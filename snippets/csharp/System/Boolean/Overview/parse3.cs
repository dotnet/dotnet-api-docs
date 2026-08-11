// <Snippet9>
using System;

public class Example8
{
    public static void Main()
    {
        string[] values = ["09", "12.6", "0", "-13 "];
        foreach (string value in values)
        {
            bool success, result;
            int number;
            success = int.TryParse(value, out number);
            if (success)
            {
                // The method throws no exceptions.
                result = Convert.ToBoolean(number);
                Console.WriteLine($"Converted '{value}' to {result}");
            }
            else
            {
                Console.WriteLine($"Unable to convert '{value}'");
            }
        }
    }
}
// The example displays the following output:
//       Converted '09' to True
//       Unable to convert '12.6'
//       Converted '0' to False
//       Converted '-13 ' to True
// </Snippet9>
