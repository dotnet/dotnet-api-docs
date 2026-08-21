// <Snippet1>
using System;
using System.Collections;
public class SamplesArrayList
{

    public static void Main()
    {

        // Creates and initializes a new ArrayList.
        ArrayList myAL = ["Hello", "World", "!"];

        // Displays the properties and values of the ArrayList.
        Console.WriteLine("myAL");
        Console.WriteLine($"    Count:    {myAL.Count}");
        Console.WriteLine($"    Capacity: {myAL.Capacity}");
        Console.Write("    Values:");
        PrintValues(myAL);
    }

    public static void PrintValues(IEnumerable myList)
    {
        foreach (object obj in myList)
        {
            Console.Write($"   {obj}");
        }

        Console.WriteLine();
    }
}


/*
This code produces output similar to the following:

myAL
    Count:    3
    Capacity: 4
    Values:   Hello   World   !

*/
// </Snippet1>
