﻿// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo culture = CultureInfo.CreateSpecificCulture("it-IT");
      DateTime date1 = new DateTime(2011, 02, 01, 7, 30, 45, 0);
      DateTime date2;
      int total = 0;
      int noRoundTrip = 0;

      foreach (var fmt in culture.DateTimeFormat.GetAllDateTimePatterns()) {
         total += 1;
         if (! DateTime.TryParse(date1.ToString(fmt), out date2)) {
            noRoundTrip++;
            Console.WriteLine("Unable to parse {0:" + fmt + "} (format '{1}')",
                              date1, fmt);
         }
      }
      Console.WriteLine("\nUnable to round-trip {0} of {1} format strings.",
                        noRoundTrip, total);
   }
}
// The example displays the following output:
//    Unable to parse Tuesday 1 February 2011 7.30 (format 'dddd d MMMM yyyy H.mm')
//    Unable to parse Tuesday 1 February 2011 07.30 (format 'dddd d MMMM yyyy HH.mm')
//    Unable to parse 1-Feb-11 7.30 (format 'd-MMM-yy H.mm')
//    Unable to parse 1-Feb-11 07.30 (format 'd-MMM-yy HH.mm')
//    Unable to parse 1 February 2011 7.30 (format 'd MMMM yyyy H.mm')
//    Unable to parse 1 February 2011 07.30 (format 'd MMMM yyyy HH.mm')
//    Unable to parse Tuesday 1 February 2011 7.30.45 (format 'dddd d MMMM yyyy H.mm.ss')
//    Unable to parse Tuesday 1 February 2011 07.30.45 (format 'dddd d MMMM yyyy HH.mm.ss')
//    Unable to parse 1-Feb-11 7.30.45 (format 'd-MMM-yy H.mm.ss')
//    Unable to parse 1-Feb-11 07.30.45 (format 'd-MMM-yy HH.mm.ss')
//    Unable to parse 1 February 2011 7.30.45 (format 'd MMMM yyyy H.mm.ss')
//    Unable to parse 1 February 2011 07.30.45 (format 'd MMMM yyyy HH.mm.ss')
//    Unable to parse 01/02/2011 7.30 (format 'dd/MM/yyyy H.mm')
//    Unable to parse 01/02/2011 07.30 (format 'dd/MM/yyyy HH.mm')
//    Unable to parse 01/Feb/2011 7.30 (format 'dd/MMM/yyyy H.mm')
//    Unable to parse 01/Feb/2011 07.30 (format 'dd/MMM/yyyy HH.mm')
//    Unable to parse 01/02/11 7.30 (format 'dd/MM/yy H.mm')
//    Unable to parse 01/02/11 07.30 (format 'dd/MM/yy HH.mm')
//    Unable to parse 01.2.11 7.30 (format 'dd.M.yy H.mm')
//    Unable to parse 01.2.11 07.30 (format 'dd.M.yy HH.mm')
//    Unable to parse 1/2/11 7.30 (format 'd/M/yy H.mm')
//    Unable to parse 1/2/11 07.30 (format 'd/M/yy HH.mm')
//    Unable to parse 2011-02-01 7.30 (format 'yyyy-MM-dd H.mm')
//    Unable to parse 2011-02-01 07.30 (format 'yyyy-MM-dd HH.mm')
//    Unable to parse 01/02/2011 7.30.45 (format 'dd/MM/yyyy H.mm.ss')
//    Unable to parse 01/02/2011 07.30.45 (format 'dd/MM/yyyy HH.mm.ss')
//    Unable to parse 01/Feb/2011 7.30.45 (format 'dd/MMM/yyyy H.mm.ss')
//    Unable to parse 01/Feb/2011 07.30.45 (format 'dd/MMM/yyyy HH.mm.ss')
//    Unable to parse 01/02/11 7.30.45 (format 'dd/MM/yy H.mm.ss')
//    Unable to parse 01/02/11 07.30.45 (format 'dd/MM/yy HH.mm.ss')
//    Unable to parse 01.2.11 7.30.45 (format 'dd.M.yy H.mm.ss')
//    Unable to parse 01.2.11 07.30.45 (format 'dd.M.yy HH.mm.ss')
//    Unable to parse 1/2/11 7.30.45 (format 'd/M/yy H.mm.ss')
//    Unable to parse 1/2/11 07.30.45 (format 'd/M/yy HH.mm.ss')
//    Unable to parse 2011-02-01 7.30.45 (format 'yyyy-MM-dd H.mm.ss')
//    Unable to parse 2011-02-01 07.30.45 (format 'yyyy-MM-dd HH.mm.ss')
//    Unable to parse Tuesday 1 February 2011 7.30.45 (format 'dddd d MMMM yyyy H.mm.ss')
//    Unable to parse Tuesday 1 February 2011 07.30.45 (format 'dddd d MMMM yyyy HH.mm.ss')
//    Unable to parse 1-Feb-11 7.30.45 (format 'd-MMM-yy H.mm.ss')
//    Unable to parse 1-Feb-11 07.30.45 (format 'd-MMM-yy HH.mm.ss')
//    Unable to parse 1 February 2011 7.30.45 (format 'd MMMM yyyy H.mm.ss')
//    Unable to parse 1 February 2011 07.30.45 (format 'd MMMM yyyy HH.mm.ss')
//
//    Unable to round-trip 42 of 98 format strings.
// </Snippet1>