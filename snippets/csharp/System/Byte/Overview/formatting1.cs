using System;

public class FormattingExample
{
    public static void Main()
    {
        CallToString();
        Console.WriteLine("-----");
        CallConvert();
    }

    private static void CallToString()
    {
        // <Snippet1>
        byte[] numbers = [0, 16, 104, 213];
        foreach (byte number in numbers)
        {
            // Display value using default formatting.
            Console.Write($"{number.ToString(),-3}  -->   ");
            // Display value with 3 digits and leading zeros.
            Console.Write(number.ToString("D3") + "   ");
            // Display value with hexadecimal.
            Console.Write(number.ToString("X2") + "   ");
            // Display value with four hexadecimal digits.
            Console.WriteLine(number.ToString("X4"));
        }
        // The example displays the following output:
        //       0    -->   000   00   0000
        //       16   -->   016   10   0010
        //       104  -->   104   68   0068
        //       213  -->   213   D5   00D5
        // </Snippet1>
    }

    private static void CallConvert()
    {
        // <Snippet2>
        byte[] numbers = { 0, 16, 104, 213 };
        Console.WriteLine($"{"Value"}   {"Binary",8}   {"Octal",5}   {"Hex",5}");
        foreach (byte number in numbers)
        {
            Console.WriteLine($"{number,5}   {Convert.ToString(number, 2),8}   {Convert.ToString(number, 8),5}   {Convert.ToString(number, 16),5}");
        }
        // The example displays the following output:
        //       Value     Binary   Octal     Hex
        //           0          0       0       0
        //          16      10000      20      10
        //         104    1101000     150      68
        //         213   11010101     325      d5
        // </Snippet2>
    }
}
