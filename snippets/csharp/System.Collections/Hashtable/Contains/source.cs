// <Snippet1>
using System;
using System.Collections;
public class SamplesHashtable
{

    public static void Main()
    {
        // Creates and initializes a new Hashtable.
        Hashtable myHT = new()
        {
            { 0, "zero" },
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" }
        };

        // Displays the values of the Hashtable.
        Console.WriteLine("The Hashtable contains the following values:");
        PrintIndexAndKeysAndValues(myHT);

        // Searches for a specific key.
        int myKey = 2;
        Console.WriteLine($"The key \"{myKey}\" is {(myHT.ContainsKey(myKey) ? "in the Hashtable" : "NOT in the Hashtable")}.");
        myKey = 6;
        Console.WriteLine($"The key \"{myKey}\" is {(myHT.ContainsKey(myKey) ? "in the Hashtable" : "NOT in the Hashtable")}.");

        // Searches for a specific value.
        string myValue = "three";
        Console.WriteLine($"The value \"{myValue}\" is {(myHT.ContainsValue(myValue) ? "in the Hashtable" : "NOT in the Hashtable")}.");
        myValue = "nine";
        Console.WriteLine($"The value \"{myValue}\" is {(myHT.ContainsValue(myValue) ? "in the Hashtable" : "NOT in the Hashtable")}.");
    }

    public static void PrintIndexAndKeysAndValues(Hashtable myHT)
    {
        int i = 0;
        Console.WriteLine("\t-INDEX-\t-KEY-\t-VALUE-");
        foreach (DictionaryEntry de in myHT)
        {
            Console.WriteLine($"\t[{i++}]:\t{de.Key}\t{de.Value}");
        }

        Console.WriteLine();
    }
}


/*
This code produces the following output.

The Hashtable contains the following values:
        -INDEX- -KEY-   -VALUE-
        [0]:    4       four
        [1]:    3       three
        [2]:    2       two
        [3]:    1       one
        [4]:    0       zero

The key "2" is in the Hashtable.
The key "6" is NOT in the Hashtable.
The value "three" is in the Hashtable.
The value "nine" is NOT in the Hashtable.

*/
// </Snippet1>
