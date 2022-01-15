// Sample for String.IndexOf(Char, Int32)
using System;

class Sample
{
    public static void Main()
    {
        //<snippet1>
        string br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+---";
        string br2 = "012345678901234567890123456789012345678901234567890123456789012345678";
        string str = "Now is the time for all good men to come to the aid of their country.";
        int start;
        int at;

        Console.WriteLine();
        Console.WriteLine("All occurrences of 't' from position 0 to {0}.", str.Length-1);
        Console.WriteLine("{1}{0}{2}{0}{3}{0}", Environment.NewLine, br1, br2, str);
        Console.Write("The letter 't' occurs at position(s): ");

        at = 0;
        start = 0;
        while((start < str.Length) && (at > -1))
        {
            at = str.IndexOf('t', start);
            if (at == -1) break;
            Console.Write("{0} ", at);
            start = at+1;
        }
        Console.WriteLine();

        /*
        This example produces the following results:

        All occurrences of 't' from position 0 to 68.
        0----+----1----+----2----+----3----+----4----+----5----+----6----+---
        012345678901234567890123456789012345678901234567890123456789012345678
        Now is the time for all good men to come to the aid of their country.

        The letter 't' occurs at position(s): 7 11 33 41 44 55 65

        */
        //</snippet1>
    }
}
