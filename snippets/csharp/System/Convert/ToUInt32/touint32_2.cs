// <Snippet15>
using System;
using System.Globalization;

public class Class1
{
    public static void Main()
    {
        // Create a NumberFormatInfo object and set several of its
        // properties that apply to numbers.
        NumberFormatInfo provider = new()
        {
            PositiveSign = "pos ",
            NegativeSign = "neg "
        };

        // Define an array of numeric strings.
        string[] values = { "123456789", "+123456789", "pos 123456789",
                          "123456789.", "123,456,789",  "4294967295",
                          "4294967296", "-1", "neg 1" };

        foreach (string value in values)
        {
            Console.Write($"{value,-20} -->");
            try
            {
                Console.WriteLine($"{Convert.ToUInt32(value, provider),20}");
            }
            catch (FormatException)
            {
                Console.WriteLine($"{"Bad Format",20}");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"{"Numeric Overflow",20}");
            }
        }
    }
}
// The example displays the following output:
//       123456789            -->           123456789
//       +123456789           -->          Bad Format
//       pos 123456789        -->           123456789
//       123456789.           -->          Bad Format
//       123,456,789          -->          Bad Format
//       4294967295           -->          4294967295
//       4294967296           -->    Numeric Overflow
//       -1                   -->          Bad Format
//       neg 1                -->    Numeric Overflow
// </Snippet15>
