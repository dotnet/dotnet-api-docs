﻿using System;

class Example
{
    public static void Main()
    {
        //<snippet1>
        string s1 = "The quick brown fox jumps over the lazy dog";
        string s2 = "fox";
        bool b = s1.Contains(s2);
        Console.WriteLine("'{0}' is in the string '{1}': {2}",
                        s2, s1, b);
        if (b) {
            int index = s1.IndexOf(s2);
            if (index >= 0)
                Console.WriteLine("'{0} begins at character position {1}",
                              s2, index + 1);
        }
        // This example displays the following output:
        //    'fox' is in the string 'The quick brown fox jumps over the lazy dog': True
        //    'fox begins at character position 17
        //</snippet1>
    }
}
