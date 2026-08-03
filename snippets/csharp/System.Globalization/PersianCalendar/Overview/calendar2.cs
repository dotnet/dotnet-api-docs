// <Snippet3>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        PersianCalendar pc = new();
        DateTime thisDate = DateTime.Now;

        // Display the current date using the Gregorian and Persian calendars.
        Console.WriteLine("Today in the Gregorian Calendar:  {0:dddd}, {0}", thisDate);
        Console.WriteLine("Today in the Persian Calendar:    {0}, {1}/{2}/{3} {4}:{5}:{6}\n",
                      pc.GetDayOfWeek(thisDate),
                      pc.GetMonth(thisDate),
                      pc.GetDayOfMonth(thisDate),
                      pc.GetYear(thisDate),
                      pc.GetHour(thisDate),
                      pc.GetMinute(thisDate),
                      pc.GetSecond(thisDate));

        // Create a date using the Gregorian calendar.
        thisDate = new DateTime(2013, 5, 28, 10, 35, 0);
        Console.WriteLine("Gregorian Calendar:  {0:D} ", thisDate);
        Console.WriteLine("Persian Calendar:    {0}, {1}/{2}/{3} {4}:{5}:{6}\n",
                          pc.GetDayOfWeek(thisDate),
                          pc.GetMonth(thisDate),
                          pc.GetDayOfMonth(thisDate),
                          pc.GetYear(thisDate),
                          pc.GetHour(thisDate),
                          pc.GetMinute(thisDate),
                          pc.GetSecond(thisDate));

        // Create a date using the Persian calendar.
        thisDate = pc.ToDateTime(1395, 4, 22, 12, 30, 0, 0);
        Console.WriteLine("Gregorian Calendar:  {0:D} ", thisDate);
        Console.WriteLine("Persian Calendar:    {0}, {1}/{2}/{3} {4}:{5}:{6}\n",
                      pc.GetDayOfWeek(thisDate),
                      pc.GetMonth(thisDate),
                      pc.GetDayOfMonth(thisDate),
                      pc.GetYear(thisDate),
                      pc.GetHour(thisDate),
                      pc.GetMinute(thisDate),
                      pc.GetSecond(thisDate));

        // Show the Persian Calendar date range.
        Console.WriteLine("Minimum Persian Calendar date (Gregorian Calendar):  {0:D} ",
                          pc.MinSupportedDateTime);
        Console.WriteLine("Minimum Persian Calendar date (Persian Calendar):  " +
                          "{0}, {1}/{2}/{3} {4}:{5}:{6}\n",
                          pc.GetDayOfWeek(pc.MinSupportedDateTime),
                          pc.GetMonth(pc.MinSupportedDateTime),
                          pc.GetDayOfMonth(pc.MinSupportedDateTime),
                          pc.GetYear(pc.MinSupportedDateTime),
                          pc.GetHour(pc.MinSupportedDateTime),
                          pc.GetMinute(pc.MinSupportedDateTime),
                          pc.GetSecond(pc.MinSupportedDateTime));

        Console.WriteLine("Maximum Persian Calendar date (Gregorian Calendar):  {0:D} ",
                          pc.MaxSupportedDateTime);
        Console.WriteLine("Maximum Persian Calendar date (Persian Calendar):  " +
                          "{0}, {1}/{2}/{3} {4}:{5}:{6}\n",
                          pc.GetDayOfWeek(pc.MaxSupportedDateTime),
                          pc.GetMonth(pc.MaxSupportedDateTime),
                          pc.GetDayOfMonth(pc.MaxSupportedDateTime),
                          pc.GetYear(pc.MaxSupportedDateTime),
                          pc.GetHour(pc.MinSupportedDateTime),
                          pc.GetMinute(pc.MaxSupportedDateTime),
                          pc.GetSecond(pc.MaxSupportedDateTime));
    }
}

// The example displays output similar to the following:

// Today in the Gregorian Calendar:  Thursday, 7/30/2026 4:19:25 PM
// Today in the Persian Calendar:    Thursday, 5/8/1405 16:19:25
//
// Gregorian Calendar:  Tuesday, May 28, 2013
// Persian Calendar:    Tuesday, 3/7/1392 10:35:0
//
// Gregorian Calendar:  Tuesday, July 12, 2016
// Persian Calendar:    Tuesday, 4/22/1395 12:30:0
//
// Minimum Persian Calendar date (Gregorian Calendar):  Friday, March 22, 0622
// Minimum Persian Calendar date (Persian Calendar):  Friday, 1/1/1 0:0:0
//
// Maximum Persian Calendar date (Gregorian Calendar):  Friday, December 31, 9999
// Maximum Persian Calendar date (Persian Calendar):  Friday, 10/13/9378 0:59:59

// </Snippet3>
