// <Snippet1>
using System;
using System.Collections;
public class SamplesSortedList
{

    public static void Main()
    {

        // Creates and initializes a new SortedList.
        SortedList mySL = new()
        {
            { "3c", "dog" },
            { "2c", "over" },
            { "1c", "brown" },
            { "1a", "The" },
            { "1b", "quick" },
            { "3a", "the" },
            { "3b", "lazy" },
            { "2a", "fox" },
            { "2b", "jumps" }
        };

        // Displays the SortedList.
        Console.WriteLine("The SortedList initially contains the following:");
        PrintKeysAndValues(mySL);

        // Removes the element with the key "3b".
        mySL.Remove("3b");

        // Displays the current state of the SortedList.
        Console.WriteLine("After removing \"lazy\":");
        PrintKeysAndValues(mySL);

        // Removes the element at index 5.
        mySL.RemoveAt(5);

        // Displays the current state of the SortedList.
        Console.WriteLine("After removing the element at index 5:");
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

The SortedList initially contains the following:
    -KEY-    -VALUE-
    1a:    The
    1b:    quick
    1c:    brown
    2a:    fox
    2b:    jumps
    2c:    over
    3a:    the
    3b:    lazy
    3c:    dog

After removing "lazy":
    -KEY-    -VALUE-
    1a:    The
    1b:    quick
    1c:    brown
    2a:    fox
    2b:    jumps
    2c:    over
    3a:    the
    3c:    dog

After removing the element at index 5:
    -KEY-    -VALUE-
    1a:    The
    1b:    quick
    1c:    brown
    2a:    fox
    2b:    jumps
    3a:    the
    3c:    dog
*/
// </Snippet1>
