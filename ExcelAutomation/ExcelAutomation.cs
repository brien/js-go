using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Office.Interop.Excel;


namespace Junction
{
    public  static class ExcelAutomation
    {
        public static DataSet GetDataSetFromExcel(string PathName, string WorkbookName)
        {
            string strConn;
            
            if (PathName.Substring(PathName.Length - 4) == "xlsx")
            {
                strConn="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + PathName + @";Extended Properties= ""Excel 12.0;HDR=YES;""";
            }
            else
            {
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + PathName + "; Extended Properties=Excel 8.0;";
            }
            DataSet  ds = new DataSet();
            //    You must use the $ after the object you reference in the spreadsheet
            System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [" + WorkbookName + "$]", strConn);
            da.TableMappings.Add("Table", WorkbookName);
            da.Fill(ds);
            return ds;
        }

        public static void CreateResultsWorksheet(DataSet Schedule)
        {
            // Frequenty-used variable for optional arguments.
            object m_objOpt = System.Reflection.Missing.Value;

            Application xlApp = new Application();
            Worksheet ws = new Worksheet();
            int outRows, outCols;

            //Rows and columns are transposed for printing
            outCols = Schedule.Tables[0].Columns.Count;
            outRows = Schedule.Tables[0].Rows.Count + 1; //leave roof for row and column headers

            object[,] OutputArray = new object[outRows, outCols];
            ////Note Excel Arrays are 1-based, not 0-based
            for (int i = 0; i < outCols; i++)
            {
                //Put the titles into the spreadsheet.
                OutputArray[0, i] = Schedule.Tables[0].Columns[i].ColumnName;
            }

            for (int i = 1; i < outRows; i++)
            {
                for (int j = 0;j < outCols; j++)
                {
                    DataRow dr = Schedule.Tables[0].Rows[i - 1];
                    OutputArray[i, j] = dr[j];
                }
            }

            //Create a workbook and add a worksheet named "Schedule Results"
            xlApp.Workbooks.Add(m_objOpt);
            ws = (Worksheet) xlApp.Workbooks[1].Worksheets[1];
            ws.Name = "Schedule Results";

            Range r = ws.get_Range(ws.Cells[1,1],ws.Cells[outRows, outCols]);
            //put the output array into Excel in one step.
            r.Value2=OutputArray;

            //select the title columns and make them bold
            r = ws.get_Range(ws.Cells[1, 1], ws.Cells[1, outCols + 1]);
            r.Font.Bold = true;
            r.Font.Size = 14;
            
            //format any DateTime Columns
            for (int i = 0; i<outCols; i++)
            {
                if (Schedule.Tables[0].Columns[i].DataType.ToString() == "System.DateTime" )
                {
                    r = ws.get_Range(ws.Cells[1, i+1], ws.Cells[outRows + 1, i+1]);
                    r.NumberFormat = "[$-409]m/d/yy h:mm AM/PM;@";
                }
            }

            //Select the entire spreadsheet and autofit the contents
            r = ws.get_Range(ws.Cells[1, 1], ws.Cells[outRows + 1, outCols + 1]);
            r.Columns.AutoFit();
            xlApp.Visible = true;
            xlApp = null;
        }

    }
}
