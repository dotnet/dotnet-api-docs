using System;

public class Example1
{
    public static void Main()
    {
        // <Snippet1>
        short[] values = [short.MinValue, -27, 0, 1042, short.MaxValue];
        Console.WriteLine($"{"Decimal",10}  {"Hex",10}\n");
        foreach (short value in values)
        {
            string formatString = string.Format("{0,10:G}: {0,10:X}", value);
            Console.WriteLine(formatString);
        }
        // The example displays the following output:
        //       Decimal         Hex
        //
        //        -32768:       8000
        //           -27:       FFE5
        //             0:          0
        //          1042:        412
        //         32767:       7FFF
        // </Snippet1>
    }
}
