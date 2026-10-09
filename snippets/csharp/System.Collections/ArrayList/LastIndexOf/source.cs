// <Snippet1>
using System;
using System.Collections;
public class SamplesArrayList
{

    public static void Main()
    {

        // Creates and initializes a new ArrayList with three elements of the same value.
        ArrayList myAL =
        [
            "the",
            "quick",
            "brown",
            "fox",
            "jumps",
            "over",
            "the",
            "lazy",
            "dog",
            "in",
            "the",
            "barn",
        ];

        // Displays the values of the ArrayList.
        Console.WriteLine("The ArrayList contains the following values:");
        PrintIndexAndValues(myAL);

        // Searches for the last occurrence of the duplicated value.
        string myString = "the";
        int myIndex = myAL.LastIndexOf(myString);
        Console.WriteLine($"The last occurrence of \"{myString}\" is at index {myIndex}.");

        // Searches for the last occurrence of the duplicated value in the first section of the ArrayList.
        myIndex = myAL.LastIndexOf(myString, 8);
        Console.WriteLine($"The last occurrence of \"{myString}\" between the start and index 8 is at index {myIndex}.");

        // Searches for the last occurrence of the duplicated value in a section of the ArrayList.  Note that the start index is greater than the end index because the search is done backward.
        myIndex = myAL.LastIndexOf(myString, 10, 6);
        Console.WriteLine($"The last occurrence of \"{myString}\" between index 10 and index 5 is at index {myIndex}.");
    }

    public static void PrintIndexAndValues(IEnumerable myList)
    {
        int i = 0;
        foreach (object obj in myList)
        {
            Console.WriteLine($"   [{i++}]:    {obj}");
        }

        Console.WriteLine();
    }
}


/*
This code produces the following output.

The ArrayList contains the following values:
   [0]:    the
   [1]:    quick
   [2]:    brown
   [3]:    fox
   [4]:    jumps
   [5]:    over
   [6]:    the
   [7]:    lazy
   [8]:    dog
   [9]:    in
   [10]:    the
   [11]:    barn

The last occurrence of "the" is at index 10.
The last occurrence of "the" between the start and index 8 is at index 6.
The last occurrence of "the" between index 10 and index 5 is at index 10.
*/
// </Snippet1>
