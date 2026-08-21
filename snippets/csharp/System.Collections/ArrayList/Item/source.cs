//<Snippet1>
using System;
using System.Collections;

public class Example
{
    public static void Run()
    {
        // Create an empty ArrayList, and add some elements.
        ArrayList stringList = ["a", "abc", "abcdef", "abcdefg"];

        // The Item property is an indexer, so the property name is
        // not required.
        Console.WriteLine($"Element {2} is \"{stringList[2]}\"");

        // Assigning a value to the property changes the value of
        // the indexed element.
        stringList[2] = "abcd";
        Console.WriteLine($"Element {2} is \"{stringList[2]}\"");

        // Accessing an element outside the current element count
        // causes an exception.
        Console.WriteLine($"Number of elements in the list: {stringList.Count}");
        try
        {
            Console.WriteLine($"Element {stringList.Count} is \"{stringList[stringList.Count]}\"");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine($"stringList({stringList.Count}) is out of range.");
        }

        // You cannot use the Item property to add new elements.
        try
        {
            stringList[stringList.Count] = "42";
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine($"stringList({stringList.Count}) is out of range.");
        }

        Console.WriteLine();
        for (int i = 0; i < stringList.Count; i++)
        {
            Console.WriteLine($"Element {i} is \"{stringList[i]}\"");
        }

        Console.WriteLine();
        foreach (object o in stringList)
        {
            Console.WriteLine(o);
        }
    }
}
/*
 This code example produces the following output:

Element 2 is "abcdef"
Element 2 is "abcd"
Number of elements in the list: 4
stringList(4) is out of range.
stringList(4) is out of range.

Element 0 is "a"
Element 1 is "abc"
Element 2 is "abcd"
Element 3 is "abcdefg"

a
abc
abcd
abcdefg
 */
//</Snippet1>
