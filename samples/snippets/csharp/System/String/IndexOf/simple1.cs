﻿using System;

public class Example
{
    public static void Main()
    {
        // <Snippet12>
        String str = "animal";
        String toFind = "n";
        int index = str.IndexOf("n");
        Console.WriteLine("Found '{0}' in '{1}' at position {2}",
                        toFind, str, index);

        // The example displays the following output:
        //        Found 'n' in 'animal' at position 1
        // </Snippet12>
    }
}
