using System;
using System.Collections;

public class Remarks
{
    public static void Run()
    {
        // Create a new hash table.
        //
        Hashtable myHashtable = new()
        {
            // Add some elements to the hash table. There are no
            // duplicate keys, but some of the values are duplicates.
            { "txt", "notepad.exe" },
            { "bmp", "paint.exe" },
            { "dib", "paint.exe" },
            { "rtf", "wordpad.exe" }
        };

        // When you use foreach to enumerate hash table elements,
        // the elements are retrieved as KeyValuePair objects.
        // <snippet01>
        foreach (DictionaryEntry de in myHashtable)
        {
            // ...
        }
        // </snippet01>
    }
}
