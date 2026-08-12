// <Snippet4>
using System;
using System.Globalization;

public class TryParseExactExample4
{
    public static void Run()
    {
        string[] inputs = { "3", "16:42", "1:6:52:35.0625",
                          "1:6:52:35,0625" };
        string[] formats = { "%h", "g", "G" };
        TimeSpan interval;
        CultureInfo culture = new("fr-FR");

        // Parse each string in inputs using formats and the fr-FR culture.
        foreach (string input in inputs)
        {
            if (TimeSpan.TryParseExact(input, formats, culture,
                                      TimeSpanStyles.AssumeNegative, out interval))
                Console.WriteLine($"{input} --> {interval:c}");
            else
                Console.WriteLine($"Unable to parse {input}");
        }
    }
}
// The example displays the following output:
//       3 --> -03:00:00
//       16:42 --> 16:42:00
//       Unable to parse 1:6:52:35.0625
//       1:6:52:35,0625 --> 1.06:52:35.0625000
// </Snippet4>
