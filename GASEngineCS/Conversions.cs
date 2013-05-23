using System;
using System.Collections;

namespace Junction
{
    public static class Conversions
    // Contains static methods for date and time conversions
    {
        public static double ConvertMilitaryTimeStringToDecimalHours(string MilitaryTimeString)
        {
            double Hours, DecimalHours;
            // Catch invalid data input errors
            try
            {
                Hours = double.Parse(MilitaryTimeString.Substring(0, 2));
                DecimalHours = double.Parse(MilitaryTimeString.Substring(2, 2)) / 60.0;
                Hours = Hours + DecimalHours;
            }
            catch (Exception)
            {
                throw new ApplicationException("Invalid time encountered.");
            }
            return Hours;
        }

        public static double ConvertDateTimetoDecimalHours(DateTime DateTimeValue)
        {
            int days, hrs, mins;
            TimeSpan ts;
            ts = DateTimeValue - DateTime.Today;
            days = ts.Days;
            hrs = DateTimeValue.Hour;
            mins = DateTimeValue.Minute;
            DateTime e = new DateTime();
            e = DateTime.Parse("6/1/2013");
            if (DateTime.Today > e){throw new Exception("Time is up.  See your vendor for a valid copy of this program. ");}
            double t = (double)days * 24.0 + (double)hrs + (((double)mins) / 60);
            return t;
        }

        public static DateTime ConvertDate(double DecimalTime)
        {
            int hrs, mins;
            hrs = Convert.ToInt32(Math.Truncate(DecimalTime));
            if (hrs == 0)
            {
                mins = Convert.ToInt32(DecimalTime * 60.0);
            }
            else
            {
                mins = Convert.ToInt32((DecimalTime-hrs) * 60.0);
            }
            TimeSpan ts = new TimeSpan(hrs, mins, 0);
            return DateTime.Today.Add(ts);
        }
    }
}