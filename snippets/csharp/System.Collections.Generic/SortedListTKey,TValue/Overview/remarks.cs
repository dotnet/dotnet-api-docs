using System;
using System.Collections.Generic;

public class SortedListOverviewExample1
{
    public static void Run()
    {
        // Create a new sorted list of strings, with string
        // keys.
        SortedList<int, string> mySortedList =
            new()
            {
                // Add some elements to the list. There are no
                // duplicate keys, but some of the values are duplicates.
                { 0, "notepad.exe" },
                { 1, "paint.exe" },
                { 2, "paint.exe" },
                { 3, "wordpad.exe" }
            };

        //<Snippet11>
        string v = mySortedList.Values[3];
        //</Snippet11>

        Console.WriteLine("Value at index 3: {0}", v);

        //<Snippet12>
        foreach (KeyValuePair<int, string> kvp in mySortedList)
        {
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        }
        //</Snippet12>
    }
}
