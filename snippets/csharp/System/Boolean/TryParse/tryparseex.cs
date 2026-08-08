// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        string[] values = { null, string.Empty, "True", "False",
                          "true", "false", "    true    ", "0",
                          "1", "-1", "string" };
        foreach (string value in values)
        {
            bool flag;
            if (bool.TryParse(value, out flag))
                Console.WriteLine($"'{value}' --> {flag}");
            else
                Console.WriteLine($"Unable to parse '{(value == null ? "<null>" : value)}'.");
        }
    }
}
// The example displays the following output:
//       Unable to parse '<null>'.
//       Unable to parse ''.
//       'True' --> True
//       'False' --> False
//       'true' --> True
//       'false' --> False
//       '    true    ' --> True
//       Unable to parse '0'.
//       Unable to parse '1'.
//       Unable to parse '-1'.
//       Unable to parse 'string'.
// </Snippet1>
