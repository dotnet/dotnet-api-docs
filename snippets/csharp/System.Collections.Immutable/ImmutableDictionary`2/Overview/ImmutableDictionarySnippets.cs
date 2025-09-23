using System;
using System.Collections.Generic;
using System.Collections.Immutable;

static class ImmutableDictionarySnippets
{
    static void SnippetGetValues()
    {
        // <SnippetGetValues>
        // Create an immutable dictionary that maps string values to string keys
        ImmutableDictionary<string,string> mimeTypes = ImmutableDictionary.CreateRange(
            new KeyValuePair<string,string>[] {
                KeyValuePair.Create("txt", "text/plain"),
                KeyValuePair.Create("html", "text/html"),
                KeyValuePair.Create("htm", "text/html"),
                KeyValuePair.Create("jpg", "image/jpeg")
            });

        // Query values by keys
        string? val;

        if (mimeTypes.TryGetValue("txt", out val)) Console.WriteLine($"txt is mapped to {val}");
        else Console.WriteLine($"txt key is not found");

        if (mimeTypes.TryGetValue("png", out val)) Console.WriteLine($"png is mapped to {val}");
        else Console.WriteLine($"png key is not found");

        // Iterate over all values in the dictionary
        foreach (string key in mimeTypes.Keys)
        {
            Console.WriteLine($"{key}: {mimeTypes[key]}");
        }

        /* Example output:
         txt is mapped to text/plain
         png key is not found
         html: text/html
         jpg: image/jpeg
         txt: text/plain
         htm: text/html
         */
        // </SnippetGetValues>
    }

    static void SnippetModify()
    {
        // <SnippetModify>
        // Create an immutable dictionary that maps string values to string keys
        ImmutableDictionary<string, string> mimeTypes = ImmutableDictionary.CreateRange(
            new KeyValuePair<string, string>[] {
                KeyValuePair.Create("txt", "text/plain"),
                KeyValuePair.Create("html", "text/html"),
                KeyValuePair.Create("htm", "text/html"),
                KeyValuePair.Create("jpg", "image/jpeg")
            });

        // Create a new dictionary by adding and removing values from the original dictionary
        ImmutableDictionary<string, string> modified = mimeTypes.Remove("htm").Add("png", "image/png");
        
        foreach (string key in modified.Keys)
        {
            Console.WriteLine($"{key}: {modified[key]}");
        }

        /* Example output:
         png: image/png
         txt: text/plain
         html: text/html
         jpg: image/jpeg
         */
        // </SnippetModify>
    }

    public static void Run()
    {
        SnippetGetValues();
        SnippetModify();
    }
}
