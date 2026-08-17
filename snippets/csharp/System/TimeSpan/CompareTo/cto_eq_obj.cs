//<Snippet1>
// Example of the TimeSpan.CompareTo( Object ) and
// TimeSpan.Equals( Object ) methods.
using System;

class TSCompToEqualsObjDemo
{
    // Compare the TimeSpan to the Object parameters,
    // and display the Object parameters with the results.
    static void CompTimeSpanToObject(TimeSpan Left, object Right,
        string RightText)
    {
        Console.WriteLine($"{"Object: " + RightText,-33}{Right}");
        Console.WriteLine($"{"Left.Equals( Object )",-33}{Left.Equals(Right)}");
        Console.Write($"{"Left.CompareTo( Object )",-33}");

        // Catch the exception if CompareTo( ) throws one.
        try
        {
            Console.WriteLine($"{Left.CompareTo(Right)}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}\n");
        }
    }

    static void Main()
    {
        TimeSpan Left = new(0, 5, 0);

        Console.WriteLine(
            "This example of the TimeSpan.Equals( Object ) " +
            "and \nTimeSpan.CompareTo( Object ) methods generates " +
            "the \nfollowing output by creating several different " +
            "TimeSpan \nobjects and comparing them with a " +
            "5-minute TimeSpan.\n");
        Console.WriteLine($"{"Left: TimeSpan( 0, 5, 0 )",-33}{Left}\n");

        // Create objects to compare with a 5-minute TimeSpan.
        CompTimeSpanToObject(Left, new TimeSpan(0, 0, 300),
            "TimeSpan( 0, 0, 300 )");
        CompTimeSpanToObject(Left, new TimeSpan(0, 5, 1),
            "TimeSpan( 0, 5, 1 )");
        CompTimeSpanToObject(Left, new TimeSpan(0, 5, -1),
            "TimeSpan( 0, 5, -1 )");
        CompTimeSpanToObject(Left, new TimeSpan(3000000000),
            "TimeSpan( 3000000000 )");
        CompTimeSpanToObject(Left, 3000000000L,
            "long 3000000000L");
        CompTimeSpanToObject(Left, "00:05:00",
            "string \"00:05:00\"");
    }
}

/*
This example of the TimeSpan.Equals( Object ) and
TimeSpan.CompareTo( Object ) methods generates the
following output by creating several different TimeSpan
objects and comparing them with a 5-minute TimeSpan.

Left: TimeSpan( 0, 5, 0 )        00:05:00

Object: TimeSpan( 0, 0, 300 )    00:05:00
Left.Equals( Object )            True
Left.CompareTo( Object )         0

Object: TimeSpan( 0, 5, 1 )      00:05:01
Left.Equals( Object )            False
Left.CompareTo( Object )         -1

Object: TimeSpan( 0, 5, -1 )     00:04:59
Left.Equals( Object )            False
Left.CompareTo( Object )         1

Object: TimeSpan( 3000000000 )   00:05:00
Left.Equals( Object )            True
Left.CompareTo( Object )         0

Object: long 3000000000L         3000000000
Left.Equals( Object )            False
Left.CompareTo( Object )         Error: Object must be of type TimeSpan.

Object: string "00:05:00"        00:05:00
Left.Equals( Object )            False
Left.CompareTo( Object )         Error: Object must be of type TimeSpan.
*/
//</Snippet1>
