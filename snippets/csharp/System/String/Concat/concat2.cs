// <Snippet3>
using System;
using System.Collections.Generic;
using System.Linq;

public class ConcatAlphabetExample
{
    public static void Run()
    {
        string output = string.Concat(GetAlphabet(true).Where(letter =>
                        letter.CompareTo("M") >= 0));
        Console.WriteLine(output);
    }

    private static List<string> GetAlphabet(bool upper)
    {
        List<string> alphabet = new();
        int charValue = upper ? 65 : 97;
        for (int ctr = 0; ctr <= 25; ctr++)
            alphabet.Add(((char)(charValue + ctr)).ToString());
        return alphabet;
    }
}
// The example displays the following output:
//      MNOPQRSTUVWXYZ
// </Snippet3>
