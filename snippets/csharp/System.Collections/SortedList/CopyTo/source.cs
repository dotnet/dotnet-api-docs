// <Snippet1>
using System;
using System.Collections;
public class SamplesSortedList
{

    public static void Main()
    {

        // Creates and initializes the source SortedList.
        SortedList mySourceList = new()
        {
            { 2, "cats" },
            { 3, "in" },
            { 1, "napping" },
            { 4, "the" },
            { 0, "three" },
            { 5, "barn" }
        };

        // Creates and initializes the one-dimensional target Array.
        string[] tempArray = ["The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog"];
        DictionaryEntry[] myTargetArray = new DictionaryEntry[15];
        int i = 0;
        foreach (string s in tempArray)
        {
            myTargetArray[i].Key = i;
            myTargetArray[i].Value = s;
            i++;
        }

        // Displays the values of the target Array.
        Console.WriteLine("The target Array contains the following (before and after copying):");
        PrintValues(myTargetArray, ' ');

        // Copies the entire source SortedList to the target SortedList, starting at index 6.
        mySourceList.CopyTo(myTargetArray, 6);

        // Displays the values of the target Array.
        PrintValues(myTargetArray, ' ');
    }

    public static void PrintValues(DictionaryEntry[] myArr, char mySeparator)
    {
        for (int i = 0; i < myArr.Length; i++)
        {
            Console.Write($"{mySeparator}{myArr[i].Value}");
        }

        Console.WriteLine();
    }
}


/*
This code produces the following output.

The target Array contains the following (before and after copying):
 The quick brown fox jumps over the lazy dog
 The quick brown fox jumps over three napping cats in the barn

*/
// </Snippet1>
