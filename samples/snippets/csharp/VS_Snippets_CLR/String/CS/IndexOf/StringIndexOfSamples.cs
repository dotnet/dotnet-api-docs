using System;
using System.Text;

namespace StringSamples.IndexOf
{
    internal static class StringIndexOfSamples
    {
        private static void Sample1()
        {
            //<snippet1>
            string br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+---";
            string br2 = "012345678901234567890123456789012345678901234567890123456789012345678";
            string str = "Now is the time for all good men to come to the aid of their country.";
            char value = 't';

            Console.WriteLine($"All occurrences of '{value}' from position 0 to {str.Length - 1}.");
            Console.WriteLine(br1);
            Console.WriteLine(br2);
            Console.WriteLine(str);
            
            int foundIndex = 0;
            int startIndex = 0;
            StringBuilder positions = new();
            while ((startIndex < str.Length) && (foundIndex > -1))
            {
                foundIndex = str.IndexOf(value, startIndex);
                if (foundIndex == -1) break; // -1 means it was not found.
                positions.Append($"{foundIndex} ");
                startIndex = foundIndex + 1;
            }

            Console.WriteLine($"\nThe letter '{value}' occurs at position(s): {positions}");

            // This example produces the following results:
            //   All occurrences of 't' from position 0 to 68.
            //   0----+----1----+----2----+----3----+----4----+----5----+----6----+---
            //   012345678901234567890123456789012345678901234567890123456789012345678
            //   Now is the time for all good men to come to the aid of their country.
            //   
            //   The letter 't' occurs at position(s): 7 11 33 41 44 55 65
            //</snippet1>
        }

        private static void Sample2()
        {
            //<snippet2>
            string br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+---";
            string br2 = "012345678901234567890123456789012345678901234567890123456789012345678";
            string str = "Now is the time for all good men to come to the aid of their country.";
            string value = "he";

            int endIndex = str.Length;
            int startIndex = endIndex / 2;

            Console.WriteLine($"All occurrences of '{value}' from position {startIndex} to {endIndex}.");
            Console.WriteLine(br1);
            Console.WriteLine(br2);
            Console.WriteLine(str);

            int foundIndex = 0;
            StringBuilder positions = new();
            while ((startIndex <= endIndex) && (foundIndex > -1))
            {
                int count = endIndex - startIndex;
                foundIndex = str.IndexOf(value, startIndex, count);
                if (foundIndex == -1) break; // -1 means it was not found.
                positions.Append($"{foundIndex} ");
                startIndex = foundIndex + 1;
            }

            Console.WriteLine($"\nThe string '{value}' occurs at position(s): {positions}");

            // This example produces the following results:
            //   All occurrences of 'he' from position 0 to 68.
            //   0----+----1----+----2----+----3----+----4----+----5----+----6----+---
            //   012345678901234567890123456789012345678901234567890123456789012345678
            //   Now is the time for all good men to come to the aid of their country.
            //   
            //   The string 'he' occurs at position(s): 45 56
            //</snippet2>
        }

        internal static void RunSamples()
        {
            Console.WriteLine("Samples for String.IndexOf():");
            Console.WriteLine("=================================");
            Console.WriteLine("--== Sample 1 ==--");
            Sample1();

            Console.WriteLine();
            Console.WriteLine("--== Sample 2 ==--");
            Sample2();

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
