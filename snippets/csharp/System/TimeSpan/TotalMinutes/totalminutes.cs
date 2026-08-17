using System;

public class Example
{
    public static void Main()
    {
        // <Snippet1>
        // Define an interval of 1 day, 15+ hours.
        TimeSpan interval = new(1, 15, 42, 45, 750);
        Console.WriteLine($"Value of TimeSpan: {interval}");

        Console.WriteLine($"{interval.TotalMinutes:N5} minutes, as follows:");
        Console.WriteLine($"   Minutes:      {interval.Days * 24 * 60 +
                                                    interval.Hours * 60 +
                                                    interval.Minutes,5}");
        Console.WriteLine($"   Seconds:      {interval.Seconds,5}");
        Console.WriteLine($"   Milliseconds: {interval.Milliseconds,5}");

        // The example displays the following output:
        //       Value of TimeSpan: 1.15:42:45.7500000
        //       2,382.76250 minutes, as follows:
        //          Minutes:       2382
        //          Seconds:         45
        //          Milliseconds:   750
        // </Snippet1>
    }
}
