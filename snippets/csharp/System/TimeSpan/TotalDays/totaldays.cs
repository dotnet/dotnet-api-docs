using System;

public class Example
{
    public static void Main()
    {
        // <Snippet1>
        // Define an interval of 3 days, 16+ hours.
        TimeSpan interval = new(3, 16, 42, 45, 750);
        Console.WriteLine($"Value of TimeSpan: {interval}");

        Console.WriteLine($"{interval.TotalDays:N5} days, as follows:");
        Console.WriteLine($"   Days:         {interval.Days,3}");
        Console.WriteLine($"   Hours:        {interval.Hours,3}");
        Console.WriteLine($"   Minutes:      {interval.Minutes,3}");
        Console.WriteLine($"   Seconds:      {interval.Seconds,3}");
        Console.WriteLine($"   Milliseconds: {interval.Milliseconds,3}");

        // The example displays the following output:
        //       Value of TimeSpan: 3.16:42:45.7500000
        //       3.69636 days, as follows:
        //          Days:           3
        //          Hours:         16
        //          Minutes:       42
        //          Seconds:       45
        //          Milliseconds: 750
        // </Snippet1>
    }
}
