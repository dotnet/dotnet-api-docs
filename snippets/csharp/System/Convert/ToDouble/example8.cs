// <Snippet8>
using System;

public class Example
{
    public static void Main()
    {
        string[] values = { "-1,035.77219", "1AFF", "1e-35",
                         "1,635,592,999,999,999,999,999,999", "-17.455",
                         "190.34001", "1.29e325"};
        double result;

        foreach (string value in values)
        {
            try
            {
                result = Convert.ToDouble(value);
                Console.WriteLine($"Converted '{value}' to {result}.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to convert '{value}' to a Double.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"'{value}' is outside the range of a Double.");
            }
        }
    }
}
// The example displays the following output:
//       Converted '-1,035.77219' to -1035.77219.
//       Unable to convert '1AFF' to a Double.
//       Converted '1e-35' to 1E-35.
//       Converted '1,635,592,999,999,999,999,999,999' to 1.635593E+24.
//       Converted '-17.455' to -17.455.
//       Converted '190.34001' to 190.34001.
//       '1.29e325' is outside the range of a Double.
// </Snippet8>
