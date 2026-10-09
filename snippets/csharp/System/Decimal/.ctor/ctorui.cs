//<Snippet2>
// Example of the decimal( uint ) constructor.
using System;

class DecimalCtorUIDemo
{
    // Create a decimal object and display its value.
    public static void CreateDecimal(uint value, string valToStr)
    {
        decimal decimalNum = new(value);

        // Format the constructor for display.
        string ctor = $"decimal( {valToStr} )";

        // Display the constructor and its value.
        Console.WriteLine($"{ctor,-33}{decimalNum,16}");
    }

    public static void Main()
    {
        Console.WriteLine("This example of the decimal( uint ) " +
            "constructor \ngenerates the following output.\n");
        Console.WriteLine($"{"Constructor",-33}{"Value",16}");
        Console.WriteLine($"{"-----------",-33}{"-----",16}");

        // Construct decimal objects from uint values.
        CreateDecimal(uint.MinValue, "uint.MinValue");
        CreateDecimal(uint.MaxValue, "uint.MaxValue");
        CreateDecimal((uint)int.MaxValue, "(uint)int.MaxValue");
        CreateDecimal(999999999U, "999999999U");
        CreateDecimal(0x40000000U, "0x40000000U");
        CreateDecimal(0xC0000000, "0xC0000000");
    }
}

/*
This example of the decimal( uint ) constructor
generates the following output.

Constructor                                 Value
-----------                                 -----
decimal( uint.MinValue )                        0
decimal( uint.MaxValue )               4294967295
decimal( (uint)int.MaxValue )          2147483647
decimal( 999999999U )                   999999999
decimal( 0x40000000U )                 1073741824
decimal( 0xC0000000 )                  3221225472
*/
//</Snippet2>
