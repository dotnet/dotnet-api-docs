// <Snippet1>
using System;
using System.Collections;

public class SamplesHashtable2
{
    public static void Run()
    {
        // Creates and initializes a new Hashtable.
        Hashtable myHT = new()
        {
            { 0, "zero" },
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" }
        };

        // Creates a synchronized wrapper around the Hashtable.
        Hashtable mySyncdHT = Hashtable.Synchronized(myHT);

        // Displays the sychronization status of both Hashtables.
        Console.WriteLine($"myHT is {(myHT.IsSynchronized ? "synchronized" : "not synchronized")}.");
        Console.WriteLine($"mySyncdHT is {(mySyncdHT.IsSynchronized ? "synchronized" : "not synchronized")}.");
    }
}

/*
This code produces the following output.

myHT is not synchronized.
mySyncdHT is synchronized.
*/
// </Snippet1>
