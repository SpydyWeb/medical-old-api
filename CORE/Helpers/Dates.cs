using System;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace CORE.Helpers
{
	public class Dates
	{
		private HttpContext cur;

		private const int startGreg = 1900;

		private const int endGreg = 2100;

		private string[] allFormats = new string[18]
		{
			"yyyy/MM/dd", "yyyy/M/d", "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "yyyy-MM-dd", "yyyy-M-d", "dd-MM-yyyy", "d-M-yyyy",
			"dd-M-yyyy", "d-MM-yyyy", "yyyy MM dd", "yyyy M d", "dd MM yyyy", "d M yyyy", "dd M yyyy", "d MM yyyy"
		};

		private CultureInfo arCul;

		private CultureInfo enCul;

		private HijriCalendar h;

		private GregorianCalendar g;

		public Dates()
		{
			arCul = new CultureInfo("ar-SA");
			enCul = new CultureInfo("en-US");
			h = new HijriCalendar();
			g = new GregorianCalendar(GregorianCalendarTypes.USEnglish);
			arCul.DateTimeFormat.Calendar = h;
		}

		public bool IsHijri(string hijri)
		{
			if (hijri.Length <= 0)
			{
				return false;
			}
			try
			{
				DateTime tempDate = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
				if (tempDate.Year >= 1900 && tempDate.Year <= 2100)
				{
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool IsGreg(string greg)
		{
			if (greg.Length <= 0)
			{
				return false;
			}
			try
			{
				DateTime tempDate = DateTime.ParseExact(greg, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
				if (tempDate.Year >= 1900 && tempDate.Year <= 2100)
				{
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string FormatHijri(string date, string format)
		{
			if (date.Length <= 0)
			{
				return "";
			}
			try
			{
				return DateTime.ParseExact(date, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces).ToString(format, arCul.DateTimeFormat);
			}
			catch (Exception)
			{
				return "";
			}
		}

		public string FormatGreg(string date, string format)
		{
			if (date.Length <= 0)
			{
				return "";
			}
			try
			{
				return DateTime.ParseExact(date, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces).ToString(format, enCul.DateTimeFormat);
			}
			catch (Exception)
			{
				return "";
			}
		}

		public string GDateNow()
		{
			try
			{
				return DateTime.Now.ToString("yyyy/MM/dd", enCul.DateTimeFormat);
			}
			catch (Exception)
			{
				return "";
			}
		}

		public string GDateNow(string format)
		{
			try
			{
				return DateTime.Now.ToString(format, enCul.DateTimeFormat);
			}
			catch (Exception)
			{
				return "";
			}
		}

		public string HDateNow()
		{
			try
			{
				return DateTime.Now.ToString("yyyy/MM/dd", arCul.DateTimeFormat);
			}
			catch (Exception)
			{
				return "";
			}
		}

		public string HDateNow(string format)
		{
			try
			{
				return DateTime.Now.ToString(format, arCul.DateTimeFormat);
			}
			catch (Exception)
			{
				return "";
			}
		}

		public DateTime? HijriToGreg(string hijri)
		{
			if (hijri.Length <= 0)
			{
				return null;
			}
			try
			{
				return DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public string HijriToGreg(string hijri, string format)
		{
			if (hijri.Length <= 0)
			{
				return "";
			}
			try
			{
				return DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces).ToString(format, enCul.DateTimeFormat);
			}
			catch (Exception)
			{
				return "";
			}
		}

		public string GregToHijri(string greg)
		{
			if (greg.Length <= 0)
			{
				return "";
			}
			try
			{
				return DateTime.ParseExact(greg, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces).ToString("MM/dd/yyyy", arCul.DateTimeFormat);
			}
			catch (Exception)
			{
				return "";
			}
		}

		public string ConverToHijri(string gregorian)
		{
			DateTime dateTime = default(DateTime);
			try
			{
				try
				{
					dateTime = Convert.ToDateTime(gregorian);
				}
				catch (Exception)
				{
					try
					{
						dateTime = DateTime.ParseExact(gregorian, "dd-MM-yyyy", CultureInfo.InvariantCulture);
					}
					catch (Exception)
					{
						dateTime = DateTime.ParseExact("10/01/1985", "dd/MM/yyyy", CultureInfo.InvariantCulture);
					}
				}
			}
			catch (Exception)
			{
				try
				{
					dateTime = DateTime.ParseExact(gregorian, "dd-MM-yyyy", CultureInfo.InvariantCulture);
				}
				catch (Exception)
				{
					dateTime = DateTime.ParseExact("10/01/1985", "dd/MM/yyyy", CultureInfo.InvariantCulture);
				}
			}
			int d = int.Parse(dateTime.Day.ToString());
			int j = dateTime.Month + 1;
			int y = int.Parse(dateTime.Year.ToString());
			double jd = ((y <= 1582 && (y != 1582 || j <= 10) && (y != 1582 || j != 10 || d <= 14)) ? ((double)(367 * y) - getInt(7.0 * ((double)(y + 5001) + getInt((j - 9) / 7)) / 4.0) + getInt(275 * j / 9) + (double)d + 1729777.0) : (getInt(1461.0 * ((double)(y + 4800) + getInt((j - 14) / 12)) / 4.0) + getInt(367.0 * ((double)(j - 2) - 12.0 * getInt((j - 14) / 12)) / 12.0) - getInt(3.0 * getInt(((double)(y + 4900) + getInt((j - 14) / 12)) / 100.0) / 4.0) + (double)d - 32075.0));
			if (jd < 1948440.0)
			{
				return "";
			}
			if (jd > 2621734.0)
			{
				return "";
			}
			int theDay = (int)(jd % 7.0);
			double L = jd - 1948440.0 + 10632.0;
			double k = getInt((L - 1.0) / 10631.0);
			L = L - 10631.0 * k + 354.0;
			double i = getInt((10985.0 - L) / 5316.0) * getInt(50.0 * L / 17719.0) + getInt(L / 5670.0) * getInt(43.0 * L / 15238.0);
			L = L - getInt((30.0 - i) / 15.0) * getInt(17719.0 * i / 50.0) - getInt(i / 16.0) * getInt(15238.0 * i / 43.0) + 29.0;
			j = (int)getInt(24.0 * L / 709.0);
			d = (int)(L - getInt(709 * j / 24));
			return j - 1 + "-" + (int)(30.0 * k + i - 30.0);
		}

		private double getInt(double fNumber)
		{
			if (fNumber < -1E-07)
			{
				return Math.Ceiling(fNumber - 1E-07);
			}
			return Math.Floor(fNumber + 1E-07);
		}

		public string GregToHijri(string greg, string format)
		{
			if (greg.Length <= 0)
			{
				return "";
			}
			try
			{
				return DateTime.ParseExact(greg, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces).ToString(format, arCul.DateTimeFormat);
			}
			catch (Exception)
			{
				return "";
			}
		}

		public string GTimeStamp()
		{
			return GDateNow("yyyyMMddHHmmss");
		}

		public string HTimeStamp()
		{
			return HDateNow("yyyyMMddHHmmss");
		}

		public int Compare(string d1, string d2)
		{
			try
			{
				DateTime date1 = DateTime.ParseExact(d1, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
				DateTime date2 = DateTime.ParseExact(d2, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
				return DateTime.Compare(date1, date2);
			}
			catch (Exception)
			{
				return -1;
			}
		}
	}
}
