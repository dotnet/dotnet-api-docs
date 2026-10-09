// <Snippet5>
using System;
using System.Collections.Generic;
using System.Linq;

public class Func3Example
{
    public static void Main()
    {
        Func<string, int, bool> predicate = (str, index) => str.Length == index;

        string[] words = { "orange", "apple", "Article", "elephant", "star", "and" };
        IEnumerable<string> aWords = words.Where(predicate).Select(str => str);

        foreach (string word in aWords)
            Console.WriteLine(word);
    }
}
// </Snippet5>
