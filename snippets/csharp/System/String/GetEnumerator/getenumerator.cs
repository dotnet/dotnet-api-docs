//<snippet1>
using System;

class Example
{
    public static void Main()
    {
        EnumerateAndDisplay("Test Case");
        EnumerateAndDisplay("This is a sentence.");
        EnumerateAndDisplay("Has\ttwo\ttabs");
        EnumerateAndDisplay("Two\nnew\nlines");
    }

    static void EnumerateAndDisplay(string phrase)
    {
        Console.WriteLine($"The characters in the string \"{phrase}\" are:");

        int CharCount = 0;
        int controlChars = 0;
        int alphanumeric = 0;
        int punctuation = 0;

        foreach (char ch in phrase)
        {
            Console.Write(char.IsControl(ch) ? $"{ch}" : $"0x{(ushort)ch:X4}");

            if (char.IsLetterOrDigit(ch))
                alphanumeric++;
            else if (char.IsControl(ch))
                controlChars++;
            else if (char.IsPunctuation(ch))
                punctuation++;
            CharCount++;
        }

        Console.WriteLine($"\n   Total characters:        {CharCount,3}");
        Console.WriteLine($"   Alphanumeric characters: {alphanumeric,3}");
        Console.WriteLine($"   Punctuation characters:  {punctuation,3}");
        Console.WriteLine($"   Control Characters:      {controlChars,3}\n");
    }
}
// The example displays the following output:
//    The characters in the string "Test Case" are:
//    'T' 'e' 's' 't' ' ' 'C' 'a' 's' 'e'
//       Total characters:          9
//       Alphanumeric characters:   8
//       Punctuation characters:    0
//       Control Characters:        0
//
//    The characters in the string "This is a sentence." are:
//    'T' 'h' 'i' 's' ' ' 'i' 's' ' ' 'a' ' ' 's' 'e' 'n' 't' 'e' 'n' 'c' 'e' '.'
//       Total characters:         19
//       Alphanumeric characters:  15
//       Punctuation characters:    1
//       Control Characters:        0
//
//    The characters in the string "Has       two     tabs" are:
//    'H' 'a' 's' '0x0009' 't' 'w' 'o' '0x0009' 't' 'a' 'b' 's'
//       Total characters:         12
//       Alphanumeric characters:  10
//       Punctuation characters:    0
//       Control Characters:        2
//
//    The characters in the string "Two
//    new
//    lines" are:
//    'T' 'w' 'o' '0x000A' 'n' 'e' 'w' '0x000A' 'l' 'i' 'n' 'e' 's'
//       Total characters:         13
//       Alphanumeric characters:  11
//       Punctuation characters:    0
//       Control Characters:        2
//</snippet1>
