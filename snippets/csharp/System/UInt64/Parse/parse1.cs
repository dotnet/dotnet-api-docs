using System;

public class UInt64ParseExample1
{
    public static void Run()
    {
        // <Snippet1>
        string[] values = { "+13230", "-0", "1,390,146", "$190,235,421,127",
                          "0xFA1B", "163042", "-10", "14065839182",
                          "16e07", "134985.0", "-12034" };
        foreach (string value in values)
        {
            try
            {
                ulong number = ulong.Parse(value);
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
        // The example displays the following output:
        //       +13230 --> 13230
        //       -0 --> 0
        //       1,390,146: Bad Format
        //       $190,235,421,127: Bad Format
        //       0xFA1B: Bad Format
        //       163042 --> 163042
        //       -10: Overflow
        //       14065839182 --> 14065839182
        //       16e07: Bad Format
        //       134985.0: Bad Format
        //       -12034: Overflow
        // </Snippet1>
    }
}
