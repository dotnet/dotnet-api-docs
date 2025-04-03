using System;
using System.Collections.Generic;
using System.Globalization;

public class StringSort
{
    public static void Run()
    {
        var wordList = new List<string>
        {
            "cant", "bill's", "coop", "cannot", "billet", "can't", "con", "bills", "co-op"
        };

        Console.WriteLine("Before sorting:");
        foreach (string word in wordList)
        {
            Console.WriteLine(word);
        }

        Console.WriteLine(Environment.NewLine + "After sorting with CompareOptions.None:");
        SortAndDisplay(wordList, CompareOptions.None);

        Console.WriteLine(Environment.NewLine + "After sorting with CompareOptions.StringSort:");
        SortAndDisplay(wordList, CompareOptions.StringSort);
    }

    // Sort the list of words with the supplied CompareOptions.
    private static void SortAndDisplay(List<string> unsorted, CompareOptions options)
    {
        // Create a copy of the original list to sort.
        var words = new List<string>(unsorted);
        // Define the CompareInfo to use to compare strings.
        CompareInfo comparer = CultureInfo.InvariantCulture.CompareInfo;

        // Sort the copy with the supplied CompareOptions then display.
        words.Sort((str1, str2) => comparer.Compare(str1, str2, options));
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}

/*
CompareOptions.None and CompareOptions.StringSort provide identical ordering by default
in .NET 5 and later. But in prior versions, the output is the following:

Before sorting:
cant
bill's
coop
cannot
billet
can't
con
bills
co-op

After sorting with CompareOptions.None:
billet
bills
bill's
cannot
cant
can't
con
coop
co-op

After sorting with CompareOptions.StringSort:
bill's
billet
bills
can't
cannot
cant
co-op
con
coop
*/
