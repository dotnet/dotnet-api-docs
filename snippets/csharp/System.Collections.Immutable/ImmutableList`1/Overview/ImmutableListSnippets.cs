using System;
using System.Collections.Immutable;

static class ImmutableListSnippets
{
    static void SnippetIterate()
    {
        // <SnippetIterate>
        // Create an immutable list of strings
        ImmutableList<string> colors = ImmutableList.Create("Red", "Green", "Blue");

        // Iterate over all items in the list and print them
        foreach (string s in colors)
        {
            Console.WriteLine(s);
        }

        /* Example output:
         Red
         Green
         Blue
         */
        // </SnippetIterate>
    }

    static void SnippetModify()
    {
        // <SnippetModify>
        // Create an immutable list of strings
        ImmutableList<string> colors = ImmutableList.Create("Red", "Green", "Blue");

        // Create a new immutable list by adding and removing items from the original list
        ImmutableList<string> colorsModified = colors.RemoveAt(1).Add("Orange");

        foreach (string s in colorsModified)
        {
            Console.WriteLine(s);
        }

        /* Example output:
         Red
         Blue
         Orange
         */
        // </SnippetModify>
    }

    public static void Run()
    {
        SnippetIterate();
        SnippetModify();
    }
}

