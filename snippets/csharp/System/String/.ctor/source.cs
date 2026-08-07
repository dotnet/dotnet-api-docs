using System;
using System.Text;

namespace Microsoft.Demo
{
    class ConsoleApp
    {
        [STAThread]
        static void Main(string[] args)
        {
            //<snippet1>
            // Unicode Mathematical operators
            char[] charArr1 = { '\u2200', '\u2202', '\u200F', '\u2205' };
            string szMathSymbols = new(charArr1);

            // Unicode Letterlike Symbols
            char[] charArr2 = { '\u2111', '\u2118', '\u2122', '\u2126' };
            string szLetterLike = new(charArr2);

            // Compare Strings - the result is false
            Console.WriteLine("The Strings are equal? " +
                (string.Compare(szMathSymbols, szLetterLike) == 0 ? "true" : "false"));
            //</snippet1>
            //<snippet2>
            unsafe
            {
                // Null terminated ASCII characters in an sbyte array
                string szAsciiUpper = null;
                sbyte[] sbArr1 = new sbyte[] { 0x41, 0x42, 0x43, 0x00 };
                // Instruct the Garbage Collector not to move the memory
                fixed (sbyte* pAsciiUpper = sbArr1)
                {
                    szAsciiUpper = new(pAsciiUpper);
                }
                string szAsciiLower = null;
                sbyte[] sbArr2 = { 0x61, 0x62, 0x63, 0x00 };
                // Instruct the Garbage Collector not to move the memory
                fixed (sbyte* pAsciiLower = sbArr2)
                {
                    szAsciiLower = new(pAsciiLower, 0, sbArr2.Length);
                }
                // Prints "ABC abc"
                Console.WriteLine(szAsciiUpper + " " + szAsciiLower);

                // Compare Strings - the result is true
                Console.WriteLine("The Strings are equal when capitalized ? " +
                    (string.Compare(szAsciiUpper.ToUpper(), szAsciiLower.ToUpper()) == 0 ? "true" : "false"));

                // This is the effective equivalent of another Compare method, which ignores case
                Console.WriteLine("The Strings are equal when capitalized ? " +
                    (string.Compare(szAsciiUpper, szAsciiLower, true) == 0 ? "true" : "false"));
            }
            //</snippet2>
            //<snippet3>
            // Create a Unicode String with 5 Greek Alpha characters
            string szGreekAlpha = new('\u0391', 5);
            // Create a Unicode String with a Greek Omega character
            string szGreekOmega = new(new char[] { '\u03A9', '\u03A9', '\u03A9' }, 2, 1);

            string szGreekLetters = string.Concat(szGreekOmega, szGreekAlpha, szGreekOmega.Clone());

            // Examine the result
            Console.WriteLine(szGreekLetters);

            // The first index of Alpha
            int ialpha = szGreekLetters.IndexOf('\u0391');
            // The last index of Omega
            int iomega = szGreekLetters.LastIndexOf('\u03A9');

            Console.WriteLine("The Greek letter Alpha first appears at index " + ialpha +
                " and Omega last appears at index " + iomega + " in this String.");
            //</snippet3>

            //<snippet4>
            unsafe
            {
                string utfeightstring = null;
                sbyte[] asciiChars = new sbyte[] { 0x51, 0x52, 0x53, 0x54, 0x54, 0x56 };
                UTF8Encoding encoding = new(true, true);

                // Instruct the Garbage Collector not to move the memory
                fixed (sbyte* pAsciiChars = asciiChars)
                {
                    utfeightstring = new(pAsciiChars, 0, asciiChars.Length, encoding);
                }
                Console.WriteLine("The UTF8 String is " + utfeightstring); // prints "QRSTTV"
            }
            //</snippet4>
        }
    }
}
