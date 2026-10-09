// <Snippet2>
using System;

using System.IO;

public class Example
{
    public static void Main()
    {
        StreamWriter sw = new(@".\graphemes.txt");
        string grapheme = "\u0061\u0308";
        sw.WriteLine(grapheme);

        string singleChar = "\u00e4";
        sw.WriteLine(singleChar);

        sw.WriteLine($"{grapheme} = {singleChar} (Culture-sensitive): {string.Equals(grapheme, singleChar,
                                   StringComparison.CurrentCulture)}");
        sw.WriteLine($"{grapheme} = {singleChar} (Ordinal): {string.Equals(grapheme, singleChar,
                                   StringComparison.Ordinal)}");
        sw.WriteLine($"{grapheme} = {singleChar} (Normalized Ordinal): {string.Equals(grapheme.Normalize(),
                                   singleChar.Normalize(),
                                   StringComparison.Ordinal)}");
        sw.Close();
    }
}
// The example produces the following output:
//       ä
//       ä
//       ä = ä (Culture-sensitive): True
//       ä = ä (Ordinal): False
//       ä = ä (Normalized Ordinal): True
// </Snippet2>
