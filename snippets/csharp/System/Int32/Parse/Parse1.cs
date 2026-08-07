// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        string[] values = { "+13230", "-0", "1,390,146", "$190,235,421,127",
                          "0xFA1B", "163042", "-10", "007", "2147483647",
                          "2147483648", "16e07", "134985.0", "-12034",
                          "-2147483648", "-2147483649" };
        foreach (string value in values)
        {
            try
            {
                int number = int.Parse(value);
                Console.WriteLine($"{value} --> {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine($"{value}: Bad Format");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"{value}: Overflow");
            }
        }
    }
}
// The example displays the following output:
//       +13230 --> 13230
//       -0 --> 0
//       1,390,146: Bad Format
//       $190,235,421,127: Bad Format
//       0xFA1B: Bad Format
//       163042 --> 163042
//       -10 --> -10
//       007 --> 7
//       2147483647 --> 2147483647
//       2147483648: Overflow
//       16e07: Bad Format
//       134985.0: Bad Format
//       -12034 --> -12034
//       -2147483648 --> -2147483648
//       -2147483649: Overflow
// </Snippet1>
