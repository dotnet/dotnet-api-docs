
// Sample for String.IndexOfAny(Char[], Int32)
using System;

class Example2
{
    public static void Run()
    {
        //<snippet1>
        string br1 = "0----+----1----+----2----+----3" +
            "----+----4----+----5----+----6----+-";
        string br2 = "012345678901234567890123456789" +
            "0123456789012345678901234567890123456";
        string str = "Now is the time for all good men " +
            "to come to the aid of their party.";
        int start;
        int at;
        string target = "is";
        char[] anyOf = target.ToCharArray();

        start = str.Length / 2;
        Console.WriteLine();
        Console.WriteLine("The first character occurrence " +
            $"from position {start} to {str.Length - 1}:");
        Console.WriteLine($"""
            {Environment.NewLine}{br1}{Environment.NewLine}
            {br2}{Environment.NewLine}{str}{Environment.NewLine}
            """);
        Console.Write($"A character in '{target}' occurs at position: ");

        at = str.IndexOfAny(anyOf, start);
        if (at > -1)
            Console.Write(at);
        else
            Console.Write("(not found)");
        Console.WriteLine();

        /*

        The first character occurrence from position 33 to 66.
        0----+----1----+----2----+----3----+----4----+----5----+----6----+-
        0123456789012345678901234567890123456789012345678901234567890123456
        Now is the time for all good men to come to the aid of their party.

        A character in 'is' occurs at position: 49

        */
        //</snippet1>
    }
}
