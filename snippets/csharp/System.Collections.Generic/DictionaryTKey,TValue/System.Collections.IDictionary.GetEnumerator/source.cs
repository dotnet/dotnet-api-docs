using System;
using System.Collections;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        // Create a new dictionary of strings, with string keys,
        // and access it using the IDictionary interface.
        //
        IDictionary openWith = new Dictionary<string, string>();

        // Add some elements to the dictionary. There are no
        // duplicate keys, but some of the values are duplicates.
        // IDictionary.Add throws an exception if incorrect types
        // are supplied for key or value.
        openWith.Add("txt", "notepad.exe");
        openWith.Add("bmp", "paint.exe");
        openWith.Add("dib", "paint.exe");
        openWith.Add("rtf", "wordpad.exe");

        // When you use foreach to enumerate dictionary elements
        // with the IDictionary interface, the elements are retrieved
        // as DictionaryEntry objects instead of KeyValuePair objects.
        foreach( DictionaryEntry de in openWith )
        {
            Console.WriteLine($"Key = {de.Key}, Value = {de.Value}");
        }
    }
}
