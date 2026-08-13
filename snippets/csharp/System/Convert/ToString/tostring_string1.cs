// <Snippet2>
using System;

public class Example
{
    public static void Main()
    {
        string article = "An";
        string noun = "apple";
        string str1 = $"{article} {noun}";
        string str2 = Convert.ToString(str1);

        Console.WriteLine($"str1 is interned: {!(string.IsInterned(str1) == null)}");
        Console.WriteLine($"str1 and str2 are the same reference: {object.ReferenceEquals(str1, str2)}");
    }
}
// The example displays the following output:
//       str1 is interned: False
//       str1 and str2 are the same reference: True
// </Snippet2>
