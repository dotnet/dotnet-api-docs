using System;

public class SubstringRangeExample
{
    public static void Run()
    {
        // <Snippet2>
        string s = "aaaaabbbcccccccdd";
        char charRange = 'b';
        int startIndex = s.IndexOf(charRange);
        int endIndex = s.LastIndexOf(charRange);
        int length = endIndex - startIndex + 1;
        Console.WriteLine($"{s}.Substring({startIndex}, {length}) = {s.Substring(startIndex, length)}");

        // The example displays the following output:
        //       aaaaabbbcccccccdd.Substring(5, 3) = bbb
        // </Snippet2>
    }
}
