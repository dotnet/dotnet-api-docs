//<Snippet1>
using System;
using System.Collections.Generic;

public class SortedListConstructorExample1
{
    public static void Run()
    {
        // Create a new sorted list of strings, with string keys and
        // a case-insensitive comparer for the current culture.
        SortedList<string, string> openWith =
                      new SortedList<string, string>(
                          StringComparer.CurrentCultureIgnoreCase)
                      {
                          // Add some elements to the list.
                          { "txt", "notepad.exe" },
                          { "bmp", "paint.exe" },
                          { "DIB", "paint.exe" },
                          { "rtf", "wordpad.exe" }
                      };

        // Try to add a fifth element with a key that is the same
        // except for case; this would be allowed with the default
        // comparer.
        try
        {
            openWith.Add("BMP", "paint.exe");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("\nBMP is already in the sorted list.");
        }

        // List the contents of the sorted list.
        Console.WriteLine();
        foreach (KeyValuePair<string, string> kvp in openWith)
        {
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key,
                kvp.Value);
        }
    }
}

/* This code example produces the following output:

BMP is already in the sorted list.

Key = bmp, Value = paint.exe
Key = DIB, Value = paint.exe
Key = rtf, Value = wordpad.exe
Key = txt, Value = notepad.exe
 */
//</Snippet1>
