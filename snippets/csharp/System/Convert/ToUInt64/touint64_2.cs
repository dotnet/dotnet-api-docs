// <Snippet15>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        // Create a NumberFormatInfo object and set several properties.
        NumberFormatInfo provider = new()
        {
            PositiveSign = "pos ",
            NegativeSign = "neg "
        };

        // Define an array of numeric strings.
        string[] values = { "123456789012", "+123456789012",
                          "pos 123456789012", "123456789012.",
                          "123,456,789,012", "18446744073709551615",
                          "18446744073709551616", "neg 1", "-1" };
        //  Convert the strings using the format provider.
        foreach (string value in values)
        {
            Console.Write($"{value,-20}  -->  ");
            try
            {
                Console.WriteLine($"{Convert.ToUInt64(value, provider),20}");
            }
            catch (FormatException)
            {
                Console.WriteLine($"{"Invalid Format",20}");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"{"Numeric Overflow",20}");
            }
        }
    }
}
// The example displays the following output:
//    123456789012          -->          123456789012
//    +123456789012         -->        Invalid Format
//    pos 123456789012      -->          123456789012
//    123456789012.         -->        Invalid Format
//    123,456,789,012       -->        Invalid Format
//    18446744073709551615  -->  18446744073709551615
//    18446744073709551616  -->      Numeric Overflow
//    neg 1                 -->      Numeric Overflow
//    -1                    -->        Invalid Format
// </Snippet15>
