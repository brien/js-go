using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Junction
{
    public static class GanttControlCS
    {
        public static void SetBarStartLeft(string rowText, Font rowTextFont,int barStartLeft, System.Windows.Forms.Control ths)
        {
            Graphics gfx = ths.CreateGraphics();
            int length = (int) gfx.MeasureString(rowText, rowTextFont, 500).Width;

            if (length > barStartLeft)
            {
                barStartLeft = length;
            }
        }

        public static void AddChartBar(string rowText, object barValue, DateTime fromTime, DateTime toTime, Color color, Color hoverColor, int rowIndex, int datasetIndex,
            bool isSetup, bool isConstraintViolation, ref List<ChartBarDate> bars, Font rowTextFont, int barStartLeft, System.Windows.Forms.Control ths)
        {
            ChartBarDate bar = new ChartBarDate();
            bar.Text = rowText;
            bar.Value = barValue;
            bar.StartValue = fromTime;
            bar.EndValue = toTime;
            bar.color = color;
            bar.HoverColor = hoverColor;
            bar.RowIndex = rowIndex;
            bar.DataSetIndex = datasetIndex;
            bar.IsSetup = isSetup;
            bar.IsConstraintViolation = isConstraintViolation;
            bars.Add(bar);
            SetBarStartLeft(rowText, rowTextFont, barStartLeft, ths);
        }

        //public static void ClearChartBars(ref List<ChartBarDate> bars)
        //{
        //    bars.Clear();
        //}
    }
}
 