// <Snippet2>
using System;

public class CompareToStringExample
{
    public static void Run()
    {
        string s1 = "ani\u00ADmal";
        string s2 = "animal";

        Console.WriteLine($"Comparison of '{s1}' and '{s2}': {s1.CompareTo(s2)}");
    }
}
// The example displays the following output:
//       Comparison of 'ani-mal' and 'animal': 0
// </Snippet2>
