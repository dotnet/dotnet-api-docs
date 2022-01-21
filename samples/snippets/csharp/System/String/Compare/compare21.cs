﻿using System;

public class Example21
{
    public static void Main()
    {
        // <Snippet21>
        string s1 = "ani\u00ADmal";
        string s2 = "animal";

        Console.WriteLine("Comparison of '{0}' and '{1}': {2}",
                        s1, s2, String.Compare(s1, s2));

        // The example displays the following output:
        //       Comparison of 'ani-mal' and 'animal': 0

        // </Snippet21>
    }
}
