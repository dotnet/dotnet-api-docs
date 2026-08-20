// The following code example creates hash tables using different Hashtable
// constructors and demonstrates the differences in the behavior of the hash
// tables, even if each one contains the same elements.

// <Snippet1>
using System;
using System.Collections;
using System.Globalization;

class CapacityLoadFactorCultureEqualityComparer : IEqualityComparer
{
    public CaseInsensitiveComparer myComparer;

    public CapacityLoadFactorCultureEqualityComparer() => myComparer = CaseInsensitiveComparer.DefaultInvariant;

    public CapacityLoadFactorCultureEqualityComparer(CultureInfo myCulture) => myComparer = new(myCulture);

    public new bool Equals(object x, object y)
    {
        if (myComparer.Compare(x, y) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetHashCode(object obj) =>
        // Compare the hash code for the lowercase versions of the strings.
        obj.ToString().ToLower().GetHashCode();
}

public class SamplesHashtableCapacityLoadFactor
{

    public static void Run()
    {

        // Create a hash table using the default comparer.
        Hashtable myHT1 = new Hashtable(3, .8f)
        {
            { "FIRST", "Hello" },
            { "SECOND", "World" },
            { "THIRD", "!" }
        };

        // Create a hash table using the specified IEqualityComparer that uses
        // the CaseInsensitiveComparer.DefaultInvariant to determine equality.
        Hashtable myHT2 = new Hashtable(3, .8f, new CapacityLoadFactorCultureEqualityComparer())
        {
            { "FIRST", "Hello" },
            { "SECOND", "World" },
            { "THIRD", "!" }
        };

        // Create a hash table using an IEqualityComparer that is based on
        // the Turkish culture (tr-TR) where "I" is not the uppercase
        // version of "i".
        CultureInfo myCul = new("tr-TR");
        Hashtable myHT3 = new Hashtable(3, .8f, new CapacityLoadFactorCultureEqualityComparer(myCul))
        {
            { "FIRST", "Hello" },
            { "SECOND", "World" },
            { "THIRD", "!" }
        };

        // Search for a key in each hash table.
        Console.WriteLine($"first is in myHT1: {myHT1.ContainsKey("first")}");
        Console.WriteLine($"first is in myHT2: {myHT2.ContainsKey("first")}");
        Console.WriteLine($"first is in myHT3: {myHT3.ContainsKey("first")}");
    }
}


/*
This code produces the following output.
Results vary depending on the system's culture settings.

first is in myHT1: False
first is in myHT2: True
first is in myHT3: False

*/

// </Snippet1>
