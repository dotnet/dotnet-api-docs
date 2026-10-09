// <Snippet1>
using System;

public class BooleanConversion
{
    public static void Main()
    {
        string[] values = { null, string.Empty, "true", "TrueString",
                          "False", "    false    ", "-1", "0" };
        foreach (string value in values)
        {
            try
            {
                Console.WriteLine($"Converted '{value}' to {Convert.ToBoolean(value)}.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to convert '{value}' to a Boolean.");
            }
        }
    }
}
// The example displays the following output:
//       Converted '' to False.
//       Unable to convert '' to a Boolean.
//       Converted 'true' to True.
//       Unable to convert 'TrueString' to a Boolean.
//       Converted 'False' to False.
//       Converted '    false    ' to False.
//       Unable to convert '-1' to a Boolean.
//       Unable to convert '0' to a Boolean.
// </Snippet1>
