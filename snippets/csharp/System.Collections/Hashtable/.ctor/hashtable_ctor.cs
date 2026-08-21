// The following code example creates hash tables using different Hashtable
// constructors and demonstrates the differences in the behavior of the hash
// tables, even if each one contains the same elements.

// <Snippet1>
using System;
using System.Collections;
using System.Globalization;

class DefaultEqualityComparer : IEqualityComparer
{
    public new bool Equals(object x, object y) => x.Equals(y);

    public int GetHashCode(object obj) => obj.ToString().ToLower().GetHashCode();
}

// <Snippet2>
class CultureEqualityComparer : IEqualityComparer
{
    public CaseInsensitiveComparer myComparer;

    public CultureEqualityComparer() => myComparer = CaseInsensitiveComparer.DefaultInvariant;

    public CultureEqualityComparer(CultureInfo myCulture) => myComparer = new(myCulture);

    public new bool Equals(object x, object y) => myComparer.Compare(x, y) == 0;

    public int GetHashCode(object obj) => obj.ToString().ToLower().GetHashCode();
}
// </Snippet2>

public class SamplesHashtableDefault
{

    public static void Run()
    {

        // Create a hash table using the default comparer.
        Hashtable myHT1 = new Hashtable()
        {
            { "FIRST", "Hello" },
            { "SECOND", "World" },
            { "THIRD", "!" }
        };

        // Create a hash table using the specified IEqualityComparer that uses
        // the default Object.Equals to determine equality.
        Hashtable myHT2 = new Hashtable(new DefaultEqualityComparer())
        {
            { "FIRST", "Hello" },
            { "SECOND", "World" },
            { "THIRD", "!" }
        };

        // Create a hash table using a case-insensitive hash code provider and
        // case-insensitive comparer based on the InvariantCulture.
        Hashtable myHT3 = new Hashtable(
            CaseInsensitiveHashCodeProvider.DefaultInvariant,
            CaseInsensitiveComparer.DefaultInvariant)
        {
            { "FIRST", "Hello" },
            { "SECOND", "World" },
            { "THIRD", "!" }
        };

        // Create a hash table using an IEqualityComparer that is based on
        // the Turkish culture (tr-TR) where "I" is not the uppercase
        // version of "i".
        CultureInfo myCul = new("tr-TR");
        Hashtable myHT4 = new Hashtable(new CultureEqualityComparer(myCul))
        {
            { "FIRST", "Hello" },
            { "SECOND", "World" },
            { "THIRD", "!" }
        };

        // Search for a key in each hash table.
        Console.WriteLine($"first is in myHT1: {myHT1.ContainsKey("first")}");
        Console.WriteLine($"first is in myHT2: {myHT2.ContainsKey("first")}");
        Console.WriteLine($"first is in myHT3: {myHT3.ContainsKey("first")}");
        Console.WriteLine($"first is in myHT4: {myHT4.ContainsKey("first")}");
    }
}


/*
This code produces the following output.
Results vary depending on the system's culture settings.

first is in myHT1: False
first is in myHT2: False
first is in myHT3: True
first is in myHT4: False

*/

// </Snippet1>
