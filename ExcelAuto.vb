Imports System.Net
Imports Microsoft.Office.Interop
Module ExcelAutomation

    Public Sub CreateResultsWorksheet(ByVal Schedule As DataSet)
        Dim xlApp As Excel.Application
        Dim ws As Excel.Worksheet
        Dim i, outRows, outCols As Integer

        'Rows and colums are transposed for printing
        outCols = Schedule.Tables(0).Columns.Count
        outRows = Schedule.Tables(0).Rows.Count + 1 'leave room for row and column headers


        Dim OutputArray(outRows, outCols) As Object
        'Note: Excel Array is 1-based, not 0-based
        OutputArray(0, 0) = "Job Number"
        OutputArray(0, 1) = "Product"
        OutputArray(0, 2) = "Product Name"
        OutputArray(0, 3) = "End Time"
        OutputArray(0, 4) = "Time Due"
        OutputArray(0, 5) = "Production Line"
        OutputArray(0, 6) = "Production Order"
        OutputArray(0, 7) = "Setup Time"



        Dim d As DateTime = Today
        Dim dr As DataRow
        For i = 1 To outRows - 1
            dr = Schedule.Tables(0).Rows(i - 1)
            OutputArray(i, 0) = dr(0)
            OutputArray(i, 1) = dr(1)
            OutputArray(i, 2) = dr(2)
            OutputArray(i, 3) = dr(3)
            OutputArray(i, 4) = dr(4)
            OutputArray(i, 5) = dr(5)
            OutputArray(i, 6) = dr(6)
            OutputArray(i, 7) = dr(7)
        Next

        'Create the Excel Application and do a Big Bang output
        xlApp = CType(CreateObject("Excel.Application"), Excel.Application)
        xlApp.Workbooks.Add()
        ws = CType(xlApp.Workbooks(1).Worksheets(1), Excel.Worksheet) 'create a worksheet
        ws.Name = "Schedule Results"
        ws.Range(ws.Cells(1, 1), ws.Cells(outRows + 1, outCols + 1)).Value = OutputArray
        ws.Range("A1:H1").Font.Bold = True
        ws.Range("A1:H1").Font.Size = 14
        'ws.Range("A1:E1").Columns.AutoFit()
        ws.Range(ws.Cells(1, 1), ws.Cells(outRows + 1, outCols + 1)).Columns.AutoFit()
        xlApp.Visible = True
        xlApp = Nothing
    End Sub
   
    Public Function iGetDataSetFromExcel(ByVal PathName As String, ByVal WorkbookName As String) As DataSet 'Works for XLS files not for XLSX

        Dim strConn As String

        Dim Office2007 As Boolean 'need a different connection string based on the version of Excel
        If Right(PathName, 4) = "xlsx" Then Office2007 = True

        If Office2007 Then
            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & PathName & ";Extended Properties= ""Excel 12.0;HDR=YES;"""
        Else
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" _
                     & "Data Source=" & PathName & "; Extended Properties=Excel 8.0;"
        End If

        Dim ds As New DataSet
        'You must use the $ after the object you reference in the spreadsheet
        'Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [Sheet1$]", strConn)
        Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM [" & WorkbookName & "$]", strConn)
        da.TableMappings.Add("Table", "ExcelTest")
        da.Fill(ds)
        'The first row in the spreadsheet will be used as the column headers
        'Bind to a gridview using the following syntax
        'DataGridView1.DataSource = ds.Tables(0).DefaultView
        Return ds
    End Function

End Module
