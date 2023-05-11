using System;
using System.Collections.Immutable;

static class ImmutableHashSetSnippets
{
    static void SnippetIterate()
    {
        // <SnippetIterate>
        // Create immutable set of strings
        ImmutableHashSet<string> colors = ImmutableHashSet.Create("Red", "Green", "Blue");

        // Iterate over all items in the set and print them
        Console.WriteLine("colors:");

        foreach (string s in colors)
        {
            Console.WriteLine(s);
        }

        // Try to add duplicate item into the set 
        ImmutableHashSet<string> colors2 = colors.Add("Red");
        Console.WriteLine("colors2:");

        // Print items in the new set
        foreach (string s in colors2)
        {
            Console.WriteLine(s);
        }

        /* Example output:
         colors:
         Red
         Blue
         Green
         colors2:
         Red
         Blue
         Green
         */
        // </SnippetIterate>
    }

    static void SnippetModify()
    {
        // <SnippetModify>
        // Create immutable set of strings
        ImmutableHashSet<string> colors = ImmutableHashSet.Create("Red", "Green", "Blue");

        // Create a new set by adding and removing items from the original set
        ImmutableHashSet<string> colorsModified = colors.Remove("Red").Add("Orange");

        foreach (string s in colorsModified)
        {
            Console.WriteLine(s);
        }

        /* Example output:
         Blue
         Green
         Orange
         */
        // </SnippetModify>
    }

    static void SnippetSetOperations()
    {
        // <SnippetSetOperations>
        // Create two sets of numbers
        ImmutableHashSet<int> evenNumbers = ImmutableHashSet<int>.Empty;
        ImmutableHashSet<int> oddNumbers = ImmutableHashSet<int>.Empty;

        for (int i = 0; i < 5; i++)
        {            
            evenNumbers = evenNumbers.Add(i * 2);
            oddNumbers = oddNumbers.Add((i * 2) + 1);
        }

        Console.Write("evenNumbers: ");

        foreach (int n in evenNumbers) Console.Write($"{n} ");
        
        Console.Write("\noddNumbers: ");

        foreach (int n in oddNumbers) Console.Write($"{n} ");

        // Create a new set that contains an intersection of two sets
        ImmutableHashSet<int> intersection = evenNumbers.Intersect(oddNumbers);
        Console.Write("\nintersection: ");

        foreach (int n in intersection) Console.Write($"{n} ");

        // Create a new set that contains a union of two sets
        ImmutableHashSet<int> union = evenNumbers.Union(oddNumbers);
        Console.Write("\nunion: ");

        foreach (int n in union) Console.Write($"{n} ");

        /* Example output:
         evenNumbers: 0 2 4 6 8
         oddNumbers: 1 3 5 7 9
         intersection:
         union: 0 1 2 3 4 5 6 7 8 9
         */
        // </SnippetSetOperations>
    }

    public static void Run()
    {
        SnippetIterate();
        SnippetModify();
        SnippetSetOperations();
    }
}
