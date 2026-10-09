using System;

public class Example1
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
        int[] numbers = { -1403, 0, 169, 1483104 };
        foreach (int number in numbers)
        {
            // Display value using default formatting.
            Console.Write($"{number.ToString(),-8}  -->   ");
            // Display value with 3 digits and leading zeros.
            Console.Write($"{number,11:D3}");
            // Display value with 1 decimal digit.
            Console.Write($"{number,13:N1}");
            // Display value as hexadecimal.
            Console.Write($"{number,12:X2}");
            // Display value with eight hexadecimal digits.
            Console.WriteLine($"{number,14:X8}");
        }
        // The example displays the following output:
        //    -1403     -->         -1403     -1,403.0    FFFFFA85      FFFFFA85
        //    0         -->           000          0.0          00      00000000
        //    169       -->           169        169.0          A9      000000A9
        //    1483104   -->       1483104  1,483,104.0      16A160      0016A160
        // </Snippet1>
    }

    private static void CallConvert()
    {
        // <Snippet2>
        int[] numbers = { -146, 11043, 2781913 };
        Console.WriteLine($"{"Value",8}   {"Binary",32}   {"Octal",11}   {"Hex",10}");
        foreach (int number in numbers)
        {
            Console.WriteLine($"{number,8}   {Convert.ToString(number, 2),32}   {Convert.ToString(number, 8),11}   {Convert.ToString(number, 16),10}");
        }
        // The example displays the following output:
        //       Value                             Binary         Octal          Hex
        //        -146   11111111111111111111111101101110   37777777556     ffffff6e
        //       11043                     10101100100011         25443         2b23
        //     2781913             1010100111001011011001      12471331       2a72d9
        // </Snippet2>
    }
}
