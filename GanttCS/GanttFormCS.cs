using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Junction
{
    public partial class GanttFormCS : Form
    {
        private DataSet _DS;
        private Color RunColor = Color.Aqua;
        private Color SetupColor = Color.DarkRed;
        private Color LateColor = Color.Red;
        private int CurrentLine = -1;

        public DataSet DS
        {
            get
            {
                return _DS;
            }
            set
            {
                _DS = value;
                _DS.AcceptChanges();
            }
        }

        public GanttFormCS()
        {
            InitializeComponent();

            // Add a keypad handler event. 
            // The form must have preview key events set to true for this to work.
            this.KeyUp += new KeyEventHandler(GanttFormCS_KeyUp);

            //Add Mouse event handlers
            gntLineOverview.MouseMove += new MouseEventHandler(gntLineOverview_MouseMove);
            gntLineOverview.Click += new EventHandler(gntLineOverview_Click);
            gntDetail.MouseMove += new MouseEventHandler(gntDetail_MouseMove);
        }

 
        private void GanttFormCS_Load(object sender, EventArgs e)
        {
            //Display the overview gantt chart
            ShowLineOverview();
            //    show the detailed gantt breakdown for line 1 when loading the form
            ShowDetail(1);
        }

        private void ShowDetail(int Line)
        {
            CurrentLine = Line;
            gntDetail.ClearChartBars();
            label2.Text = "Resource # " + Line.ToString() + " Detail";
            gntDetail.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
            gntDetail.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59);

            DataTable dt = _DS.Tables[0];
            int i = 0;
            int etHrs, etMins;
            string ProductionLine, PrevProductionLine, TimeString, ProductName;
            int stHrs = -1;
            int  stMins= -1;
            DateTime StartTime, EndTime;
            Double Setup, RunTime, RunLength;

            //     PrevProductionLine is used to iterate through the rows of the input dataset and 
            //     determine when we have found the right production line to display
            PrevProductionLine = "";
            gntDetail.ClearSelection();

            int dbIndex = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr.RowState == DataRowState.Deleted)
                {
                    dbIndex++;
                    continue;
                }
                EndTime = (DateTime)dr["End Time"];
                Setup = (double)dr["Setup Time"];
                RunTime = (double)dr["Run Time"];
                ProductionLine = dr["Resource Number"].ToString();
                ProductName = (string)dr["Product Name"];
                if (Convert.ToInt32(ProductionLine) == Line)
                {
                    if (PrevProductionLine != ProductionLine)
                    {
                        RunLength = RunTime + Setup;
                        TimeSpan ts = new TimeSpan(0, (int)RunLength, 0);
                        StartTime = EndTime - ts;
                        TimeString = StartTime.ToString("HH:mm");
                        stHrs = Convert.ToInt32(TimeString.Substring(0, 2));
                        stMins = Convert.ToInt32(TimeString.Substring(3, 2));
                    }
                    if (Setup != 0)
                    {
                        TimeSpan ts = new TimeSpan(0, (int)RunTime, 0);
                        DateTime SetupEnd = EndTime - ts;
                        TimeString = SetupEnd.ToString("HH:mm");
                        etHrs = Convert.ToInt32(TimeString.Substring(0, 2));
                        etMins = Convert.ToInt32(TimeString.Substring(3, 2));
                        gntDetail.AddChartBar(ProductName, ProductionLine, new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, stHrs, stMins, 0),
                            new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, etHrs, etMins, 0), SetupColor, Color.Khaki, i, dbIndex, true, false);

                        stHrs = etHrs;
                        stMins = etMins;
                    }
                    TimeString = EndTime.ToString("HH:mm");
                    etHrs = Convert.ToInt32(TimeString.Substring(0, 2));
                    etMins = Convert.ToInt32(TimeString.Substring(3, 2));

                    gntDetail.AddChartBar(ProductName, ProductionLine, new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, stHrs, stMins, 0),
                            new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, etHrs, etMins, 0), RunColor, Color.Khaki, i,dbIndex ,false, false);
                    stHrs = etHrs;
                    stMins = etMins;
                    i++;
                }
                dbIndex++;
            }
            gntDetail.PaintChart();
        }

        private void ShowLineOverview()
        {
            gntLineOverview.ClearChartBars();
            lblProductName.Text = "";
            DataTable dt = DS.Tables[0];
            int LineNum = -1;
            int etHrs, etMins;
            int stHrs = -1;
            int stMins = -1;

            string ProductionLine, PrevProductionLine, Timestring, ProductName;
            DateTime StartTime, EndTime;
            double Setup, RunTime;

            //Set up time headers
            gntLineOverview.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
            gntLineOverview.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59);

            PrevProductionLine = "";
            StartTime = DateTime.Today;
            int dbIndex = -1;
            foreach (DataRow dr in dt.Rows)
            {
                dbIndex++;
                if (dr.RowState == DataRowState.Deleted) 
                {
                    continue;
                }
                EndTime = (DateTime)dr["End Time"];
                Setup = (double)dr["Setup Time"];
                RunTime = (double)dr["Run Time"];
                ProductionLine = dr["Resource Number"].ToString();
                ProductName = (string)dr["Product Name"];

                // Increment the line count
                if (ProductionLine != PrevProductionLine)
                {
                    LineNum++;
                }

                
                TimeSpan tsRun = new TimeSpan(0, (int)RunTime, 0);
                TimeSpan tsSetup = new TimeSpan(0, (int)Setup, 0);
               
                if (Setup > 0)
                {
                    StartTime = EndTime - tsRun - tsSetup;
                    Timestring = StartTime.ToString("HH:mm");
                    stHrs = Convert.ToInt32(Timestring.Substring(0, 2));
                    stMins = Convert.ToInt32(Timestring.Substring(3, 2));
                    DateTime SetupEnd = EndTime - tsRun;
                    Timestring = SetupEnd.ToString("HH:mm");
                    etHrs = Convert.ToInt32(Timestring.Substring(0, 2));
                    etMins = Convert.ToInt32(Timestring.Substring(3, 2));
                    gntLineOverview.AddChartBar("Line " + ProductionLine, ProductName, new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, stHrs, stMins, 0),
                    new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, etHrs, etMins, 0), SetupColor, Color.Khaki, LineNum,dbIndex, true, false);
                }
             
                StartTime = EndTime - tsRun;
                Timestring = StartTime.ToString("HH:mm");
                stHrs = Convert.ToInt32(Timestring.Substring(0, 2));
                stMins = Convert.ToInt32(Timestring.Substring(3, 2));
                Timestring = EndTime.ToString("HH:mm");
                etHrs = Convert.ToInt32(Timestring.Substring(0, 2));
                etMins = Convert.ToInt32(Timestring.Substring(3, 2));
                gntLineOverview.AddChartBar("Line " + ProductionLine, ProductName, new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, stHrs, stMins, 0),
                        new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, etHrs, etMins, 0), RunColor, Color.Khaki, LineNum, dbIndex, false, false);
               
                
                PrevProductionLine = ProductionLine;
            }
            gntLineOverview.PaintChart();
        }


        //Pressing the escape key generates an event for the active control.
        //In order to consistently handle the event, set the form keypreview to "true"
        // add a handler for the form keyup event and handle it here.
        private void GanttFormCS_KeyUp(object sender, KeyEventArgs e)
        {
           switch (e.KeyCode)
            {
                case Keys.Escape:
                    gntDetail.ClearSelection();
                    break;
                case Keys.Left:
                    gntDetail.NudgeSelectionEarlier();
                    break;
                case Keys.Right:
                    gntDetail.NudgeSelectionLater();
                    break;
                case Keys.Delete:
                    //MessageBox.Show("Delete Not Active");
                    gntDetail.DeleteSelection();
                    ShowDetail(CurrentLine);
                    break;
                default:
                    //do nothing
                    break;
            }
        }

       
        // Display the product name and job info when the mouse hovers over the gantt bar
        void gntLineOverview_MouseMove(object sender, MouseEventArgs e)
        {
            if (gntLineOverview.MouseOverRowText.Length > 0)
            {
                lblProductName.Text = "Product: " + gntLineOverview.MouseOverRowValue;
            }
            else
            {
                lblProductName.Text = "";
            }
        }

        void gntLineOverview_Click(object sender, EventArgs e)
        {
            if (gntLineOverview.MouseOverRowIndex != -1)
            {
                CurrentLine = Convert.ToInt32( _DS.Tables[0].Rows[gntLineOverview.MouseOverDBIndex]["Resource Number"]);
                label2.Text = CurrentLine.ToString();
                ShowDetail(CurrentLine);
            }
            else
            {
                label2.Text = "";
            }
        }

        void gntDetail_MouseMove(object sender, MouseEventArgs e)
        {
            int i = gntDetail.MouseOverDBIndex;
            //update the label if the mouse is over a valid bar
            if (i > -1 && i < _DS.Tables[0].Rows.Count)
            {
                DataRow dr = _DS.Tables[0].Rows[i];
                if (dr.RowState == DataRowState.Deleted)
                {
                    lblJobDetail.Text = "";
                    return;
                }
                TimeSpan ts = new TimeSpan(0, Convert.ToInt32(dr["Run Time"]), 0); 
                DateTime StartTime, EndTime;
                string tmp = lblJobDetail.Text;
                EndTime = (DateTime) dr["End Time"];
                StartTime = EndTime - ts;
                tmp = i.ToString() + " Product: " + dr["Product Number"].ToString() + ", " + dr["Product Name"].ToString() +
                    "    Start: " + StartTime.ToString() + "    Finish: " + dr["End Time"].ToString() +
                    "    Run Time: " + dr["Run Time"].ToString();
                if (Convert.ToInt32( dr["Setup Time"]) > 0)
                {
                    tmp = tmp + "   Setup Time " + dr["Setup Time"].ToString();
                }
                if (! dr.IsNull("Time Due"))
                {
                    tmp = tmp + "   Time Due: " + dr["Time Due"].ToString();
                }
                lblJobDetail.Text = tmp;
            }
            else
            {
                lblJobDetail.Text = "";
            }
        }
        
        private void gntDetail_BarChanged(object sender, ref List<ChartBarDate> BarValues)
        {
            // set the column for update
            _DS.Tables[0].Columns["End Time"].ReadOnly = false;

            foreach (ChartBarDate cbd in BarValues)
            {
                DataRow dr = _DS.Tables[0].Rows[cbd.DataSetIndex];
                //setup bars are not in the db so ignore
                if (!cbd.IsSetup)
                {
                    //blow away the item if it is deleted
                    if (cbd.IsDeleted)
                    {
                        dr.Delete();
                    }
                    else
                    {
                        if (dr.RowState != DataRowState.Deleted)
                        {
                            //update the end time per the edited bars
                            dr["End Time"] = cbd.EndValue;
                        }
                    }
                }
            }
            ShowLineOverview();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult cxl = MessageBox.Show("Are you sure you want to exit and loose all changes?"
                , "OK to Cancel", MessageBoxButtons.YesNo);
            if (cxl == System.Windows.Forms.DialogResult.Yes)
            {
                _DS.RejectChanges();
                this.Close();
            }
        }
    }
}
