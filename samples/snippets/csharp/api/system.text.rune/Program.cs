using System;
using System.Buffers;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace RuneSamples
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n----- Count letters in string");
            CountLettersInString.Run();

            Console.WriteLine("\n----- Count letters in span");
            CountLettersInSpan.Run();

            Console.WriteLine("\n----- Handle surrogates");
            WorkWithSurrogates.Run();

            Console.WriteLine("\n----- Find first letter");
            FindFirstLetter.Run();

            Console.WriteLine("\n----- Split string  on char");
            SplitStringOnChar.Run();

            Console.WriteLine("\n----- Instantiate Runes");
            InstantiateRunes.Run();

            Console.WriteLine("\n----- Trim letters and nondigits");
            TrimNonLettersAndNonDigits.Run();

            Console.WriteLine("\n----- Encode a Rune");
            EncodeRune.Run();
        }
    }
}
