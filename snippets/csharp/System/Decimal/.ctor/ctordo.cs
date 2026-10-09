//<Snippet2>
// Example of the decimal( double ) constructor.
using System;

class DecimalCtorDoDemo
{
    // Get the exception type name; remove the namespace prefix.
    public static string GetExceptionType(Exception ex)
    {
        string exceptionType = ex.GetType().ToString();
        return exceptionType.Substring(
            exceptionType.LastIndexOf('.') + 1);
    }

    // Create a decimal object and display its value.
    public static void CreateDecimal(double value, string valToStr)
    {
        // Format and display the constructor.
        Console.Write($"{string.Format("decimal( {0} )", valToStr),-34}");

        try
        {
            // Construct the decimal value.
            decimal decimalNum = new(value);

            // Display the value if it was created successfully.
            Console.WriteLine($"{decimalNum,31}");
        }
        catch (Exception ex)
        {
            // Display the exception type if an exception was thrown.
            Console.WriteLine($"{GetExceptionType(ex),31}");
        }
    }

    public static void Main()
    {
        Console.WriteLine("This example of the decimal( double ) " +
            "constructor \ngenerates the following output.\n");
        Console.WriteLine($"{"Constructor",-34}{"Value or Exception",31}");
        Console.WriteLine($"{"-----------",-34}{"------------------",31}");

        // Construct decimal objects from double values.
        CreateDecimal(1.23456789E+5, "1.23456789E+5");
        CreateDecimal(1.234567890123E+15, "1.234567890123E+15");
        CreateDecimal(1.2345678901234567E+25,
            "1.2345678901234567E+25");
        CreateDecimal(1.2345678901234567E+35,
            "1.2345678901234567E+35");
        CreateDecimal(1.23456789E-5, "1.23456789E-5");
        CreateDecimal(1.234567890123E-15, "1.234567890123E-15");
        CreateDecimal(1.2345678901234567E-25,
            "1.2345678901234567E-25");
        CreateDecimal(1.2345678901234567E-35,
            "1.2345678901234567E-35");
        CreateDecimal(1.0 / 7.0, "1.0 / 7.0");
    }
}

/*
This example of the decimal( double ) constructor
generates the following output.

Constructor                                    Value or Exception
-----------                                    ------------------
decimal( 1.23456789E+5 )                               123456.789
decimal( 1.234567890123E+15 )                    1234567890123000
decimal( 1.2345678901234567E+25 )      12345678901234600000000000
decimal( 1.2345678901234567E+35 )               OverflowException
decimal( 1.23456789E-5 )                          0.0000123456789
decimal( 1.234567890123E-15 )       0.000000000000001234567890123
decimal( 1.2345678901234567E-25 )  0.0000000000000000000000001235
decimal( 1.2345678901234567E-35 )                               0
decimal( 1.0 / 7.0 )                            0.142857142857143
*/
//</Snippet2>
