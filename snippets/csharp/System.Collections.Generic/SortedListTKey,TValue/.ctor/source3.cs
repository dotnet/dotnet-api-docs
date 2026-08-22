//<Snippet1>
using System;
using System.Collections.Generic;

public class SortedListConstructorExample4
{
    public static void Run()
    {
        // Create a new sorted list of strings, with string keys and
        // an initial capacity of 4.
        SortedList<string, string> openWith =
                               new SortedList<string, string>(4)
                               {
                                   // Add 4 elements to the list.
                                   { "txt", "notepad.exe" },
                                   { "bmp", "paint.exe" },
                                   { "dib", "paint.exe" },
                                   { "rtf", "wordpad.exe" }
                               };

        // List the contents of the sorted list.
        Console.WriteLine();
        foreach (KeyValuePair<string, string> kvp in openWith)
        {
            Console.WriteLine("Key = {0}, Value = {1}",
               kvp.Key, kvp.Value);
        }
    }
}

/* This code example produces the following output:

Key = bmp, Value = paint.exe
Key = dib, Value = paint.exe
Key = rtf, Value = wordpad.exe
Key = txt, Value = notepad.exe
 */
//</Snippet1>
