// <Snippet1>
using System;
using System.Collections;
public class SamplesQueue
{

    public static void Main()
    {

        // Creates and initializes a new Queue.
        Queue myQ = new();
        myQ.Enqueue("Hello");
        myQ.Enqueue("World");
        myQ.Enqueue("!");

        // Displays the properties and values of the Queue.
        Console.WriteLine("myQ");
        Console.WriteLine($"\tCount:    {myQ.Count}");
        Console.Write("\tValues:");
        PrintValues(myQ);
    }

    public static void PrintValues(IEnumerable myCollection)
    {
        foreach (object obj in myCollection)
        {
            Console.Write($"    {obj}");
        }

        Console.WriteLine();
    }
}
/*
This code produces the following output.

myQ
    Count:    3
    Values:    Hello    World    !
*/
// </Snippet1>
