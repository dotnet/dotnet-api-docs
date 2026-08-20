// <Snippet1>
using System;
using System.Collections;

public class SamplesSortedList2
{
    public static void Run()
    {
        // Creates and initializes a new SortedList.
        SortedList mySL = new()
        {
            { "Third", "!" },
            { "Second", "World" },
            { "First", "Hello" }
        };

        // Displays the properties and values of the SortedList.
        Console.WriteLine("mySL");
        Console.WriteLine($"  Count:    {mySL.Count}");
        Console.WriteLine($"  Capacity: {mySL.Capacity}");
        Console.WriteLine("  Keys and Values:");
        PrintKeysAndValues(mySL);
    }

    public static void PrintKeysAndValues(SortedList myList)
    {
        Console.WriteLine("\t-KEY-\t-VALUE-");
        for (int i = 0; i < myList.Count; i++)
        {
            Console.WriteLine($"\t{myList.GetKey(i)}:\t{myList.GetByIndex(i)}");
        }
        Console.WriteLine();
    }
}
/*
This code produces the following output.

mySL
  Count:    3
  Capacity: 16
  Keys and Values:
    -KEY-    -VALUE-
    First:    Hello
    Second:    World
    Third:    !
*/
// </Snippet1>
