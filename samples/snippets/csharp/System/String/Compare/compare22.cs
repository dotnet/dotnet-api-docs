﻿// <Snippet22>
using System;

public class Example
{
    public static void Main()
    {
        string s1 = "Ani\u00ADmal";
        string s2 = "animal";
      
        Console.WriteLine("Comparison of '{0}' and '{1}': {2}", 
                        s1, s2, String.Compare(s1, s2, true));

        // The example displays the following output:
        //       Comparison of 'Ani-mal' and 'animal': 0
    }
}
// </Snippet22>
