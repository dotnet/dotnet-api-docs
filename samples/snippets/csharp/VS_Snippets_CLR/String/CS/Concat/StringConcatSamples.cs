using System;

namespace StringSamples.Concat
{
    internal static class StringConcatSamples
    {
        private static void Sample1()
        {
            //<snippet1>
            int i = -123;
            object o = i;
            object[] objs = new object[] { -123, -456, -789 };

            Console.WriteLine("Concatenate 1, 2, and 3 objects:");
            Console.WriteLine($"  1) {string.Concat(o)}");
            Console.WriteLine($"  2) {string.Concat(o, o)}");
            Console.WriteLine($"  3) {string.Concat(o, o, o)}");
            Console.WriteLine("Concatenate 4 objects and a variable length parameter list:");
            Console.WriteLine($"  4) {string.Concat(o, o, o, o)}");
            Console.WriteLine($"  5) {string.Concat(o, o, o, o, o)}");
            Console.WriteLine("Concatenate an object array:");
            Console.WriteLine($"  6) {string.Concat(objs)}");
            Console.WriteLine("Concatenate an object with an object array:");
            Console.WriteLine($"  7) {string.Concat(o, objs)}");

            // The example displays the following output:
            //    Concatenate 1, 2, and 3 objects:
            //      1) -123
            //      2) -123-123
            //      3) -123-123-123
            //    Concatenate 4 objects and a variable length parameter list:
            //      4) -123-123-123-123
            //      5) -123-123-123-123-123
            //    Concatenate an object array:
            //      6) -123-456-789
            //    Concatenate an object with an object array:
            //      7) -123System.Object[]
            // </snippet1>
        }

        internal static void RunSamples()
        {
            Console.WriteLine("Samples for String.Concat():");
            Console.WriteLine("============================");
            Console.WriteLine("--== Sample 1 ==--");
            Sample1();

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
