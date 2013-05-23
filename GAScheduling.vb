Option Explicit On
Option Strict On
Imports System.Collections.Generic
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.Strings


Public Class GAScheduling
    Public Const UNCONSTRAINED_TIME As Double = 999999
    Dim GAS As New Junction.GeneticAlgorithmSchedulingCS

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Initialize the form
        gbResults.Visible = False
        lblResult.Text = ""
        lblSolveTime.Text = ""

        'set up the default production start time
        dtpProductionStartTime.Checked = True 'Required to set time properly when control is on a tab.
        dtpProductionStartTime.Value = Today.AddHours(6)
        'set up the default production start date
        dtpProductionDate.Checked = True 'Required to set time properly when control is on a tab.
        dtpProductionDate.Value = Today
        'set up the default production end date

        'set up the defaule procuction end time
        dtpProductionEndTime.Checked = True 'Required to set time properly when control is on a tab.
        dtpProductionEndTime.Value = Today.AddHours(23).AddMinutes(59)

        'Set the default data file
        tbWorkBookName.Text = My.Application.Info.DirectoryPath & "\TestImport.xlsx"

    End Sub

    Private Sub btnSolve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSolve.Click
        'Turn on the wait cursor
        Cursor = Cursors.WaitCursor
        'Dim EA As New Junction.ExcelAutomation

        With GAS
            'Dim dr As DataRow
            Dim i As Integer = 0

            'Initialize the properties
            .ShowStatusWhileRunning = cbShowStatus.Checked
            '.LateCost = CDbl(tbLateCost.Text) / 60
            .WashTime = CDbl(tbWashTime.Text) / 60
            .BOMPenaltyCost = CDbl(tbComponentShortagePenalty.Text)
            .ResourceNotFeasible = CDbl(tbLineInfeasibility.Text)
            .ResourcePref = CDbl(tbLineAffinity.Text)

            'The next section of code loads worksheets into multiple data tables within a single data set
            'The dataset is then passed to the scheduler via the GAS.Masterdata Property.
            Try
                'Create a master data set with line, product, changeover, and order data in it.
                Dim ds As New DataSet
                Dim ds2 As New DataSet

                'Add the Production Line Master Data
                ds = Junction.ExcelAutomation.GetDataSetFromExcel(tbWorkBookName.Text, "Resources")
                Dim xx As Integer = ds.Tables(0).Rows.Count
                Dim dt As DataTable = ds.Tables(0)
                ds.Tables.Remove(dt)
                ds2.Tables.Add(dt)


                'Add the Product Spreadsheet.
                ds = Junction.ExcelAutomation.GetDataSetFromExcel(tbWorkBookName.Text, "Products")
                dt = ds.Tables(0)
                ds.Tables.Remove(dt)
                ds2.Tables.Add(dt)

                'Add the orders data set
                ds = Junction.ExcelAutomation.GetDataSetFromExcel(tbWorkBookName.Text, "Orders")
                dt = ds.Tables(0)
                ds.Tables.Remove(dt)
                ds2.Tables.Add(dt)

                'Add the Changeover time. Time of changing (From, To) products
                ds = Junction.ExcelAutomation.GetDataSetFromExcel(tbWorkBookName.Text, "Change Over")
                dt = ds.Tables(0)
                ds.Tables.Remove(dt)
                ds2.Tables.Add(dt)

                'Add the Changeover Penalty. Penalty (not time) of changing (From, To) products
                ds = Junction.ExcelAutomation.GetDataSetFromExcel(tbWorkBookName.Text, "Change Over Penalties")
                dt = ds.Tables(0)
                ds.Tables.Remove(dt)
                ds2.Tables.Add(dt)

                'Add the BOM Items
                ds = Junction.ExcelAutomation.GetDataSetFromExcel(tbWorkBookName.Text, "BOMItems")
                dt = ds.Tables(0)
                ds.Tables.Remove(dt)
                ds2.Tables.Add(dt)

                'Send the complete dataset to the scheduler
                .MasterData = ds2


            Catch exp As Exception
                ' Will catch any error that we're not explicitly trapping.
                Dim MessageText As String = " Problem with input spreadsheet. Run is terminating."
                MessageBox.Show(exp.Message & MessageText, MessageText, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Cursor = Cursors.Default
                Exit Sub
            End Try


        End With

        '*************************************************************
        'Start the run
        '*************************************************************
        'Set up a timer
        Dim ElapsedTime As Double = DateAndTime.Timer

        'Display the results
        gbResults.Visible = True

        Try
            Dim nBulls As Integer = 1
            lblResult.Text = String.Format("{0: #,###.00}", GAS.Schedule(CDbl(tbStrengthOfFather.Text), CDbl(tbMutationProbability.Text), CInt(tbGenerations.Text) _
                                      , CDbl(tbDeathRate.Text), CInt(tbNumberOfNonRandomOffspring.Text), CInt(tbHerdSize.Text)))
        Catch ex As Exception
            Dim MessageText As String = " Problem during execution. Run is terminating."
            MessageBox.Show(ex.Message & MessageText, MessageText, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Cursor = Cursors.Default
            Exit Sub
        End Try


        'Display the timer
        lblSolveTime.Text = ""
        ElapsedTime = DateAndTime.Timer - ElapsedTime
        lblSolveTime.Text = String.Format("{0: #,###.00}", CDbl(ElapsedTime.ToString())) & " Seconds"
        lblChangeOverTime.Text = GAS.ChangeOverTime.ToString("#,###.00") & " Hours"
        lblLateJobsLine.Text = GAS.NumberOfResourceLateJobs.ToString
        lblLateJobsService.Text = GAS.NumberOfServiceLateJobs.ToString
        lblResourceViolations.Text = GAS.NumberOfResourceFeasibilityViolations.ToString
        lblEarlyStartViolations.Text = GAS.NumberOfEarlyStartViolations.ToString
        lblBOMViolations.Text = GAS.NumberOfBOMViolations.ToString

        lblTotalTime.Text = GAS.TotalTime.ToString("#,###.00") & " Hours"
        lblRunTime.Text = GAS.RunTime.ToString("#,###.00") & " Hours"

        'reset the cursor
        Cursor = Cursors.Default

        'set the output to excel and gantt display buttons to visible
        btnOutputToExcel.Visible = True
        btnDisplayGantt.Visible = True

        'bind the gridview control to the schedule data set
        dgvSchedule.DataSource = GAS.ScheduleDataSet.Tables(0).DefaultView
        dgvSchedule.AutoResizeColumn(2, DataGridViewAutoSizeColumnMode.AllCells)
        dgvSchedule.AutoResizeColumn(3, DataGridViewAutoSizeColumnMode.AllCells)
        dgvSchedule.AutoResizeColumn(4, DataGridViewAutoSizeColumnMode.AllCells)
        dgvSchedule.AutoSize = True

    End Sub


    Private Sub ValidateRealNumberTextBoxInput(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbStrengthOfFather.Validating, tbMutationProbability.Validating, tbWashTime.Validating

        Dim tb As TextBox = CType(sender, TextBox)
        If Not IsNumeric(tb.Text) Then
            ErrorProvider1.SetError(tb, "Not a numeric value.")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(tb, "")
        End If

    End Sub

    Private Sub ValidateIntegerTextBoxInput(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbDeathRate.Validating, tbHerdSize.Validating, tbNumberOfNonRandomOffspring.Validating
        Dim tb As TextBox = CType(sender, TextBox)
        If Not Regex.IsMatch(tb.Text, "^[0-9]+$") Then
            ErrorProvider1.SetError(tb, "Not an integer value.")
        Else
            ' Clear the error.
            ErrorProvider1.SetError(tb, "")
        End If
    End Sub


    Private Sub btnOutputToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOutputToExcel.Click
        'Open a spreadsheet that shows the solution
        Junction.ExcelAutomation.CreateResultsWorksheet(GAS.ScheduleDataSet)
    End Sub


    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Function ConvertMilitaryTimeStringToDecimalHours(ByVal MilitaryTimeString As String) As Double
        Dim hours, DecimalHours As Double
        hours = CDbl(Strings.Left(MilitaryTimeString, 2))
        DecimalHours = CDbl(Strings.Right(MilitaryTimeString, 2)) / 60
        hours = hours + DecimalHours
        Return hours
    End Function

    Private Sub tbGenerations_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tbGenerations.Validating
        Dim IsInteger As Boolean = False
        IsInteger = Regex.IsMatch(tbGenerations.Text, "^[0-9]+$")
        If IsInteger Then
            If CInt(tbGenerations.Text) >= 1 Then
                ' Clear the any error that may be set already.
                ErrorProvider1.SetError(tbGenerations, "")
            Else
                ErrorProvider1.SetError(tbGenerations, "Must be an integer value greater than or equal to 1.")
            End If
        Else
            ErrorProvider1.SetError(tbGenerations, "Must be an integer value greater than or equal to 1.")
        End If
    End Sub


    Private Sub btnSelectSpreadSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectSpreadSheet.Click
        Dim DefaultDir As String = My.Application.Info.DirectoryPath
        Dim LoadedOK As Boolean = False
        OpenFileDialog1.InitialDirectory = DefaultDir
        OpenFileDialog1.FileName = "TestImport.xlsx"
        OpenFileDialog1.Filter = "Excel 2007 Workbooks (*.xlsx)|*.xlsx|Excel 98-2005 Workbooks (*.xls)|*.xls"
        OpenFileDialog1.CheckFileExists() = True
        OpenFileDialog1.ShowReadOnly() = True
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            tbWorkBookName.Text = OpenFileDialog1.FileName
        Else
            MsgBox("Error Selecting File", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub dtpProductionDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpProductionDate.ValueChanged
        dtpProductionStartTime.Value = dtpProductionDate.Value.Date + dtpProductionStartTime.Value.TimeOfDay
    End Sub

    Private Sub dtpProductionEndDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpProductionEndDate.ValueChanged
        dtpProductionEndTime.Value = dtpProductionEndDate.Value.Date + dtpProductionEndTime.Value.TimeOfDay
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayGantt.Click
        Dim ds As DataSet = GAS.ScheduleDataSet
        Dim ff As New Junction.GanttFormCS
        ff.DS = GAS.ScheduleDataSet
        ff.Show()
    End Sub

    Private Sub dgvSchedule_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles dgvSchedule.Paint
        'set the column colors
        Dim dgvr As DataGridViewRow
        For Each dgvr In dgvSchedule.Rows
            If CType(dgvr.Cells("Resource Late").Value, Boolean) Or CType(dgvr.Cells("Service Late").Value, Boolean) Or CType(dgvr.Cells("Early Violation").Value, Boolean) Or CType(dgvr.Cells("Resource Feasibility").Value, Boolean) Or CType(dgvr.Cells("BOM Violation").Value, Boolean) Then
                dgvr.DefaultCellStyle.BackColor = Color.LightPink
            Else
                'dgvr.DefaultCellStyle.BackColor =
            End If
        Next
    End Sub
End Class


