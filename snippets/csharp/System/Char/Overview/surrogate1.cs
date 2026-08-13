// <Snippet2>
using System;
using System.IO;

public class Example3
{
    public static void Main()
    {
        StreamWriter sw = new(@".\chars2.txt");
        int utf32 = 0x1D160;
        string surrogate = char.ConvertFromUtf32(utf32);
        sw.WriteLine($"U+{utf32:X6} UTF-32 = {surrogate} ({ShowCodePoints(surrogate)}) UTF-16");
        sw.Close();
    }

    private static string ShowCodePoints(string value)
    {
        string retval = null;
        foreach (char ch in value)
            retval += $"U+{Convert.ToUInt16(ch):X4} ";

        return retval.Trim();
    }
}
// The example produces the following output:
//       U+01D160 UTF-32 = ð (U+D834 U+DD60) UTF-16
// </Snippet2>
