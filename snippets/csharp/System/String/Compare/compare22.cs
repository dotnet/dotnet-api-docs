using System;

public class Example22
{
    public static void Main()
    {
        // <Snippet22>
        string s1 = "Ani\u00ADmal";
        string s2 = "animal";

        Console.WriteLine($"Comparison of '{s1}' and '{s2}': {string.Compare(s1, s2, true)}");

        // The example displays the following output:
        //       Comparison of 'Ani-mal' and 'animal': 0

        // </Snippet22>
    }
}
