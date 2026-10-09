using System;

public class SubstringMarkupExample
{
    public static void Run()
    {
        // <Snippet3>
        string s = "<term>extant<definition>still in existence</definition></term>";
        string searchString = "<definition>";
        int startIndex = s.IndexOf(searchString);
        searchString = "</" + searchString.Substring(1);
        int endIndex = s.IndexOf(searchString);
        string substring = s.Substring(startIndex, endIndex + searchString.Length - startIndex);
        Console.WriteLine($"Original string: {s}");
        Console.WriteLine($"Substring;       {substring}");

        // The example displays the following output:
        //     Original string: <term>extant<definition>still in existence</definition></term>
        //     Substring;       <definition>still in existence</definition>
        // </Snippet3>
    }
}
