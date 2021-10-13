using System;

namespace StringSamples.GetTypeCode
{
    internal static class StringGetTypeCodeSamples
    {
        private static void Sample1()
        {
            //<snippet1>
            string str = "abc";
            TypeCode tc = str.GetTypeCode();
            Console.WriteLine($"The type code for '{str}' is '{tc:D}', which represents '{tc:F}'.");

            // This example produces the following results:
            // The type code for 'abc' is '18', which represents 'String'.
            //</snippet1>
        }

        internal static void RunSamples()
        {
            Console.WriteLine("Samples for String.GetTypeCode():");
            Console.WriteLine("=================================");
            Console.WriteLine("--== Sample 1 ==--");
            Sample1();

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
