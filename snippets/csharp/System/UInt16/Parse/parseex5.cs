// <Snippet5>
using System;

public class Example
{
    public static void Main()
    {
        string[] values = { "-0", "17", "-12", "185", "66012", "+0",
                          "", null, "16.1", "28.0", "1,034" };
        foreach (string value in values)
        {
            try
            {
                ushort number = ushort.Parse(value);
                Console.WriteLine($"'{value}' --> {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine($"'{value}' --> Bad Format");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"'{value}' --> OverflowException");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"'{value}' --> Null");
            }
        }
    }
}
// The example displays the following output:
//       '-0' --> 0
//       '17' --> 17
//       '-12' --> OverflowException
//       '185' --> 185
//       '66012' --> OverflowException
//       '+0' --> 0
//       '' --> Bad Format
//       '' --> Null
//       '16.1' --> Bad Format
//       '28.0' --> Bad Format
//       '1,034' --> Bad Format
// </Snippet5>
