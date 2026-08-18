// The following example shows how to sort the values in a section of an <see cref="System.Collections.ArrayList" /> using the default comparer and a custom comparer which reverses the sort order.

// <Snippet1>
using System;
using System.Collections;

public class SamplesArrayList3
{
    public class ReverseCaseInsensitiveComparer : IComparer
    {
        // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare(object x, object y) => ((new CaseInsensitiveComparer()).Compare(y, x));
    }

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
        PrintIndexAndValues(myAL);

        // Sorts the values of the ArrayList using the default comparer.
        myAL.Sort(1, 3, null);
        Console.WriteLine("After sorting from index 1 to index 3 with the default comparer:");
        PrintIndexAndValues(myAL);

        // Sorts the values of the ArrayList using the reverse case-insensitive comparer.
        IComparer myComparer = new ReverseCaseInsensitiveComparer();
        myAL.Sort(1, 3, myComparer);
        Console.WriteLine("After sorting from index 1 to index 3 with the reverse case-insensitive comparer:");
        PrintIndexAndValues(myAL);
    }

    public static void PrintIndexAndValues(IEnumerable myList)
    {
        int i = 0;
        foreach (object obj in myList)
        {
            Console.WriteLine($"\t[{i++}]:\t{obj}");
        }

        Console.WriteLine();
    }
}

/*
This code produces the following output.
The ArrayList initially contains the following values:
        [0]:    The
        [1]:    QUICK
        [2]:    BROWN
        [3]:    FOX
        [4]:    jumps
        [5]:    over
        [6]:    the
        [7]:    lazy
        [8]:    dog

After sorting from index 1 to index 3 with the default comparer:
        [0]:    The
        [1]:    BROWN
        [2]:    FOX
        [3]:    QUICK
        [4]:    jumps
        [5]:    over
        [6]:    the
        [7]:    lazy
        [8]:    dog

After sorting from index 1 to index 3 with the reverse case-insensitive comparer:
        [0]:    The
        [1]:    QUICK
        [2]:    FOX
        [3]:    BROWN
        [4]:    jumps
        [5]:    over
        [6]:    the
        [7]:    lazy
        [8]:    dog
*/

// </Snippet1>
