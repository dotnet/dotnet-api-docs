﻿// The following code example creates hash tables using different Hashtable
// constructors and demonstrates the differences in the behavior of the hash
// tables, even if each one contains the same elements.

// <Snippet1>
using System;
using System.Collections;
using System.Globalization;

class myComparer : IEqualityComparer
{
    public new bool Equals(object x, object y)
    {
        return x.Equals(y);
    }

    public int GetHashCode(object obj)
    {
        return obj.ToString().ToLower().GetHashCode();
    }
}

// <Snippet2>
class myCultureComparer : IEqualityComparer
{
    public CaseInsensitiveComparer myComparer;

    public myCultureComparer()
    {
        myComparer = CaseInsensitiveComparer.DefaultInvariant;
    }

    public myCultureComparer(CultureInfo myCulture)
    {
        myComparer = new CaseInsensitiveComparer(myCulture);
    }

    public new bool Equals(object x, object y)
    {
        return myComparer.Compare(x, y) == 0;
    }

    public int GetHashCode(object obj)
    {
        return obj.ToString().ToLower().GetHashCode();
    }
}
// </Snippet2>

public class SamplesHashtable
{

    public static void Main()
    {

        // Create a hash table using the default comparer.
        var myHT1 = new Hashtable();
        myHT1.Add("FIRST", "Hello");
        myHT1.Add("SECOND", "World");
        myHT1.Add("THIRD", "!");

        // Create a hash table using the specified IEqualityComparer that uses
        // the default Object.Equals to determine equality.
        var myHT2 = new Hashtable(new myComparer());
        myHT2.Add("FIRST", "Hello");
        myHT2.Add("SECOND", "World");
        myHT2.Add("THIRD", "!");

        // Create a hash table using a case-insensitive hash code provider and
        // case-insensitive comparer based on the InvariantCulture.
        Hashtable myHT3 = new Hashtable(
            CaseInsensitiveHashCodeProvider.DefaultInvariant,
            CaseInsensitiveComparer.DefaultInvariant);
        myHT3.Add("FIRST", "Hello");
        myHT3.Add("SECOND", "World");
        myHT3.Add("THIRD", "!");

        // Create a hash table using an IEqualityComparer that is based on
        // the Turkish culture (tr-TR) where "I" is not the uppercase
        // version of "i".
        var myCul = new CultureInfo("tr-TR");
        var myHT4 = new Hashtable(new myCultureComparer(myCul));
        myHT4.Add("FIRST", "Hello");
        myHT4.Add("SECOND", "World");
        myHT4.Add("THIRD", "!");

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
