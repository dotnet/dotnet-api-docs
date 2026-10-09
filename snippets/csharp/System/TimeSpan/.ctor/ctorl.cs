//<Snippet1>
// Example of the TimeSpan( long ) constructor.
using System;

class TimeSpanCtorLDemo
{
    // Create a TimeSpan object and display its value.
    static void CreateTimeSpan(long ticks)
    {
        TimeSpan elapsedTime = new(ticks);

        // Format the constructor for display.
        string ctor = $"TimeSpan( {ticks} )";

        // Pad the end of a TimeSpan string with spaces if
        // it does not contain milliseconds.
        string elapsedStr = elapsedTime.ToString();
        int pointIndex = elapsedStr.IndexOf(':');

        pointIndex = elapsedStr.IndexOf('.', pointIndex);
        if (pointIndex < 0) elapsedStr += "        ";

        // Display the constructor and its value.
        Console.WriteLine($"{ctor,-33}{elapsedStr,24}");
    }

    static void Main()
    {
        Console.WriteLine(
            "This example of the TimeSpan( long ) constructor " +
            "\ngenerates the following output.\n");
        Console.WriteLine($"{"Constructor",-33}{"Value",16}");
        Console.WriteLine($"{"-----------",-33}{"-----",16}");

        CreateTimeSpan(1);
        CreateTimeSpan(999999);
        CreateTimeSpan(-1000000000000);
        CreateTimeSpan(18012202000000);
        CreateTimeSpan(999999999999999999);
        CreateTimeSpan(1000000000000000000);
    }
}

/*
This example of the TimeSpan( long ) constructor
generates the following output.

Constructor                                 Value
-----------                                 -----
TimeSpan( 1 )                            00:00:00.0000001
TimeSpan( 999999 )                       00:00:00.0999999
TimeSpan( -1000000000000 )            -1.03:46:40
TimeSpan( 18012202000000 )            20.20:20:20.2000000
TimeSpan( 999999999999999999 )   1157407.09:46:39.9999999
TimeSpan( 1000000000000000000 )  1157407.09:46:40
*/
//</Snippet1>
