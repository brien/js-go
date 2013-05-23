using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Junction
{
    public class ChartBarDate
    {
        public struct Location
        {
            public Point Left;// = new Point(0, 0);
            public Point Right; // = new Point(0, 0);
        }
        public DateTime  StartValue;
        public DateTime EndValue;
        public Boolean IsSetup;
        public Boolean IsConstraintViolation;
        public int DataSetIndex;
        public Boolean IsDeleted; // = false;

        public Color color;
        public Color HoverColor;

        public string Text;
        public object Value;

        public int RowIndex;

        public Location TopLocation = new Location();
        public Location BottomLocation = new Location();

        public Boolean HideFromMouseMove = false;
    }   
}