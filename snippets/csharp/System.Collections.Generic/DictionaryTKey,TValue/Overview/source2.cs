using System;
using System.Collections.Generic;

public class DictionaryOverviewExample2
{
    public static void Run()
    {
        // Create a new dictionary of strings, with string keys.
        //
        Dictionary<string, string> myDictionary =
            new()
            {
                // Add some elements to the dictionary. There are no
                // duplicate keys, but some of the values are duplicates.
                { "txt", "notepad.exe" },
                { "bmp", "paint.exe" },
                { "dib", "paint.exe" },
                { "rtf", "wordpad.exe" }
            };

        //<Snippet11>
        foreach (KeyValuePair<string, string> kvp in myDictionary)
        {
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        }
        //</Snippet11>
    }
}
