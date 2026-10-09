//<Snippet1>
using System;
using System.Collections.Generic;

public class DictionaryConstructorExample2
{
    public static void Run()
    {
        // Create a new sorted dictionary of strings, with string
        // keys and a case-insensitive comparer.
        SortedDictionary<string, string> openWith =
                new SortedDictionary<string, string>(
                    StringComparer.CurrentCultureIgnoreCase)
                {
                    // Add some elements to the dictionary.
                    { "txt", "notepad.exe" },
                    { "Bmp", "paint.exe" },
                    { "DIB", "paint.exe" },
                    { "rtf", "wordpad.exe" }
                };

        // Create a Dictionary of strings with string keys and a
        // case-insensitive equality comparer, and initialize it
        // with the contents of the sorted dictionary.
        Dictionary<string, string> copy =
                new Dictionary<string, string>(openWith,
                    StringComparer.CurrentCultureIgnoreCase);

        // List the contents of the copy.
        Console.WriteLine();
        foreach (KeyValuePair<string, string> kvp in copy)
        {
            Console.WriteLine("Key = {0}, Value = {1}",
               kvp.Key, kvp.Value);
        }
    }
}

/* This code example produces the following output:

Key = Bmp, Value = paint.exe
Key = DIB, Value = paint.exe
Key = rtf, Value = wordpad.exe
Key = txt, Value = notepad.exe
 */
//</Snippet1>
