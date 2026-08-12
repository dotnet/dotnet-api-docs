// <Snippet4>
using System;
using System.Globalization;

public class ParseExactExample4
{
    public static void Run()
    {
        string[] inputs = [ "3", "16:42", "1:6:52:35.0625",
                          "1:6:52:35,0625" ];
        string[] formats = [ "%h", "g", "G" ];
        TimeSpan interval;
        CultureInfo culture = new("de-DE");

        // Parse each string in inputs using formats and the de-DE culture.
        foreach (string input in inputs)
        {
            try
            {
                interval = TimeSpan.ParseExact(input, formats, culture,
                                               TimeSpanStyles.AssumeNegative);
                Console.WriteLine($"{input} --> {interval:c}");
            }
            catch (FormatException)
            {
                Console.WriteLine($"{input} --> Bad Format");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"{input} --> Overflow");
            }
        }
    }
}
// The example displays the following output:
//       3 --> -03:00:00
//       16:42 --> 16:42:00
//       1:6:52:35.0625 --> Bad Format
//       1:6:52:35,0625 --> 1.06:52:35.0625000
// </Snippet4>
