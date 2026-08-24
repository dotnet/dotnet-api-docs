using System;
using System.Collections.Generic;

public class DictionaryInterfaceOverviewExample2
{
    public static void Run()
    {
        // Create a new dictionary of strings, with string keys.
        //
        Dictionary<int, string> exDictionary = new()
        {
            // Add some elements to the dictionary. There are no
            // duplicate keys, but some of the values are duplicates.
            { 0, "notepad.exe" },
            { 1, "paint.exe" },
            { 2, "paint.exe" },
            { 3, "wordpad.exe" }
        };
        IDictionary<int, string> myDictionary = exDictionary;
        // <Snippet11>
        foreach (KeyValuePair<int, string> kvp in myDictionary)
        {
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        }
        // </Snippet11>
    }
}
