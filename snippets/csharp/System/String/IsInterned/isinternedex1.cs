// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        string str1 = "a";
        string str2 = str1 + "b";
        string str3 = str2 + "c";
        string[] strings = { "value", "part1" + "_" + "part2", str3,
                           string.Empty, null };
        foreach (string value in strings)
        {
            if (value == null) continue;

            bool interned = string.IsInterned(value) != null;
            if (interned)
                Console.WriteLine($"'{value}' is in the string intern pool.");
            else
                Console.WriteLine($"'{value}' is not in the string intern pool.");
        }
    }
}
// The example displays the following output:
//       'value' is in the string intern pool.
//       'part1_part2' is in the string intern pool.
//       'abc' is not in the string intern pool.
//       '' is in the string intern pool.
// </Snippet1>
