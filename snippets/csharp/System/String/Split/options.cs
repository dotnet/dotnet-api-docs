using System;

namespace Split
{
    class Options
    {
        public static void Main3()
        {
            //<snippet1>
            // This example demonstrates the String.Split() methods that use
            // the StringSplitOptions enumeration.

            // Example 1: Split a string delimited by characters
            Console.WriteLine("1) Split a string delimited by characters:\n");

            string s1 = ",ONE,, TWO,, , THREE,,";
            char[] charSeparators = new char[] { ',' };
            string[] result;

            Console.WriteLine($"The original string is: \"{s1}\".");
            Console.WriteLine($"The delimiter character is: '{charSeparators[0]}'.\n");

            // Split the string and return all elements
            Console.WriteLine("1a) Return all elements:");
            result = s1.Split(charSeparators, StringSplitOptions.None);
            Show(result);

            // Split the string and return all elements with whitespace trimmed
            Console.WriteLine("1b) Return all elements with whitespace trimmed:");
            result = s1.Split(charSeparators, StringSplitOptions.TrimEntries);
            Show(result);

            // Split the string and return all non-empty elements
            Console.WriteLine("1c) Return all non-empty elements:");
            result = s1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            Show(result);

            // Split the string and return all non-whitespace elements with whitespace trimmed
            Console.WriteLine("1d) Return all non-whitespace elements with whitespace trimmed:");
            result = s1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Show(result);


            // Split the string into only two elements, keeping the remainder in the last match
            Console.WriteLine("1e) Split into only two elements:");
            result = s1.Split(charSeparators, 2, StringSplitOptions.None);
            Show(result);

            // Split the string into only two elements with whitespace trimmed, keeping the remainder in the last match
            Console.WriteLine("1f) Split into only two elements with whitespace trimmed:");
            result = s1.Split(charSeparators, 2, StringSplitOptions.TrimEntries);
            Show(result);

            // Split the string into only two non-empty elements, keeping the remainder in the last match
            Console.WriteLine("1g) Split into only two non-empty elements:");
            result = s1.Split(charSeparators, 2, StringSplitOptions.RemoveEmptyEntries);
            Show(result);

            // Split the string into only two non-whitespace elements with whitespace trimmed, keeping the remainder in the last match
            Console.WriteLine("1h) Split into only two non-whitespace elements with whitespace trimmed:");
            result = s1.Split(charSeparators, 2, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Show(result);


            // Example 2: Split a string delimited by another string
            Console.WriteLine("2) Split a string delimited by another string:\n");

            string s2 = "[stop]" +
                        "ONE[stop] [stop]" +
                        "TWO  [stop][stop]  [stop]" +
                        "THREE[stop][stop]  ";
            string[] stringSeparators = new string[] { "[stop]" };

            Console.WriteLine($"The original string is: \"{s2}\".");
            Console.WriteLine($"The delimiter string is: \"{stringSeparators[0]}\".\n");

            // Split the string and return all elements
            Console.WriteLine("2a) Return all elements:");
            result = s2.Split(stringSeparators, StringSplitOptions.None);
            Show(result);

            // Split the string and return all elements with whitespace trimmed
            Console.WriteLine("2b) Return all elements with whitespace trimmed:");
            result = s2.Split(stringSeparators, StringSplitOptions.TrimEntries);
            Show(result);

            // Split the string and return all non-empty elements
            Console.WriteLine("2c) Return all non-empty elements:");
            result = s2.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            Show(result);

            // Split the string and return all non-whitespace elements with whitespace trimmed
            Console.WriteLine("2d) Return all non-whitespace elements with whitespace trimmed:");
            result = s2.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Show(result);


            // Split the string into only two elements, keeping the remainder in the last match
            Console.WriteLine("2e) Split into only two elements:");
            result = s2.Split(stringSeparators, 2, StringSplitOptions.None);
            Show(result);

            // Split the string into only two elements with whitespace trimmed, keeping the remainder in the last match
            Console.WriteLine("2f) Split into only two elements with whitespace trimmed:");
            result = s2.Split(stringSeparators, 2, StringSplitOptions.TrimEntries);
            Show(result);

            // Split the string into only two non-empty elements, keeping the remainder in the last match
            Console.WriteLine("2g) Split into only two non-empty elements:");
            result = s2.Split(stringSeparators, 2, StringSplitOptions.RemoveEmptyEntries);
            Show(result);

            // Split the string into only two non-whitespace elements with whitespace trimmed, keeping the remainder in the last match
            Console.WriteLine("2h) Split into only two non-whitespace elements with whitespace trimmed:");
            result = s2.Split(stringSeparators, 2, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Show(result);


            // Display the array of separated strings using a local function
            void Show(string[] entries)
            {
                Console.WriteLine($"The return value contains these {entries.Length} elements:");
                foreach (string entry in entries)
                {
                    Console.Write($"<{entry}>");
                }
                Console.Write("\n\n");
            }

            /*
            This example produces the following results:

            1) Split a string delimited by characters:

            The original string is: ",ONE,, TWO,, , THREE,,".
            The delimiter character is: ','.

            1a) Return all elements:
            The return value contains these 9 elements:
            <><ONE><>< TWO><>< >< THREE><><>

            1b) Return all elements with whitespace trimmed:
            The return value contains these 9 elements:
            <><ONE><><TWO><><><THREE><><>

            1c) Return all non-empty elements:
            The return value contains these 4 elements:
            <ONE>< TWO>< >< THREE>

            1d) Return all non-whitespace elements with whitespace trimmed:
            The return value contains these 3 elements:
            <ONE><TWO><THREE>

            1e) Split into only two elements:
            The return value contains these 2 elements:
            <><ONE,, TWO,, , THREE,,>

            1f) Split into only two elements with whitespace trimmed:
            The return value contains these 2 elements:
            <><ONE,, TWO,, , THREE,,>

            1g) Split into only two non-empty elements:
            The return value contains these 2 elements:
            <ONE>< TWO,, , THREE,,>

            1h) Split into only two non-whitespace elements with whitespace trimmed:
            The return value contains these 2 elements:
            <ONE><TWO,, , THREE,,>

            2) Split a string delimited by another string:

            The original string is: "[stop]ONE[stop] [stop]TWO  [stop][stop]  [stop]THREE[stop][stop]  ".
            The delimiter string is: "[stop]".

            2a) Return all elements:
            The return value contains these 9 elements:
            <><ONE>< ><TWO  ><><  ><THREE><><  >

            2b) Return all elements with whitespace trimmed:
            The return value contains these 9 elements:
            <><ONE><><TWO><><><THREE><><>

            2c) Return all non-empty elements:
            The return value contains these 6 elements:
            <ONE>< ><TWO  ><  ><THREE><  >

            2d) Return all non-whitespace elements with whitespace trimmed:
            The return value contains these 3 elements:
            <ONE><TWO><THREE>

            2e) Split into only two elements:
            The return value contains these 2 elements:
            <><ONE[stop] [stop]TWO  [stop][stop]  [stop]THREE[stop][stop]  >

            2f) Split into only two elements with whitespace trimmed:
            The return value contains these 2 elements:
            <><ONE[stop] [stop]TWO  [stop][stop]  [stop]THREE[stop][stop]>

            2g) Split into only two non-empty elements:
            The return value contains these 2 elements:
            <ONE>< [stop]TWO  [stop][stop]  [stop]THREE[stop][stop]  >

            2h) Split into only two non-whitespace elements with whitespace trimmed:
            The return value contains these 2 elements:
            <ONE><TWO  [stop][stop]  [stop]THREE[stop][stop]>

            */
            //</snippet1>
        }

        public static void Main4()
        {
            // <Snippet2>
            string source = "[stop]ONE[stop][stop]TWO[stop][stop][stop]THREE[stop][stop]";
            string[] stringSeparators = new string[] { "[stop]" };
            string[] result;

            // Display the original string and delimiter string.
            Console.WriteLine($"Splitting the string:\n   \"{source}\".");
            Console.WriteLine();
            Console.WriteLine($"Using the delimiter string:\n   \"{stringSeparators[0]}\"");
            Console.WriteLine();

            // Split a string delimited by another string and return all elements.
            result = source.Split(stringSeparators, StringSplitOptions.None);
            Console.WriteLine($"Result including all elements ({result.Length} elements):");
            Console.Write("   ");
            foreach (string s in result)
            {
                Console.Write("'{0}' ", String.IsNullOrEmpty(s) ? "<>" : s);
            }
            Console.WriteLine();
            Console.WriteLine();

            // Split delimited by another string and return all non-empty elements.
            result = source.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Result including non-empty elements ({result.Length} elements):");
            Console.Write("   ");
            foreach (string s in result)
            {
                Console.Write("'{0}' ", String.IsNullOrEmpty(s) ? "<>" : s);
            }
            Console.WriteLine();

            // The example displays the following output:
            //    Splitting the string:
            //       "[stop]ONE[stop][stop]TWO[stop][stop][stop]THREE[stop][stop]".
            //
            //    Using the delimiter string:
            //       "[stop]"
            //
            //    Result including all elements (9 elements):
            //       '<>' 'ONE' '<>' 'TWO' '<>' '<>' 'THREE' '<>' '<>'
            //
            //    Result including non-empty elements (3 elements):
            //       'ONE' 'TWO' 'THREE'
            // </Snippet2>
        }

        public static void Main2()
        {
            // <Snippet3>
            string[] separators = { ",", ".", "!", "?", ";", ":", " " };
            string value = "The handsome, energetic, young dog was playing with his smaller, more lethargic litter mate.";
            string[] words = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
                Console.WriteLine(word);

            // The example displays the following output:
            //       The
            //       handsome
            //       energetic
            //       young
            //       dog
            //       was
            //       playing
            //       with
            //       his
            //       smaller
            //       more
            //       lethargic
            //       litter
            //       mate
            // </Snippet3>
        }
    }
}
