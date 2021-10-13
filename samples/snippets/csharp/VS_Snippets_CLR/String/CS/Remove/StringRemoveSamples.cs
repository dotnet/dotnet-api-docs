using System;

namespace StringExamples.Remove
{
    internal class StringRemoveSamples
    {
        private static void Sample1()
        {
            //<snippet1>
            string name = "Michelle Violet Banks";

            Console.WriteLine($"The entire name is '{name}'");

            // Remove the middle name, identified by finding the spaces in the name.
            int foundS1 = name.IndexOf(" ");
            int foundS2 = name.IndexOf(" ", foundS1 + 1);

            if (foundS1 != foundS2 && foundS1 >= 0)
            {
                name = name.Remove(foundS1 + 1, foundS2 - foundS1);

                Console.WriteLine($"After removing the middle name, we are left with '{name}'");
            }

            // The example displays the following output:
            //       The entire name is 'Michelle Violet Banks'
            //       After removing the middle name, we are left with 'Michelle Banks'
            //</snippet1>
        }

        private static void Sample2()
        {
            //<snippet2>
            string s = "abc---def";

            Console.WriteLine("Index: 012345678");
            Console.WriteLine("1)     {0}", s);
            Console.WriteLine("2)     {0}", s.Remove(3));
            Console.WriteLine("3)     {0}", s.Remove(3, 3));

            // This example produces the following results:
            // Index: 012345678
            // 1)     abc---def
            // 2)     abc
            // 3)     abcdef
            //</snippet2>
        }

        internal static void RunSamples()
        {
            Console.WriteLine("Samples for String.Remove():");
            Console.WriteLine("============================");
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
