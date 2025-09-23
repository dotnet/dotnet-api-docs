
// Sample for String.IndexOfAny(Char[], Int32, Int32)
using System;

class Example3
{
    public static void Run()
    {
        //<snippet1>
        string br1 = "0----+----1----+----2----+----3----" +
            "+----4----+----5----+----6----+-";
        string br2 = "012345678901234567890123456789" +
            "0123456789012345678901234567890123456";
        string str = "Now is the time for all good men " +
            "to come to the aid of their party.";
        string target = "aid";
        char[] anyOf = target.ToCharArray();

        int start = (str.Length - 1) / 3;
        int count = (str.Length - 1) / 4;
        Console.WriteLine();
        Console.WriteLine("The first character occurrence from " +
            $"position {start} for {count} characters:");
        Console.WriteLine($"""
            {Environment.NewLine}{br1}{Environment.NewLine}{br2}
            {Environment.NewLine}{str}{Environment.NewLine}
            """);
        Console.Write($"A character in '{target}' occurs at position: ");

        int at = str.IndexOfAny(anyOf, start, count);
        if (at > -1)
            Console.Write(at);
        else
            Console.Write("(not found)");
        Console.WriteLine();

        /*

        The first character occurrence from position 22 for 16 characters.
        0----+----1----+----2----+----3----+----4----+----5----+----6----+-
        0123456789012345678901234567890123456789012345678901234567890123456
        Now is the time for all good men to come to the aid of their party.

        A character in 'aid' occurs at position: 27

        */
        //</snippet1>
    }
}
