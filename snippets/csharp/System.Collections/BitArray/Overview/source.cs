// <Snippet1>
using System;
using System.Collections;
public class SamplesBitArray
{

    public static void Run()
    {

        // Creates and initializes several BitArrays.
        BitArray myBA1 = new(5);

        BitArray myBA2 = new(5, false);

        byte[] myBytes = [1, 2, 3, 4, 5];
        BitArray myBA3 = new(myBytes);

        bool[] myBools = [true, false, true, true, false];
        BitArray myBA4 = new(myBools);

        int[] myInts = [6, 7, 8, 9, 10];
        BitArray myBA5 = new(myInts);

        // Displays the properties and values of the BitArrays.
        Console.WriteLine("myBA1");
        Console.WriteLine($"   Count:    {myBA1.Count}");
        Console.WriteLine($"   Length:   {myBA1.Length}");
        Console.WriteLine("   Values:");
        PrintValues(myBA1, 8);

        Console.WriteLine("myBA2");
        Console.WriteLine($"   Count:    {myBA2.Count}");
        Console.WriteLine($"   Length:   {myBA2.Length}");
        Console.WriteLine("   Values:");
        PrintValues(myBA2, 8);

        Console.WriteLine("myBA3");
        Console.WriteLine($"   Count:    {myBA3.Count}");
        Console.WriteLine($"   Length:   {myBA3.Length}");
        Console.WriteLine("   Values:");
        PrintValues(myBA3, 8);

        Console.WriteLine("myBA4");
        Console.WriteLine($"   Count:    {myBA4.Count}");
        Console.WriteLine($"   Length:   {myBA4.Length}");
        Console.WriteLine("   Values:");
        PrintValues(myBA4, 8);

        Console.WriteLine("myBA5");
        Console.WriteLine($"   Count:    {myBA5.Count}");
        Console.WriteLine($"   Length:   {myBA5.Length}");
        Console.WriteLine("   Values:");
        PrintValues(myBA5, 8);
    }

    public static void PrintValues(IEnumerable myList, int myWidth)
    {
        int i = myWidth;
        foreach (object obj in myList)
        {
            if (i <= 0)
            {
                i = myWidth;
                Console.WriteLine();
            }
            i--;
            Console.Write($"{obj,8}");
        }
        Console.WriteLine();
    }
}


/*
This code produces the following output.

myBA1
   Count:    5
   Length:   5
   Values:
   False   False   False   False   False
myBA2
   Count:    5
   Length:   5
   Values:
   False   False   False   False   False
myBA3
   Count:    40
   Length:   40
   Values:
    True   False   False   False   False   False   False   False
   False    True   False   False   False   False   False   False
    True    True   False   False   False   False   False   False
   False   False    True   False   False   False   False   False
    True   False    True   False   False   False   False   False
myBA4
   Count:    5
   Length:   5
   Values:
    True   False    True    True   False
myBA5
   Count:    160
   Length:   160
   Values:
   False    True    True   False   False   False   False   False
   False   False   False   False   False   False   False   False
   False   False   False   False   False   False   False   False
   False   False   False   False   False   False   False   False
    True    True    True   False   False   False   False   False
   False   False   False   False   False   False   False   False
   False   False   False   False   False   False   False   False
   False   False   False   False   False   False   False   False
   False   False   False    True   False   False   False   False
   False   False   False   False   False   False   False   False
   False   False   False   False   False   False   False   False
   False   False   False   False   False   False   False   False
    True   False   False    True   False   False   False   False
   False   False   False   False   False   False   False   False
   False   False   False   False   False   False   False   False
   False   False   False   False   False   False   False   False
   False    True   False    True   False   False   False   False
   False   False   False   False   False   False   False   False
   False   False   False   False   False   False   False   False
   False   False   False   False   False   False   False   False
*/

// </Snippet1>
