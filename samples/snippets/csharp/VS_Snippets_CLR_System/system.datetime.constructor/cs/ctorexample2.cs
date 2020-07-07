﻿// <Snippet2>
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

public class Example
{
   public static void Main()
   {
      Console.WriteLine("Using the Persian Calendar:");
      PersianCalendar persian = new PersianCalendar();
      DateTime date1 = new DateTime(1389, 5, 27, persian);
      Console.WriteLine(date1.ToString());
      Console.WriteLine("{0}/{1}/{2}\n", persian.GetMonth(date1),
                                       persian.GetDayOfMonth(date1),
                                       persian.GetYear(date1));

      Console.WriteLine("Using the Hijri Calendar:");
      // Get current culture so it can later be restored.
      CultureInfo dftCulture = Thread.CurrentThread.CurrentCulture;

      // Define Hijri calendar.
      HijriCalendar hijri = new HijriCalendar();
      // Make ar-SY the current culture and Hijri the current calendar.
      Thread.CurrentThread.CurrentCulture = new CultureInfo("ar-SY");
      CultureInfo current = CultureInfo.CurrentCulture;
      current.DateTimeFormat.Calendar = hijri;
      string dFormat = current.DateTimeFormat.ShortDatePattern;
      // Ensure year is displayed as four digits.
      dFormat = Regex.Replace(dFormat, "/yy$", "/yyyy");
      current.DateTimeFormat.ShortDatePattern = dFormat;
      DateTime date2 = new DateTime(1431, 9, 9, hijri);
      Console.WriteLine("{0} culture using the {1} calendar: {2:d}", current,
                        GetCalendarName(hijri), date2);

      // Restore previous culture.
      Thread.CurrentThread.CurrentCulture = dftCulture;
      Console.WriteLine("{0} culture using the {1} calendar: {2:d}",
                        CultureInfo.CurrentCulture,
                        GetCalendarName(CultureInfo.CurrentCulture.Calendar),
                        date2);
   }

   private static string GetCalendarName(Calendar cal)
   {
      return Regex.Match(cal.ToString(), "\\.(\\w+)Calendar").Groups[1].Value;
   }
}
// The example displays the following output:
//       Using the Persian Calendar:
//       8/18/2010 12:00:00 AM
//       5/27/1389
//
//       Using the Hijri Calendar:
//       ar-SY culture using the Hijri calendar: 09/09/1431
//       en-US culture using the Gregorian calendar: 8/18/2010
// </Snippet2>
