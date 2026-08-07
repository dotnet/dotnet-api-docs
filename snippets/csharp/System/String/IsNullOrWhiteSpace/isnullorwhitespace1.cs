// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        string[] values = { null, string.Empty, "ABCDE",
                          new string(' ', 20), "  \t   ",
                          new string('\u2000', 10) };
        foreach (string value in values)
            Console.WriteLine(string.IsNullOrWhiteSpace(value));
    }
}
// The example displays the following output:
//       True
//       True
//       False
//       True
//       True
//       True
// </Snippet1>
