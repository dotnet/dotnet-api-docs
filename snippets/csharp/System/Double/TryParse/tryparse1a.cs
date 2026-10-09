// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        string[] values = { "1,643.57", "$1,643.57", "-1.643e6",
                          "-168934617882109132", "123AE6",
                          null, string.Empty, "ABCDEF" };
        double number;

        foreach (string value in values)
        {
            if (double.TryParse(value, out number))
                Console.WriteLine($"'{value}' --> {number}");
            else
                Console.WriteLine($"Unable to parse '{value}'.");
        }
    }
}
// The example displays the following output:
//       '1,643.57' --> 1643.57
//       Unable to parse '$1,643.57'.
//       '-1.643e6' --> -1643000
//       '-168934617882109132' --> -1.68934617882109E+17
//       Unable to parse '123AE6'.
//       Unable to parse ''.
//       Unable to parse ''.
//       Unable to parse 'ABCDEF'.
// </Snippet1>
