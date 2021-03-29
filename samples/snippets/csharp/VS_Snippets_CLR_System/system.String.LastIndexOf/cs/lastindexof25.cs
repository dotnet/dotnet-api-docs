﻿using System;

public class Example
{
    public static void Main()
    {
        // <Snippet25>
        string searchString = "\u00ADm";

        string s1 = "ani\u00ADmal";
        string s2 = "animal";

        int position;

        position = s1.LastIndexOf('m');
        if (position >= 0)
        {
            Console.WriteLine(s1.LastIndexOf(searchString, position, StringComparison.CurrentCulture));
            Console.WriteLine(s1.LastIndexOf(searchString, position, StringComparison.Ordinal));
        }

        position = s2.LastIndexOf('m');
        if (position >= 0)
        {
            Console.WriteLine(s2.LastIndexOf(searchString, position, StringComparison.CurrentCulture));
            Console.WriteLine(s2.LastIndexOf(searchString, position, StringComparison.Ordinal));
        }

        // The example displays the following output:
        //
        // 4
        // 3
        // 3
        // -1
        // </Snippet25>
    }
}
