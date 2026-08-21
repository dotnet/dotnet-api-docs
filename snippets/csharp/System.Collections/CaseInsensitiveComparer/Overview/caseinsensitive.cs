// The following code example creates a case-sensitive hashtable and a case-insensitive hashtable
// and demonstrates the difference in their behavior, even if both contain the same elements.

// <Snippet1>
using System;
using System.Collections;
using System.Globalization;

public class SamplesHashtable
{

    public static void Main()
    {

        // Create a Hashtable using the default hash code provider and the default comparer.
        Hashtable myHT1 = new()
        {
            { "FIRST", "Hello" },
            { "SECOND", "World" },
            { "THIRD", "!" }
        };

        // Create a Hashtable using a case-insensitive code provider and a case-insensitive comparer,
        // based on the culture of the current thread.
        Hashtable myHT2 = new(new CaseInsensitiveHashCodeProvider(), new CaseInsensitiveComparer())
        {
            { "FIRST", "Hello" },
            { "SECOND", "World" },
            { "THIRD", "!" }
        };

        // Create a Hashtable using a case-insensitive code provider and a case-insensitive comparer,
        // based on the InvariantCulture.
        Hashtable myHT3 = new(CaseInsensitiveHashCodeProvider.DefaultInvariant, CaseInsensitiveComparer.DefaultInvariant)
        {
            { "FIRST", "Hello" },
            { "SECOND", "World" },
            { "THIRD", "!" }
        };

        // Create a Hashtable using a case-insensitive code provider and a case-insensitive comparer,
        // based on the Turkish culture (tr-TR), where "I" is not the uppercase version of "i".
        CultureInfo myCul = new("tr-TR");
        Hashtable myHT4 = new(new CaseInsensitiveHashCodeProvider(myCul), new CaseInsensitiveComparer(myCul))
        {
            { "FIRST", "Hello" },
            { "SECOND", "World" },
            { "THIRD", "!" }
        };

        // Search for a key in each hashtable.
        Console.WriteLine($"first is in myHT1: {myHT1.ContainsKey("first")}");
        Console.WriteLine($"first is in myHT2: {myHT2.ContainsKey("first")}");
        Console.WriteLine($"first is in myHT3: {myHT3.ContainsKey("first")}");
        Console.WriteLine($"first is in myHT4: {myHT4.ContainsKey("first")}");
    }
}


/*
This code produces the following output.  Results vary depending on the system's culture settings.

first is in myHT1: False
first is in myHT2: True
first is in myHT3: True
first is in myHT4: False

*/

// </Snippet1>
