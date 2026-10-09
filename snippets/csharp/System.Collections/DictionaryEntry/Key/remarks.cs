using System;
using System.Collections;

public class SimpleDictionaryBase : DictionaryBase
{
}

public class DictionaySamples
{
    public static void Run()
    {
        // Create a dictionary that contains no more than three entries.
        IDictionary myDictionary = new SimpleDictionaryBase();

        // Add three people and their ages to the dictionary.
        myDictionary.Add("Jeff", 40);
        myDictionary.Add("Kristin", 34);
        myDictionary.Add("Aidan", 1);
        // Display every entry's key and value.
        foreach (DictionaryEntry de in myDictionary)
        {
            Console.WriteLine($"{de.Key} is {de.Value} years old.");
        }

        // Remove an entry that exists.
        myDictionary.Remove("Jeff");

        // Remove an entry that does not exist, but do not throw an exception.
        myDictionary.Remove("Max");

        // <Snippet14>
        foreach (DictionaryEntry de in myDictionary)
        {
            //...
        }
        // </Snippet14>
    }
}
