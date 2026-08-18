// <Snippet1>
using System;
using System.Collections;
public class SamplesArrayList
{

    public static void Run()
    {

        // Creates and initializes a new ArrayList.
        ArrayList myAL = ["The", "quick", "brown", "fox"];

        // Creates a synchronized wrapper around the ArrayList.
        ArrayList mySyncdAL = ArrayList.Synchronized(myAL);

        // Displays the sychronization status of both ArrayLists.
        Console.WriteLine($"myAL is {(myAL.IsSynchronized ? "synchronized" : "not synchronized")}.");
        Console.WriteLine($"mySyncdAL is {(mySyncdAL.IsSynchronized ? "synchronized" : "not synchronized")}.");
    }
}
/*
This code produces the following output.

myAL is not synchronized.
mySyncdAL is synchronized.
*/
// </Snippet1>
