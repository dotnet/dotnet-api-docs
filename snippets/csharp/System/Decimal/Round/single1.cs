using System;

public class SingleExample
{
    public static void Example()
    {
        // <Snippet1>
        float value = 16.325f;
        Console.WriteLine($"Widening Conversion of {value:R} (type {value.GetType().Name}) to {(double)value:R} (type {((double)(value)).GetType().Name}): ");
        Console.WriteLine(Math.Round(value, 2));
        Console.WriteLine(Math.Round(value, 2, MidpointRounding.AwayFromZero));
        Console.WriteLine();

        decimal decValue = (decimal)value;
        Console.WriteLine($"Cast of {value:R} (type {value.GetType().Name}) to {decValue} (type {decValue.GetType().Name}): ");
        Console.WriteLine(Math.Round(decValue, 2));
        Console.WriteLine(Math.Round(decValue, 2, MidpointRounding.AwayFromZero));

        // The example displays the following output:
        //    Widening Conversion of 16.325 (type Single) to 16.325000762939453 (type Double):
        //    16.33
        //    16.33
        //
        //    Cast of 16.325 (type Single) to 16.325 (type Decimal):
        //    16.32
        //    16.33
        // </Snippet1>
    }
}
