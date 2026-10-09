// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        string[] names = { "Adam", "Adel", "Bridgette", "Carla",
                         "Charles", "Daniel", "Elaine", "Frances",
                         "George", "Gillian", "Henry", "Irving",
                         "James", "Janae", "Lawrence", "Miguel",
                         "Nicole", "Oliver", "Paula", "Robert",
                         "Stephen", "Thomas", "Vanessa",
                         "Veronica", "Wilberforce" };
        char[] charsToFind = { 'A', 'K', 'W', 'Z' };

        foreach (char charToFind in charsToFind)
            Console.WriteLine($"One or more names begin with '{charToFind}': {Array.Exists(names, (new StringSearcher(charToFind)).StartsWith)}");
    }
}

public class StringSearcher
{
    char firstChar;

    public StringSearcher(char firstChar) => this.firstChar = char.ToUpper(firstChar);

    public bool StartsWith(string s)
    {
        if (string.IsNullOrEmpty(s)) return false;

        if (s.Substring(0, 1).ToUpper() == firstChar.ToString())
            return true;
        else
            return false;
    }
}
// The example displays the following output:
//       One or more names begin with 'A': True
//       One or more names begin with 'K': False
//       One or more names begin with 'W': True
//       One or more names begin with 'Z': False
// </Snippet1>
