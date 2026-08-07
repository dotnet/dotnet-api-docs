// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        string s1 = "ani\u00ADmal";
        object o1 = "animal";

        Console.WriteLine($"Comparison of '{s1}' and '{o1}': {s1.CompareTo(o1)}");
    }
}
// The example displays the following output:
//       Comparison of 'ani-mal' and 'animal': 0
// </Snippet1>
