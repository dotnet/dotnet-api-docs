using System;

namespace StringSamples.Contains
{
    internal static class StringContainsSamples
    {
        private static void Sample1()
        {
            //<snippet1>
            string str = "The quick brown fox jumps over the lazy dog";
            string value = "fox";
            bool isValueInStr = str.Contains(value);
            Console.WriteLine($"'{value}' {(isValueInStr ? "is" : "is not")} in the string '{str}'");

            if (isValueInStr)
            {
                int index = str.IndexOf(value);
                Console.WriteLine($"'{value} begins at character position {index}");
            }

            // This example displays the following output:
            //    'fox' is in the string 'The quick brown fox jumps over the lazy dog'
            //    'fox begins at character position 16
            //</snippet1>
        }

        internal static void RunSamples()
        {
            Console.WriteLine("Samples for String.Contains():");
            Console.WriteLine("==============================");
            Console.WriteLine("--== Sample 1 ==--");
            Sample1();

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
