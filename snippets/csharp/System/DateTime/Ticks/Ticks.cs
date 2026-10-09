using System;

public class Class1
{
    public static void Main()
    {
        // <Snippet1>
        DateTime centuryBegin = new(2001, 1, 1);
        DateTime currentDate = DateTime.Now;

        long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
        TimeSpan elapsedSpan = new(elapsedTicks);

        Console.WriteLine($"Elapsed from the beginning of the century to {currentDate:f}:");
        Console.WriteLine($"   {elapsedTicks * 100:N0} nanoseconds");
        Console.WriteLine($"   {elapsedTicks:N0} ticks");
        Console.WriteLine($"   {elapsedSpan.TotalSeconds:N2} seconds");
        Console.WriteLine($"   {elapsedSpan.TotalMinutes:N2} minutes");
        Console.WriteLine($"   {elapsedSpan.Days:N0} days, {elapsedSpan.Hours} hours, {elapsedSpan.Minutes} minutes, {elapsedSpan.Seconds} seconds");

        // This example displays an output similar to the following:
        //
        // Elapsed from the beginning of the century to Thursday, 14 November 2019 18:21:
        //    595,448,498,171,000,000 nanoseconds
        //    5,954,484,981,710,000 ticks
        //    595,448,498.17 seconds
        //    9,924,141.64 minutes
        //    6,891 days, 18 hours, 21 minutes, 38 seconds
        // </Snippet1>
    }
}
