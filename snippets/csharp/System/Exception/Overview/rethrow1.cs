// <Snippet6>
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public static class Library
{
    public static int[] FindOccurrences(this string s, string f)
    {
        var indexes = new List<int>();
        int currentIndex = 0;
        try
        {
            while (currentIndex >= 0 && currentIndex < s.Length)
            {
                currentIndex = s.IndexOf(f, currentIndex);
                if (currentIndex >= 0)
                {
                    indexes.Add(currentIndex);
                    currentIndex++;
                }
            }
        }
        catch (ArgumentNullException e)
        {
            // Perform some action here, such as logging this exception.

            throw;
        }
        return indexes.ToArray();
    }
}
// </Snippet6>

// <Snippet7>
public class Example
{
    public static void Main()
    {
        string s = "It was a cold day when...";
        int[] indexes = s.FindOccurrences("a");
        ShowOccurrences(s, "a", indexes);
        Console.WriteLine();

        string toFind = null;
        try
        {
            indexes = s.FindOccurrences(toFind);
            ShowOccurrences(s, toFind, indexes);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine($"An exception ({e.GetType().Name}) occurred.");
            Console.WriteLine($"Message:\n   {e.Message}\n");
            Console.WriteLine($"Stack Trace:\n   {e.StackTrace}\n");
        }
    }

    private static void ShowOccurrences(string s, string toFind, int[] indexes)
    {
        Console.Write($"'{toFind}' occurs at the following character positions: ");
        for (int ctr = 0; ctr < indexes.Length; ctr++)
            Console.Write($"{indexes[ctr]}{(ctr == indexes.Length - 1 ? "" : ", ")}");

        Console.WriteLine();
    }
}
// The example displays the following output:
//    'a' occurs at the following character positions: 4, 7, 15
//
//    An exception (ArgumentNullException) occurred.
//    Message:
//       Value cannot be null.
//    Parameter name: value
//
//    Stack Trace:
//          at System.String.IndexOf(String value, Int32 startIndex, Int32 count, Stri
//    ngComparison comparisonType)
//       at Library.FindOccurrences(String s, String f)
//       at Example.Main()
// </Snippet7>
