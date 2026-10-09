using System;

public class Example
{
    public static void Main()
    {
        // <Snippet1>
        // Define an interval of 1 day, 15+ hours.
        TimeSpan interval = new(1, 15, 42, 45, 750);
        Console.WriteLine($"Value of TimeSpan: {interval}");

        Console.WriteLine($"{interval.TotalHours:N5} hours, as follows:");
        Console.WriteLine($"   Hours:        {interval.Days * 24 + interval.Hours,3}");
        Console.WriteLine($"   Minutes:      {interval.Minutes,3}");
        Console.WriteLine($"   Seconds:      {interval.Seconds,3}");
        Console.WriteLine($"   Milliseconds: {interval.Milliseconds,3}");

        // The example displays the following output:
        //       Value of TimeSpan: 1.15:42:45.7500000
        //       39.71271 hours, as follows:
        //          Hours:         39
        //          Minutes:       42
        //          Seconds:       45
        //          Milliseconds: 750
        // </Snippet1>
    }
}
