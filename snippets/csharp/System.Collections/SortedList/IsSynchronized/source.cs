// <Snippet1>
using System;
using System.Collections;

public class SamplesSortedList
{
    public static void Run()
    {
        // Creates and initializes a new SortedList.
        SortedList mySL = new()
        {
            { 2, "two" },
            { 3, "three" },
            { 1, "one" },
            { 0, "zero" },
            { 4, "four" }
        };

        // Creates a synchronized wrapper around the SortedList.
        SortedList mySyncdSL = SortedList.Synchronized(mySL);

        // Displays the sychronization status of both SortedLists.
        Console.WriteLine($"mySL is {(mySL.IsSynchronized ? "synchronized" : "not synchronized")}.");
        Console.WriteLine($"mySyncdSL is {(mySyncdSL.IsSynchronized ? "synchronized" : "not synchronized")}.");
    }
}
/*
This code produces the following output.

mySL is not synchronized.
mySyncdSL is synchronized.
*/
// </Snippet1>
