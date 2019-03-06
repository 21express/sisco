using System;
using System.Globalization;

namespace Devenlab.Common.Helpers
{
	public static class CultureHelper
	{
		public static CultureInfo SetUpCultureInfo()
		{
			var cultureInfo = new CultureInfo("id-ID", true);
			var numberFormatInfo = new NumberFormatInfo
			{
			    CurrencySymbol = "Rp ",
			    CurrencyDecimalDigits = 0,
			    CurrencyGroupSeparator = ".",
			    CurrencyDecimalSeparator = ",",
			    NumberDecimalDigits = 0,
			    NumberDecimalSeparator = ",",
			    NumberGroupSeparator = "."
			};
		    cultureInfo.NumberFormat = numberFormatInfo;

			var dateInfo = new DateTimeFormatInfo
			{
			    DayNames = new[] {"Minggu", "Senin", "Selasa", "Rabu", "Kamis", "Jum'at", "Sabtu"},
			    AbbreviatedDayNames = new[] {"Minggu", "Senin", "Selasa", "Rabu", "Kamis", "Jum'at", "Sabtu"},
			    ShortestDayNames = new[] {"Mi", "Sn", "Sl", "Rb", "Km", "Jm", "Sb"},
			    MonthNames = new[]
			    {
			        "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus",
			        "September", "Oktober", "November", "Desember", ""
			    },
			    AbbreviatedMonthNames = new[]
			    {
			        "Jan", "Feb", "Mar", "Apr", "Mei", "Jun", "Jul", "Ags",
			        "Sep", "Okt", "Nov", "Des", ""
			    },
			    AbbreviatedMonthGenitiveNames = new[]
			    {
			        "Januari", "Februari", "Maret", "April", "Mei", "Juni",
			        "Juli", "Agustus",
			        "September", "Oktober", "November", "Desember", ""
			    }
			};
		    cultureInfo.DateTimeFormat = dateInfo;
			return cultureInfo;
		}

	    public static string GetDateIdFormat(DateTime date)
	    {
	        var month = GetIdMonthName(date.Month);
	        return date.Day + " " + month + " " + date.Year;
	    }

	    private static string GetIdMonthName(int month)
	    {
	        switch (month)
	        {
                case 1:
	                return "Januari";
                case 2:
                    return "Februari";
                case 3:
                    return "Maret";
                case 4 :
                    return "April";
                case 5 :
                    return "Mei";
                case 6 :
                    return "Juni";
                case 7:
                    return "Juli";
                case 8 :
                    return "Agustus";
                case 9:
                    return "September";
                case 10:
                    return "Oktober";
                case 11 :
                    return "November";
                case 12:
                    return "Desember";
                default:
	                return "";
	        }
	    }
	}
}
