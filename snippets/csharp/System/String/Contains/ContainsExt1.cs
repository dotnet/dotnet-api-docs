// <Snippet1>
using System;

public static class StringExtensions
{
    public static bool Contains(this string str, string substring,
                                StringComparison comp)
    {
        if (substring == null)
            throw new ArgumentNullException("substring",
                                         "substring cannot be null.");
        else if (!Enum.IsDefined(typeof(StringComparison), comp))
            throw new ArgumentException("comp is not a member of StringComparison",
                                     "comp");

        return str.IndexOf(substring, comp) >= 0;
    }
}
// </Snippet1>

namespace App
{
    using System;

    public class Example
    {
        public static void Main()
        {
            // <Snippet2>
            string s = "This is a string.";
            string sub1 = "this";
            Console.WriteLine($"Does '{s}' contain '{sub1}'?");
            StringComparison comp = StringComparison.Ordinal;
            Console.WriteLine($"   {comp:G}: {s.Contains(sub1, comp)}");

            comp = StringComparison.OrdinalIgnoreCase;
            Console.WriteLine($"   {comp:G}: {s.Contains(sub1, comp)}");

            // The example displays the following output:
            //       Does 'This is a string.' contain 'this'?
            //          Ordinal: False
            //          OrdinalIgnoreCase: True
            // </Snippet2>
        }
    }
}
