<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GAScheduling
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnSolve = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.gbResults = New System.Windows.Forms.GroupBox()
        Me.lblChangeOverTime = New System.Windows.Forms.Label()
        Me.lblRunTime = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblTotalTime = New System.Windows.Forms.Label()
        Me.lblSolveTime = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblResourceViolations = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblEarlyStartViolations = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblLateJobsLine = New System.Windows.Forms.Label()
        Me.LineLateJobs = New System.Windows.Forms.Label()
        Me.lblLateJobsService = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnOutputToExcel = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tcGAFormTabs = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.lblBOMViolations = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnDisplayGantt = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSelectSpreadSheet = New System.Windows.Forms.Button()
        Me.tbWorkBookName = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbShowStatus = New System.Windows.Forms.CheckBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbDeathRate = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbGenerations = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbHerdSize = New System.Windows.Forms.TextBox()
        Me.tbMutationProbability = New System.Windows.Forms.TextBox()
        Me.lblStrengthOfFather = New System.Windows.Forms.Label()
        Me.tbStrengthOfFather = New System.Windows.Forms.TextBox()
        Me.tbNumberOfNonRandomOffspring = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tbComponentShortagePenalty = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tbLineInfeasibility = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.tbLineAffinity = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tbWashTime = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbLateCost = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbOvertimeIncrementCost = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tbStandardCost = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dtpProductionEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtpProductionDate = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpProductionStartTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpProductionEndTime = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tbOvertimeStart = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgvSchedule = New System.Windows.Forms.DataGridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.gbResults.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcGAFormTabs.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSolve
        '
        Me.btnSolve.Location = New System.Drawing.Point(624, 333)
        Me.btnSolve.Name = "btnSolve"
        Me.btnSolve.Size = New System.Drawing.Size(75, 23)
        Me.btnSolve.TabIndex = 0
        Me.btnSolve.Text = "Solve"
        Me.btnSolve.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Best Value"
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResult.Location = New System.Drawing.Point(121, 32)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(112, 20)
        Me.lblResult.TabIndex = 8
        Me.lblResult.Text = "Solution Value"
        Me.ToolTip1.SetToolTip(Me.lblResult, "Value of the Fitness Function of the best solution found.")
        '
        'gbResults
        '
        Me.gbResults.Controls.Add(Me.lblChangeOverTime)
        Me.gbResults.Controls.Add(Me.lblRunTime)
        Me.gbResults.Controls.Add(Me.Label22)
        Me.gbResults.Controls.Add(Me.lblTotalTime)
        Me.gbResults.Controls.Add(Me.lblSolveTime)
        Me.gbResults.Controls.Add(Me.Label21)
        Me.gbResults.Controls.Add(Me.Label7)
        Me.gbResults.Controls.Add(Me.Label20)
        Me.gbResults.Controls.Add(Me.Label3)
        Me.gbResults.Controls.Add(Me.lblResult)
        Me.gbResults.Location = New System.Drawing.Point(22, 21)
        Me.gbResults.Name = "gbResults"
        Me.gbResults.Size = New System.Drawing.Size(260, 171)
        Me.gbResults.TabIndex = 17
        Me.gbResults.TabStop = False
        Me.gbResults.Text = "Results"
        '
        'lblChangeOverTime
        '
        Me.lblChangeOverTime.AutoSize = True
        Me.lblChangeOverTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangeOverTime.Location = New System.Drawing.Point(125, 114)
        Me.lblChangeOverTime.Name = "lblChangeOverTime"
        Me.lblChangeOverTime.Size = New System.Drawing.Size(18, 20)
        Me.lblChangeOverTime.TabIndex = 26
        Me.lblChangeOverTime.Text = "0"
        Me.ToolTip1.SetToolTip(Me.lblChangeOverTime, "Sum of change over times for all jobs.")
        '
        'lblRunTime
        '
        Me.lblRunTime.AutoSize = True
        Me.lblRunTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRunTime.Location = New System.Drawing.Point(125, 88)
        Me.lblRunTime.Name = "lblRunTime"
        Me.lblRunTime.Size = New System.Drawing.Size(18, 20)
        Me.lblRunTime.TabIndex = 30
        Me.lblRunTime.Text = "0"
        Me.ToolTip1.SetToolTip(Me.lblRunTime, "Sum of Processing Times for all Jobs.")
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(19, 119)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(96, 13)
        Me.Label22.TabIndex = 25
        Me.Label22.Text = "Change Over Time"
        Me.ToolTip1.SetToolTip(Me.Label22, "Sum of change over times for all jobs.")
        '
        'lblTotalTime
        '
        Me.lblTotalTime.AutoSize = True
        Me.lblTotalTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalTime.Location = New System.Drawing.Point(125, 141)
        Me.lblTotalTime.Name = "lblTotalTime"
        Me.lblTotalTime.Size = New System.Drawing.Size(18, 20)
        Me.lblTotalTime.TabIndex = 24
        Me.lblTotalTime.Text = "0"
        Me.ToolTip1.SetToolTip(Me.lblTotalTime, "Total time required to run all jobs. Equal to Processing Time + Change Over Time." & _
        "")
        '
        'lblSolveTime
        '
        Me.lblSolveTime.AutoSize = True
        Me.lblSolveTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSolveTime.Location = New System.Drawing.Point(121, 62)
        Me.lblSolveTime.Name = "lblSolveTime"
        Me.lblSolveTime.Size = New System.Drawing.Size(86, 20)
        Me.lblSolveTime.TabIndex = 10
        Me.lblSolveTime.Text = "Solve Time"
        Me.ToolTip1.SetToolTip(Me.lblSolveTime, "Time required to run this scenario.")
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(18, 93)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(85, 13)
        Me.Label21.TabIndex = 29
        Me.Label21.Text = "Processing Time"
        Me.ToolTip1.SetToolTip(Me.Label21, "Sum of Processing Times for all Jobs.")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Solve Time"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(19, 146)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(57, 13)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "Total Time"
        Me.ToolTip1.SetToolTip(Me.Label20, "Total time required to run all jobs. Equal to Processing Time + Change Over Time." & _
        "")
        '
        'lblResourceViolations
        '
        Me.lblResourceViolations.AutoSize = True
        Me.lblResourceViolations.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResourceViolations.Location = New System.Drawing.Point(124, 126)
        Me.lblResourceViolations.Name = "lblResourceViolations"
        Me.lblResourceViolations.Size = New System.Drawing.Size(18, 20)
        Me.lblResourceViolations.TabIndex = 36
        Me.lblResourceViolations.Text = "0"
        Me.ToolTip1.SetToolTip(Me.lblResourceViolations, "Number of Jobs that did not meet scheduling constraints.")
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(17, 126)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(101, 13)
        Me.Label25.TabIndex = 35
        Me.Label25.Text = "Resource Violations"
        Me.ToolTip1.SetToolTip(Me.Label25, "Number of Jobs that did not meet scheduling constraints.")
        '
        'lblEarlyStartViolations
        '
        Me.lblEarlyStartViolations.AutoSize = True
        Me.lblEarlyStartViolations.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEarlyStartViolations.Location = New System.Drawing.Point(124, 94)
        Me.lblEarlyStartViolations.Name = "lblEarlyStartViolations"
        Me.lblEarlyStartViolations.Size = New System.Drawing.Size(18, 20)
        Me.lblEarlyStartViolations.TabIndex = 34
        Me.lblEarlyStartViolations.Text = "0"
        Me.ToolTip1.SetToolTip(Me.lblEarlyStartViolations, "Number of Jobs that did not meet scheduling constraints.")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Early Start Violations"
        Me.ToolTip1.SetToolTip(Me.Label6, "Number of Jobs that did not meet scheduling constraints.")
        '
        'lblLateJobsLine
        '
        Me.lblLateJobsLine.AutoSize = True
        Me.lblLateJobsLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLateJobsLine.Location = New System.Drawing.Point(125, 30)
        Me.lblLateJobsLine.Name = "lblLateJobsLine"
        Me.lblLateJobsLine.Size = New System.Drawing.Size(18, 20)
        Me.lblLateJobsLine.TabIndex = 32
        Me.lblLateJobsLine.Text = "0"
        Me.ToolTip1.SetToolTip(Me.lblLateJobsLine, "Number of Jobs that did not meet scheduling constraints.")
        '
        'LineLateJobs
        '
        Me.LineLateJobs.AutoSize = True
        Me.LineLateJobs.Location = New System.Drawing.Point(19, 30)
        Me.LineLateJobs.Name = "LineLateJobs"
        Me.LineLateJobs.Size = New System.Drawing.Size(82, 13)
        Me.LineLateJobs.TabIndex = 31
        Me.LineLateJobs.Text = "Late Jobs - Line"
        Me.ToolTip1.SetToolTip(Me.LineLateJobs, "Number of Jobs that did not meet scheduling constraints.")
        '
        'lblLateJobsService
        '
        Me.lblLateJobsService.AutoSize = True
        Me.lblLateJobsService.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLateJobsService.Location = New System.Drawing.Point(125, 62)
        Me.lblLateJobsService.Name = "lblLateJobsService"
        Me.lblLateJobsService.Size = New System.Drawing.Size(18, 20)
        Me.lblLateJobsService.TabIndex = 28
        Me.lblLateJobsService.Text = "0"
        Me.ToolTip1.SetToolTip(Me.lblLateJobsService, "Number of Jobs that did not meet scheduling constraints.")
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(18, 62)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(92, 13)
        Me.Label24.TabIndex = 27
        Me.Label24.Text = "Late Jobs-Service"
        Me.ToolTip1.SetToolTip(Me.Label24, "Number of Jobs that did not meet scheduling constraints.")
        '
        'btnOutputToExcel
        '
        Me.btnOutputToExcel.Location = New System.Drawing.Point(368, 333)
        Me.btnOutputToExcel.Name = "btnOutputToExcel"
        Me.btnOutputToExcel.Size = New System.Drawing.Size(75, 41)
        Me.btnOutputToExcel.TabIndex = 22
        Me.btnOutputToExcel.Text = "Output to Excel"
        Me.btnOutputToExcel.UseVisualStyleBackColor = True
        Me.btnOutputToExcel.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'tcGAFormTabs
        '
        Me.tcGAFormTabs.Controls.Add(Me.TabPage1)
        Me.tcGAFormTabs.Controls.Add(Me.TabPage2)
        Me.tcGAFormTabs.Controls.Add(Me.TabPage3)
        Me.tcGAFormTabs.Controls.Add(Me.TabPage4)
        Me.tcGAFormTabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcGAFormTabs.Location = New System.Drawing.Point(0, 0)
        Me.tcGAFormTabs.Name = "tcGAFormTabs"
        Me.tcGAFormTabs.SelectedIndex = 0
        Me.tcGAFormTabs.Size = New System.Drawing.Size(779, 469)
        Me.tcGAFormTabs.TabIndex = 23
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox7)
        Me.TabPage1.Controls.Add(Me.btnDisplayGantt)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.btnSolve)
        Me.TabPage1.Controls.Add(Me.gbResults)
        Me.TabPage1.Controls.Add(Me.btnOutputToExcel)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(771, 443)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Main"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.lblBOMViolations)
        Me.GroupBox7.Controls.Add(Me.Label5)
        Me.GroupBox7.Controls.Add(Me.Label24)
        Me.GroupBox7.Controls.Add(Me.lblResourceViolations)
        Me.GroupBox7.Controls.Add(Me.lblLateJobsService)
        Me.GroupBox7.Controls.Add(Me.LineLateJobs)
        Me.GroupBox7.Controls.Add(Me.Label25)
        Me.GroupBox7.Controls.Add(Me.lblLateJobsLine)
        Me.GroupBox7.Controls.Add(Me.Label6)
        Me.GroupBox7.Controls.Add(Me.lblEarlyStartViolations)
        Me.GroupBox7.Location = New System.Drawing.Point(22, 211)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(260, 192)
        Me.GroupBox7.TabIndex = 37
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Constraint Violations"
        '
        'lblBOMViolations
        '
        Me.lblBOMViolations.AutoSize = True
        Me.lblBOMViolations.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBOMViolations.Location = New System.Drawing.Point(124, 159)
        Me.lblBOMViolations.Name = "lblBOMViolations"
        Me.lblBOMViolations.Size = New System.Drawing.Size(18, 20)
        Me.lblBOMViolations.TabIndex = 38
        Me.lblBOMViolations.Text = "0"
        Me.ToolTip1.SetToolTip(Me.lblBOMViolations, "Number of Jobs that did not meet scheduling constraints.")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "BOM Violations"
        Me.ToolTip1.SetToolTip(Me.Label5, "Number of Jobs that did not meet scheduling constraints.")
        '
        'btnDisplayGantt
        '
        Me.btnDisplayGantt.Location = New System.Drawing.Point(462, 333)
        Me.btnDisplayGantt.Name = "btnDisplayGantt"
        Me.btnDisplayGantt.Size = New System.Drawing.Size(75, 41)
        Me.btnDisplayGantt.TabIndex = 23
        Me.btnDisplayGantt.Text = "Display Gantt Chart"
        Me.btnDisplayGantt.UseVisualStyleBackColor = True
        Me.btnDisplayGantt.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSelectSpreadSheet)
        Me.GroupBox1.Controls.Add(Me.tbWorkBookName)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.cbShowStatus)
        Me.GroupBox1.Location = New System.Drawing.Point(359, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 148)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Run Conditions"
        '
        'btnSelectSpreadSheet
        '
        Me.btnSelectSpreadSheet.AccessibleName = ""
        Me.btnSelectSpreadSheet.Location = New System.Drawing.Point(281, 57)
        Me.btnSelectSpreadSheet.Name = "btnSelectSpreadSheet"
        Me.btnSelectSpreadSheet.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectSpreadSheet.TabIndex = 18
        Me.btnSelectSpreadSheet.Text = "Browse"
        Me.btnSelectSpreadSheet.UseVisualStyleBackColor = True
        '
        'tbWorkBookName
        '
        Me.tbWorkBookName.Location = New System.Drawing.Point(9, 57)
        Me.tbWorkBookName.Name = "tbWorkBookName"
        Me.tbWorkBookName.Size = New System.Drawing.Size(251, 20)
        Me.tbWorkBookName.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.tbWorkBookName, "Name of the Excel Workbook Containing the Orders, Change Over, and Product Info")
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 41)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(92, 13)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Work Book Name"
        '
        'cbShowStatus
        '
        Me.cbShowStatus.AutoSize = True
        Me.cbShowStatus.Checked = True
        Me.cbShowStatus.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbShowStatus.Location = New System.Drawing.Point(9, 89)
        Me.cbShowStatus.Name = "cbShowStatus"
        Me.cbShowStatus.Size = New System.Drawing.Size(159, 17)
        Me.cbShowStatus.TabIndex = 13
        Me.cbShowStatus.Text = "Show Status While Running"
        Me.ToolTip1.SetToolTip(Me.cbShowStatus, "Displays a status form that updates as the solution is evolving.")
        Me.cbShowStatus.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.tbDeathRate)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.tbGenerations)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.tbHerdSize)
        Me.TabPage2.Controls.Add(Me.tbMutationProbability)
        Me.TabPage2.Controls.Add(Me.lblStrengthOfFather)
        Me.TabPage2.Controls.Add(Me.tbStrengthOfFather)
        Me.TabPage2.Controls.Add(Me.tbNumberOfNonRandomOffspring)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(771, 443)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Optimization Parameters"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 246)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "% Replacement"
        '
        'tbDeathRate
        '
        Me.tbDeathRate.Location = New System.Drawing.Point(29, 262)
        Me.tbDeathRate.Name = "tbDeathRate"
        Me.tbDeathRate.Size = New System.Drawing.Size(100, 20)
        Me.tbDeathRate.TabIndex = 34
        Me.tbDeathRate.Text = "50"
        Me.ToolTip1.SetToolTip(Me.tbDeathRate, "An integer between 0 and 100 that sets the portion of the population that is repl" & _
        "aced each generation.")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 170)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Number of Generations"
        '
        'tbGenerations
        '
        Me.tbGenerations.Location = New System.Drawing.Point(29, 186)
        Me.tbGenerations.Name = "tbGenerations"
        Me.tbGenerations.Size = New System.Drawing.Size(100, 20)
        Me.tbGenerations.TabIndex = 26
        Me.tbGenerations.Text = "1000"
        Me.ToolTip1.SetToolTip(Me.tbGenerations, "An integer number that determines the number of generations that will run. A mini" & _
        "mum of 1000 is suggested.")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(188, 172)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Number of Individuals"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Mutation Probability"
        '
        'tbHerdSize
        '
        Me.tbHerdSize.Location = New System.Drawing.Point(191, 188)
        Me.tbHerdSize.Name = "tbHerdSize"
        Me.tbHerdSize.Size = New System.Drawing.Size(100, 20)
        Me.tbHerdSize.TabIndex = 32
        Me.tbHerdSize.Text = "50"
        Me.ToolTip1.SetToolTip(Me.tbHerdSize, "The number of individuals per group. More individuals increase the chance of find" & _
        "ing a better solution, but also increases run time.")
        '
        'tbMutationProbability
        '
        Me.tbMutationProbability.Location = New System.Drawing.Point(29, 110)
        Me.tbMutationProbability.Name = "tbMutationProbability"
        Me.tbMutationProbability.Size = New System.Drawing.Size(100, 20)
        Me.tbMutationProbability.TabIndex = 24
        Me.tbMutationProbability.Text = "0.2"
        Me.ToolTip1.SetToolTip(Me.tbMutationProbability, "A number between 0 and 1.0 that sets the frequency of random gene mutations when " & _
        "producing offspring")
        '
        'lblStrengthOfFather
        '
        Me.lblStrengthOfFather.AutoSize = True
        Me.lblStrengthOfFather.Location = New System.Drawing.Point(26, 27)
        Me.lblStrengthOfFather.Name = "lblStrengthOfFather"
        Me.lblStrengthOfFather.Size = New System.Drawing.Size(61, 13)
        Me.lblStrengthOfFather.TabIndex = 23
        Me.lblStrengthOfFather.Text = "Dominance"
        Me.ToolTip1.SetToolTip(Me.lblStrengthOfFather, "A real number between 0 and 1.0 that describes the dominance of the best solution" & _
        "'s genes.")
        '
        'tbStrengthOfFather
        '
        Me.tbStrengthOfFather.Location = New System.Drawing.Point(29, 43)
        Me.tbStrengthOfFather.Name = "tbStrengthOfFather"
        Me.tbStrengthOfFather.Size = New System.Drawing.Size(100, 20)
        Me.tbStrengthOfFather.TabIndex = 22
        Me.tbStrengthOfFather.Text = ".40"
        Me.ToolTip1.SetToolTip(Me.tbStrengthOfFather, "A real number between 0 and 1.0 that describes the dominance of the best solution" & _
        "'s genes.")
        '
        'tbNumberOfNonRandomOffspring
        '
        Me.tbNumberOfNonRandomOffspring.Location = New System.Drawing.Point(191, 43)
        Me.tbNumberOfNonRandomOffspring.Name = "tbNumberOfNonRandomOffspring"
        Me.tbNumberOfNonRandomOffspring.Size = New System.Drawing.Size(100, 20)
        Me.tbNumberOfNonRandomOffspring.TabIndex = 28
        Me.tbNumberOfNonRandomOffspring.Text = "0"
        Me.ToolTip1.SetToolTip(Me.tbNumberOfNonRandomOffspring, "The number of hueristiaclly generated starting offspring")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(188, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(195, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Number of non-random starting offspring"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox6)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(771, 443)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Production Parameters"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label30)
        Me.GroupBox6.Controls.Add(Me.tbComponentShortagePenalty)
        Me.GroupBox6.Location = New System.Drawing.Point(548, 195)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(193, 93)
        Me.GroupBox6.TabIndex = 50
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "BOM Parameters"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(18, 39)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(145, 13)
        Me.Label30.TabIndex = 44
        Me.Label30.Text = "Component Shortage Penalty"
        Me.ToolTip1.SetToolTip(Me.Label30, "Time in minutes that will be added to the base changeover time when there previou" & _
        "s job contained allergens not in the following job.")
        '
        'tbComponentShortagePenalty
        '
        Me.tbComponentShortagePenalty.Location = New System.Drawing.Point(21, 55)
        Me.tbComponentShortagePenalty.Name = "tbComponentShortagePenalty"
        Me.tbComponentShortagePenalty.Size = New System.Drawing.Size(100, 20)
        Me.tbComponentShortagePenalty.TabIndex = 43
        Me.tbComponentShortagePenalty.Text = "300"
        Me.ToolTip1.SetToolTip(Me.tbComponentShortagePenalty, "Time in minutes that will be added to the base changeover time when there previou" & _
        "s job contained allergens not in the following job.")
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label27)
        Me.GroupBox5.Controls.Add(Me.tbLineInfeasibility)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.tbLineAffinity)
        Me.GroupBox5.Location = New System.Drawing.Point(17, 306)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(282, 93)
        Me.GroupBox5.TabIndex = 49
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Production Line Parameters"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(135, 39)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(58, 13)
        Me.Label27.TabIndex = 46
        Me.Label27.Text = "Infeasibility"
        Me.ToolTip1.SetToolTip(Me.Label27, "Time added to base setup time when changing products.")
        '
        'tbLineInfeasibility
        '
        Me.tbLineInfeasibility.Location = New System.Drawing.Point(138, 55)
        Me.tbLineInfeasibility.Name = "tbLineInfeasibility"
        Me.tbLineInfeasibility.Size = New System.Drawing.Size(100, 20)
        Me.tbLineInfeasibility.TabIndex = 45
        Me.tbLineInfeasibility.Text = "1000"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(18, 39)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(61, 13)
        Me.Label28.TabIndex = 44
        Me.Label28.Text = "Line Affinity"
        Me.ToolTip1.SetToolTip(Me.Label28, "Time in minutes that will be added to the base changeover time when there previou" & _
        "s job contained allergens not in the following job.")
        '
        'tbLineAffinity
        '
        Me.tbLineAffinity.Location = New System.Drawing.Point(21, 55)
        Me.tbLineAffinity.Name = "tbLineAffinity"
        Me.tbLineAffinity.Size = New System.Drawing.Size(100, 20)
        Me.tbLineAffinity.TabIndex = 43
        Me.tbLineAffinity.Text = "50"
        Me.ToolTip1.SetToolTip(Me.tbLineAffinity, "Time in minutes that will be added to the base changeover time when there previou" & _
        "s job contained allergens not in the following job.")
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.tbWashTime)
        Me.GroupBox4.Location = New System.Drawing.Point(548, 18)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(193, 112)
        Me.GroupBox4.TabIndex = 48
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Allergen Impact"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(18, 39)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 13)
        Me.Label19.TabIndex = 44
        Me.Label19.Text = "Alergen Alert Time"
        Me.ToolTip1.SetToolTip(Me.Label19, "Time in minutes that will be added to the base changeover time when there previou" & _
        "s job contained allergens not in the following job.")
        '
        'tbWashTime
        '
        Me.tbWashTime.Location = New System.Drawing.Point(21, 55)
        Me.tbWashTime.Name = "tbWashTime"
        Me.tbWashTime.Size = New System.Drawing.Size(100, 20)
        Me.tbWashTime.TabIndex = 43
        Me.tbWashTime.Text = "0"
        Me.ToolTip1.SetToolTip(Me.tbWashTime, "Time in minutes that will be added to the base changeover time when there previou" & _
        "s job contained allergens not in the following job.")
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.tbLateCost)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.tbOvertimeIncrementCost)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.tbStandardCost)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Location = New System.Drawing.Point(320, 18)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(193, 270)
        Me.GroupBox3.TabIndex = 47
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cost Parameters"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(33, 177)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 13)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "Late Cost"
        '
        'tbLateCost
        '
        Me.tbLateCost.Location = New System.Drawing.Point(36, 193)
        Me.tbLateCost.Name = "tbLateCost"
        Me.tbLateCost.Size = New System.Drawing.Size(100, 20)
        Me.tbLateCost.TabIndex = 44
        Me.tbLateCost.Text = "2000"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(33, 101)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(147, 13)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "Overtime Incremental Cost/Hr"
        '
        'tbOvertimeIncrementCost
        '
        Me.tbOvertimeIncrementCost.Location = New System.Drawing.Point(36, 117)
        Me.tbOvertimeIncrementCost.Name = "tbOvertimeIncrementCost"
        Me.tbOvertimeIncrementCost.Size = New System.Drawing.Size(100, 20)
        Me.tbOvertimeIncrementCost.TabIndex = 42
        Me.tbOvertimeIncrementCost.Text = "50"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(33, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 13)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "Standard Cost/HR"
        '
        'tbStandardCost
        '
        Me.tbStandardCost.Location = New System.Drawing.Point(36, 50)
        Me.tbStandardCost.Name = "tbStandardCost"
        Me.tbStandardCost.Size = New System.Drawing.Size(100, 20)
        Me.tbStandardCost.TabIndex = 40
        Me.tbStandardCost.Text = "100"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.dtpProductionEndDate)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.dtpProductionDate)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.dtpProductionStartTime)
        Me.GroupBox2.Controls.Add(Me.dtpProductionEndTime)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.tbOvertimeStart)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(17, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(282, 270)
        Me.GroupBox2.TabIndex = 46
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Time Parameters"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(19, 99)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 13)
        Me.Label16.TabIndex = 60
        Me.Label16.Text = "Production End Date"
        '
        'dtpProductionEndDate
        '
        Me.dtpProductionEndDate.Checked = False
        Me.dtpProductionEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProductionEndDate.Location = New System.Drawing.Point(22, 115)
        Me.dtpProductionEndDate.Name = "dtpProductionEndDate"
        Me.dtpProductionEndDate.ShowUpDown = True
        Me.dtpProductionEndDate.Size = New System.Drawing.Size(106, 20)
        Me.dtpProductionEndDate.TabIndex = 61
        Me.dtpProductionEndDate.Value = New Date(2007, 12, 31, 0, 0, 0, 0)
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(19, 31)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 13)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Production Start Date"
        '
        'dtpProductionDate
        '
        Me.dtpProductionDate.Checked = False
        Me.dtpProductionDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProductionDate.Location = New System.Drawing.Point(22, 47)
        Me.dtpProductionDate.Name = "dtpProductionDate"
        Me.dtpProductionDate.ShowUpDown = True
        Me.dtpProductionDate.Size = New System.Drawing.Size(106, 20)
        Me.dtpProductionDate.TabIndex = 59
        Me.dtpProductionDate.Value = New Date(2007, 12, 31, 0, 0, 0, 0)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(147, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(109, 13)
        Me.Label13.TabIndex = 56
        Me.Label13.Text = "Production Start Time"
        '
        'dtpProductionStartTime
        '
        Me.dtpProductionStartTime.Checked = False
        Me.dtpProductionStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpProductionStartTime.Location = New System.Drawing.Point(150, 47)
        Me.dtpProductionStartTime.Name = "dtpProductionStartTime"
        Me.dtpProductionStartTime.ShowUpDown = True
        Me.dtpProductionStartTime.Size = New System.Drawing.Size(106, 20)
        Me.dtpProductionStartTime.TabIndex = 57
        Me.dtpProductionStartTime.Value = New Date(2007, 12, 31, 0, 0, 0, 0)
        '
        'dtpProductionEndTime
        '
        Me.dtpProductionEndTime.Checked = False
        Me.dtpProductionEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpProductionEndTime.Location = New System.Drawing.Point(150, 115)
        Me.dtpProductionEndTime.Name = "dtpProductionEndTime"
        Me.dtpProductionEndTime.ShowUpDown = True
        Me.dtpProductionEndTime.Size = New System.Drawing.Size(106, 20)
        Me.dtpProductionEndTime.TabIndex = 54
        Me.ToolTip1.SetToolTip(Me.dtpProductionEndTime, "End Time of Shift")
        Me.dtpProductionEndTime.Value = New Date(2007, 12, 31, 0, 0, 0, 0)
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(147, 99)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 13)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "Production End Time"
        '
        'tbOvertimeStart
        '
        Me.tbOvertimeStart.Enabled = False
        Me.tbOvertimeStart.Location = New System.Drawing.Point(22, 193)
        Me.tbOvertimeStart.Name = "tbOvertimeStart"
        Me.tbOvertimeStart.Size = New System.Drawing.Size(100, 20)
        Me.tbOvertimeStart.TabIndex = 38
        Me.tbOvertimeStart.Text = "1730"
        Me.ToolTip1.SetToolTip(Me.tbOvertimeStart, "Time when additional overtime charge kicks in given in 24 hour military format. 6" & _
        "am is 0600, 5:30pm is 1730. If Blank, there is no overtime impact.")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(19, 177)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Overtime Start"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dgvSchedule)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(771, 443)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Schedule Results"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dgvSchedule
        '
        Me.dgvSchedule.AllowUserToAddRows = False
        Me.dgvSchedule.AllowUserToDeleteRows = False
        Me.dgvSchedule.AllowUserToOrderColumns = True
        Me.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSchedule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSchedule.Location = New System.Drawing.Point(3, 3)
        Me.dgvSchedule.Name = "dgvSchedule"
        Me.dgvSchedule.ReadOnly = True
        Me.dgvSchedule.Size = New System.Drawing.Size(765, 437)
        Me.dgvSchedule.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GAScheduling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 469)
        Me.Controls.Add(Me.tcGAFormTabs)
        Me.Name = "GAScheduling"
        Me.Text = "Genetic Algorithm Scheduling - Demo and Test Interface"
        Me.gbResults.ResumeLayout(False)
        Me.gbResults.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcGAFormTabs.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSolve As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents gbResults As System.Windows.Forms.GroupBox
    Friend WithEvents lblSolveTime As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnOutputToExcel As System.Windows.Forms.Button
    Friend WithEvents tcGAFormTabs As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbDeathRate As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbGenerations As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbHerdSize As System.Windows.Forms.TextBox
    Friend WithEvents tbMutationProbability As System.Windows.Forms.TextBox
    Friend WithEvents lblStrengthOfFather As System.Windows.Forms.Label
    Friend WithEvents tbStrengthOfFather As System.Windows.Forms.TextBox
    Friend WithEvents tbNumberOfNonRandomOffspring As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbShowStatus As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tbStandardCost As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbOvertimeStart As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbOvertimeIncrementCost As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbLateCost As System.Windows.Forms.TextBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents dgvSchedule As System.Windows.Forms.DataGridView
    Friend WithEvents btnSelectSpreadSheet As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tbWorkBookName As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblLateJobsService As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblChangeOverTime As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblTotalTime As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblRunTime As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpProductionEndTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dtpProductionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpProductionStartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtpProductionEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tbWashTime As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tbLineInfeasibility As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents tbLineAffinity As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents tbComponentShortagePenalty As System.Windows.Forms.TextBox
    Friend WithEvents btnDisplayGantt As System.Windows.Forms.Button
    Friend WithEvents lblLateJobsLine As System.Windows.Forms.Label
    Friend WithEvents LineLateJobs As System.Windows.Forms.Label
    Friend WithEvents lblResourceViolations As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblEarlyStartViolations As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents lblBOMViolations As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
