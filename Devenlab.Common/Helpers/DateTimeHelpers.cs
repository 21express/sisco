using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace Devenlab.Common.Helpers
{
    public static class DateTimeHelpers
    {
        public static string GetMonthName(DateTime value)
        {
            switch (value.Month)
            {
                case 1:
                    return "Januari";
                case 2:
                    return "Februari";
                case 3:
                    return "Maret";
                case 4:
                    return "April";
                case 5:
                    return "Mei";
                case 6:
                    return "Juni";
                case 7:
                    return "Juli";
                case 8:
                    return "Agustus";
                case 9:
                    return "Sepember";
                case 10:
                    return "Oktober";
                case 11:
                    return "November";
                case 12:
                    return "Desember";
                default:
                    return "";
            }
        }

        public static string GetMonthName(int value)
        {
            switch (value)
            {
                case 1:
                    return "Januari";
                case 2:
                    return "Februari";
                case 3:
                    return "Maret";
                case 4:
                    return "April";
                case 5:
                    return "Mei";
                case 6:
                    return "Juni";
                case 7:
                    return "Juli";
                case 8:
                    return "Agustus";
                case 9:
                    return "Sepember";
                case 10:
                    return "Oktober";
                case 11:
                    return "November";
                case 12:
                    return "Desember";
                default:
                    return "";
            }
        }

        public static string GetMonthShortName(int value)
        {
            switch (value)
            {
                case 1:
                    return "Jan";
                case 2:
                    return "Feb";
                case 3:
                    return "Mar";
                case 4:
                    return "Apr";
                case 5:
                    return "Mei";
                case 6:
                    return "Jun";
                case 7:
                    return "Jul";
                case 8:
                    return "Ags";
                case 9:
                    return "Sep";
                case 10:
                    return "Okt";
                case 11:
                    return "Nov";
                case 12:
                    return "Des";
                default:
                    return "";
            }
        }

        public static DateTime GetFirstDayOfMonth(DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }

        public static DateTime GetLastDayOfMonth(DateTime value)
        {
            var dateTime = new DateTime(value.Year, value.Month, 1).AddMonths(1);
            return dateTime.AddDays(-1);
        }

        public static string PeriodToString(int period)
        {
            var year = Convert.ToInt32(Convert.ToString(period).Substring(0, 4));
            var month = Convert.ToInt32(Convert.ToString(period).Substring(4, 2));
            return GetMonthName(month) + " " + year;
        }

        public static int GetYearFromPeriod(int period)
        {
            return Convert.ToInt32(Convert.ToString(period).Substring(0, 4));
        }

        public static int GetMonthFromPeriod(int period)
        {
            return Convert.ToInt32(Convert.ToString(period).Substring(4, 2));
        }

        public static DateTime GetDateFormPeriod(int period, int day)
        {
            return new DateTime(GetYearFromPeriod(period), GetMonthFromPeriod(period), day);
        }

        public static int GetLastPeriod(int period)
        {
            var year = GetYearFromPeriod(period);
            var month = GetMonthFromPeriod(period);
            if (month == 1)
            {
                month = 12;
                year = year - 1;
            }
            else
            {
                month = month - 1;
            }
            var p = year + month.ToString("D2");
            return Convert.ToInt32(p);
        }

        public static int GetLastPeriod(DateTime dateTime)
        {
            return GetLastPeriod(Convert.ToInt32(dateTime.Year + dateTime.Month.ToString("D2")));
        }

        public static int GetPeriod(DateTime dateTime)
        {
            return Convert.ToInt32(dateTime.Year + dateTime.Month.ToString("D2"));
        }

    }
}
