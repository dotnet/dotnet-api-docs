using System;

public class Example
{
    public static void Main()
    {
        ConvertInt32();
        Console.WriteLine("-----");
        ConvertInt64();
    }

    private static void ConvertInt32()
    {
        // Create a NumberFormatInfo object and set several of its
        // properties that control default integer formatting.
        System.Globalization.NumberFormatInfo provider = new()
        {
            NegativeSign = "minus "
        };

        int[] values = { -20, 0, 100 };

        foreach (int value in values)
            Console.WriteLine($"{value,-5}  -->  {Convert.ToString(value, provider),8}");
        // The example displays the following output:
        //       -20    -->  minus 20
        //       0      -->         0
        //       100    -->       100
    }

    private static void ConvertInt64()
    {
        // <Snippet28>
        // Create a NumberFormatInfo object and set several of its
        // properties that control default integer formatting.
        System.Globalization.NumberFormatInfo provider = new()
        {
            NegativeSign = "minus "
        };

        long[] values = { -200, 0, 1000 };

        foreach (long value in values)
            Console.WriteLine($"{value,-6}  -->  {Convert.ToString(value, provider),10}");
        // The example displays the following output:
        //       -200    -->   minus 200
        //       0       -->           0
        //       1000    -->        1000
        // </Snippet28>
    }
}
