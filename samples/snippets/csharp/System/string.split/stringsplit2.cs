using System;

public class StringSplit2
{
    public static void SplitWithCount()
    {
        // <snippet1>
        char[] delimiters = new char[] {' ', ',', '.', ':'};
        string words = "one two,three:four.";

        for (int i = 1; i <= 5; i++)
        {
            var split = words.Split(delimiters, i);
            Console.WriteLine("\ncount = {0,2} ..............", i);
            foreach (var s in split)
            {
                Console.WriteLine("-{0}-", s);
            }
        }

        // The example displays the following output:
        //
        //       count =  1 ..............
        //       -one two,three:four.-
        //       count =  2 ..............
        //       -one-
        //       -two,three:four.-
        //       count =  3 ..............
        //       -one-
        //       -two-
        //       -three:four.-
        //       count =  4 ..............
        //       -one-
        //       -two-
        //       -three-
        //       -four.-
        //       count =  5 ..............
        //       -one-
        //       -two-
        //       -three-
        //       -four-
        //       --
        // </snippet1>
    }
}

