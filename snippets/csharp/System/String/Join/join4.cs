// <Snippet4>
using System;
using System.Collections.Generic;
using System.Linq;

public class JoinAlphabetExample
{
    public static void Run()
    {
        string output = string.Join(" ", GetAlphabet(true).Where(letter =>
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
//      M N O P Q R S T U V W X Y Z
// </Snippet4>
