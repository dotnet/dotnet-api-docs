// <Snippet1>
using System;

public class Int64ParseExample1
{
    public static void Run()
    {
        Convert("  179042  ");
        Convert(" -2041326 ");
        Convert(" +8091522 ");
        Convert("   1064.0   ");
        Convert("  178.3");
        Convert(string.Empty);
        Convert(((decimal)long.MaxValue) + 1.ToString());
    }

    private static void Convert(string value)
    {
        try
        {
            long number = long.Parse(value);
            Console.WriteLine($"Converted '{value}' to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to convert '{value}'.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{value}' is out of range.");
        }
    }
}
// This example displays the following output to the console:
//       Converted '  179042  ' to 179042.
//       Converted ' -2041326 ' to -2041326.
//       Converted ' +8091522 ' to 8091522.
//       Unable to convert '   1064.0   '.
//       Unable to convert '  178.3'.
//       Unable to convert ''.
//       '92233720368547758071' is out of range.
// </Snippet1>
