// <Snippet18>
using System;
using System.Globalization;

public class Example
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

        // Define an array of strings to convert to UInt16 values.
        string[] values = { "34567", "+34567", "pos 34567", "34567.",
                         "34567.", "65535", "65535", "65535" };

        foreach (string value in values)
        {
            Console.Write($"{value,-12}  -->  ");
            try
            {
                Console.WriteLine($"{Convert.ToUInt16(value, provider),17}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"{e.GetType().Name,17}");
            }
        }
    }
}
// The example displays the following output:
//       34567         -->              34567
//       +34567        -->    FormatException
//       pos 34567     -->              34567
//       34567.        -->    FormatException
//       34567.        -->    FormatException
//       65535         -->              65535
//       65535         -->              65535
//       65535         -->              65535
// </Snippet18>
