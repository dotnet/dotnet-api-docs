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
            { "one", "The" },
            { "two", "quick" },
            { "three", "brown" },
            { "four", "fox" },
            { "five", "jumps" }
        };

        // Displays the count, capacity and values of the SortedList.
        Console.WriteLine("Initially,");
        Console.WriteLine($"   Count    : {mySL.Count}");
        Console.WriteLine($"   Capacity : {mySL.Capacity}");
        Console.WriteLine("   Values:");
        PrintKeysAndValues(mySL);

        // Trims the SortedList.
        mySL.TrimToSize();

        // Displays the count, capacity and values of the SortedList.
        Console.WriteLine("After TrimToSize,");
        Console.WriteLine($"   Count    : {mySL.Count}");
        Console.WriteLine($"   Capacity : {mySL.Capacity}");
        Console.WriteLine("   Values:");
        PrintKeysAndValues(mySL);

        // Clears the SortedList.
        mySL.Clear();

        // Displays the count, capacity and values of the SortedList.
        Console.WriteLine("After Clear,");
        Console.WriteLine($"   Count    : {mySL.Count}");
        Console.WriteLine($"   Capacity : {mySL.Capacity}");
        Console.WriteLine("   Values:");
        PrintKeysAndValues(mySL);

        // Trims the SortedList again.
        mySL.TrimToSize();

        // Displays the count, capacity and values of the SortedList.
        Console.WriteLine("After the second TrimToSize,");
        Console.WriteLine($"   Count    : {mySL.Count}");
        Console.WriteLine($"   Capacity : {mySL.Capacity}");
        Console.WriteLine("   Values:");
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

Initially,
   Count    : 5
   Capacity : 16
   Values:
    -KEY-    -VALUE-
    five:    jumps
    four:    fox
    one:    The
    three:    brown
    two:    quick

After TrimToSize,
   Count    : 5
   Capacity : 5
   Values:
    -KEY-    -VALUE-
    five:    jumps
    four:    fox
    one:    The
    three:    brown
    two:    quick

After Clear,
   Count    : 0
   Capacity : 16
   Values:
    -KEY-    -VALUE-

After the second TrimToSize,
   Count    : 0
   Capacity : 16
   Values:
    -KEY-    -VALUE-
*/
// </Snippet1>
