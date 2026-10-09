// <Snippet2>
using System;
using System.Globalization;

class Example
{
    static void Main()
    {
        // Create a NumberFormatInfo object and set some of its properties.
        NumberFormatInfo provider = new()
        {
            NumberDecimalSeparator = ",",
            NumberGroupSeparator = ".",
            NumberGroupSizes = new int[] { 3 }
        };

        // Define an array of numeric strings to convert.
        string[] values = { "123456789", "12345.6789", "12345,6789",
                            "123,456.789", "123.456,789",
                            "123,456,789.0123", "123.456.789,0123" };

        Console.WriteLine($"Default Culture: {CultureInfo.CurrentCulture.Name}\n");
        Console.WriteLine($"{"String to Convert",-22} {"Default/Exception",-20} {"Provider/Exception",-20}\n");

        // Convert each string to a Double with and without the provider.
        foreach (string value in values)
        {
            Console.Write($"{value,-22} ");
            try
            {
                Console.Write($"{Convert.ToDouble(value),-20} ");
            }
            catch (FormatException e)
            {
                Console.Write($"{e.GetType().Name,-20} ");
            }
            try
            {
                Console.WriteLine($"{Convert.ToDouble(value, provider),-20} ");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"{e.GetType().Name,-20} ");
            }
        }
    }
}
// The example displays the following output:
//       Default Culture: en-US
//
//       String to Convert      Default/Exception    Provider/Exception
//
//       123456789              123456789            123456789
//       12345.6789             12345.6789           123456789
//       12345,6789             123456789            12345.6789
//       123,456.789            123456.789           FormatException
//       123.456,789            FormatException      123456.789
//       123,456,789.0123       123456789.0123       FormatException
//       123.456.789,0123       FormatException      123456789.0123
// </Snippet2>
