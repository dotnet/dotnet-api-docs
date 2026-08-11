// <Snippet15>
using System;

public class Example1
{
    public static void Main()
    {
        string[] words = { "the", "today", "tomorrow", " ", "" };
        foreach (string word in words)
            Console.WriteLine($"First character of '{word}': '{GetFirstCharacter(word)}'");
    }

    private static char GetFirstCharacter(string s) => s[0];
}
// The example displays the following output:
//    First character of //the//: //t//
//    First character of //today//: //t//
//    First character of //tomorrow//: //t//
//    First character of // //: // //
//
//    Unhandled Exception: System.IndexOutOfRangeException: Index was outside the bounds of the array.
//       at Example.Main()
// </Snippet15>

public static class StringLib
{
    // <Snippet16>
    static char GetFirstCharacter(string s)
    {
        if (string.IsNullOrEmpty(s))
            return '\u0000';
        else
            return s[0];
    }
    // </Snippet16>

    public static char DoNothing(string s) => GetFirstCharacter(s);
}
