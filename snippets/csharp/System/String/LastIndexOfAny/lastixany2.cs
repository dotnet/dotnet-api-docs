//<snippet1>
// Sample for String.LastIndexOfAny(Char[], Int32)
using System;

class LastIndexOfAnyStartSample
{
    public static void Run()
    {

        string br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-";
        string br2 = "0123456789012345678901234567890123456789012345678901234567890123456";
        string str = "Now is the time for all good men to come to the aid of their party.";
        int start;
        int at;
        string target = "is";
        char[] anyOf = target.ToCharArray();

        start = (str.Length - 1) / 2;
        Console.WriteLine($"The last character occurrence  from position {start} to 0.");
        Console.WriteLine("{1}{0}{2}{0}{3}{0}", Environment.NewLine, br1, br2, str);
        Console.Write($"A character in '{target}' occurs at position: ");

        at = str.LastIndexOfAny(anyOf, start);
        if (at > -1)
            Console.Write(at);
        else
            Console.Write("(not found)");
        Console.Write("{0}{0}{0}", Environment.NewLine);
    }
}
/*
This example produces the following results:
The last character occurrence  from position 33 to 0.
0----+----1----+----2----+----3----+----4----+----5----+----6----+-
0123456789012345678901234567890123456789012345678901234567890123456
Now is the time for all good men to come to the aid of their party.

A character in 'is' occurs at position: 12


*/
//</snippet1>
