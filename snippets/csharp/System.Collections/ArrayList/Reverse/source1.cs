// <Snippet1>
using System;
using System.Collections;
public class SamplesArrayList1
{

    public static void Run()
    {

        // Creates and initializes a new ArrayList.
        ArrayList myAL =
        [
            "The",
            "QUICK",
            "BROWN",
            "FOX",
            "jumps",
            "over",
            "the",
            "lazy",
            "dog",
        ];

        // Displays the values of the ArrayList.
        Console.WriteLine("The ArrayList initially contains the following values:");
        PrintValues(myAL);

        // Reverses the sort order of the values of the ArrayList.
        myAL.Reverse(1, 3);

        // Displays the values of the ArrayList.
        Console.WriteLine("After reversing:");
        PrintValues(myAL);
    }

    public static void PrintValues(IEnumerable myList)
    {
        foreach (object obj in myList)
        {
            Console.WriteLine($"   {obj}");
        }

        Console.WriteLine();
    }
}


/*
This code produces the following output.

The ArrayList initially contains the following values:
   The
   QUICK
   BROWN
   FOX
   jumps
   over
   the
   lazy
   dog

After reversing:
   The
   FOX
   BROWN
   QUICK
   jumps
   over
   the
   lazy
   dog

*/
// </Snippet1>
