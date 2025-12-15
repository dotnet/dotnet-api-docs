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

        // To get the values alone, use the Values property.
        ICollection icoll = openWith.Values;

        // The elements of the collection are strongly typed
        // with the type that was specified for dictionary values,
        // even though the ICollection interface is not strongly
        // typed.
        Console.WriteLine();
        foreach( string s in icoll )
        {
            Console.WriteLine("Value = {0}", s);
        }

        // When you use foreach to enumerate dictionary elements
        // with the IDictionary interface, the elements are retrieved
        // as DictionaryEntry objects instead of KeyValuePair objects.
        Console.WriteLine();
        foreach( DictionaryEntry de in openWith )
        {
            Console.WriteLine("Key = {0}, Value = {1}",
                de.Key, de.Value);
        }
    }
}
