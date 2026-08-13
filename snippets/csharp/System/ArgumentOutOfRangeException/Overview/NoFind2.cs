// <Snippet18>
using System;

public class Example18
{
    public static void Main()
    {
        string[] phrases = { "ocean blue", "concerned citizen",
                           "runOnPhrase" };
        foreach (string phrase in phrases)
        {
            string word = GetSecondWord(phrase);
            if (!string.IsNullOrEmpty(word))
                Console.WriteLine($"Second word is {word}");
        }
    }

    static string GetSecondWord(string s)
    {
        int pos = s.IndexOf(" ");
        if (pos >= 0)
            return s.Substring(pos).Trim();
        else
            return string.Empty;
    }
}
// The example displays the following output:
//       Second word is blue
//       Second word is citizen
// </Snippet18>
