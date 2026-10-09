// The following example shows how to copy the elements of an ArrayList to a string array.

// <Snippet1>
using System;
using System.Collections;

public class SamplesArrayList
{

    public static void Main()
    {

        // Creates and initializes a new ArrayList.
        ArrayList myAL =
        [
            "The",
            "quick",
            "brown",
            "fox",
            "jumps",
            "over",
            "the",
            "lazy",
            "dog",
        ];

        // Displays the values of the ArrayList.
        Console.WriteLine("The ArrayList contains the following values:");
        PrintIndexAndValues(myAL);

        // Copies the elements of the ArrayList to a string array.
        string[] myArr = (string[])myAL.ToArray(typeof(string));

        // Displays the contents of the string array.
        Console.WriteLine("The string array contains the following values:");
        PrintIndexAndValues(myArr);
    }

    public static void PrintIndexAndValues(ArrayList myList)
    {
        int i = 0;
        foreach (object o in myList)
        {
            Console.WriteLine($"\t[{i++}]:\t{o}");
        }

        Console.WriteLine();
    }

    public static void PrintIndexAndValues(string[] myArr)
    {
        for (int i = 0; i < myArr.Length; i++)
        {
            Console.WriteLine($"\t[{i}]:\t{myArr[i]}");
        }

        Console.WriteLine();
    }
}


/*
This code produces the following output.

The ArrayList contains the following values:
        [0]:    The
        [1]:    quick
        [2]:    brown
        [3]:    fox
        [4]:    jumps
        [5]:    over
        [6]:    the
        [7]:    lazy
        [8]:    dog

The string array contains the following values:
        [0]:    The
        [1]:    quick
        [2]:    brown
        [3]:    fox
        [4]:    jumps
        [5]:    over
        [6]:    the
        [7]:    lazy
        [8]:    dog

*/

// </Snippet1>
