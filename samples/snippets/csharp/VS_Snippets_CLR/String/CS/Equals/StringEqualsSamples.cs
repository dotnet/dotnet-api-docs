using System;
using System.Text;

namespace StringSamples.Equals
{
    internal static class StringEqualsSamples
    {
        private static void Sample1()
        {
            //<snippet1>
            StringBuilder sb = new StringBuilder("abcd");
            string str1 = "abcd";

            Console.WriteLine($" *  The value of String str1 is '{str1}'.");
            Console.WriteLine($" *  The value of StringBuilder sb is '{sb}'.");
            Console.WriteLine();

            Console.WriteLine("1a) String.Equals(Object). Object is a StringBuilder, not a String.");
            Console.WriteLine($"    Is str1 equal to sb?: {str1.Equals(sb)}");
            Console.WriteLine();

            string str2 = sb.ToString();
            object o2 = str2;
            Console.WriteLine("1b) String.Equals(Object). Object is a String.");
            Console.WriteLine($" *  The value of Object o2 is '{o2}'.");
            Console.WriteLine($"    Is str1 equal to o2?: {str1.Equals(o2)}");
            Console.WriteLine();

            Console.WriteLine(" 2) String.Equals(String)");
            Console.WriteLine($" *  The value of String str2 is '{str2}'.");
            Console.WriteLine($"    Is str1 equal to str2?: {str1.Equals(str2)}");
            Console.WriteLine();

            Console.WriteLine(" 3) String.Equals(String, String)");
            Console.WriteLine($"    Is str1 equal to str2?: {string.Equals(str1, str2)}");

            // This example produces the following results:
            //  *  The value of String str1 is 'abcd'.
            //  *  The value of StringBuilder sb is 'abcd'.
            // 
            // 1a) String.Equals(Object). Object is a StringBuilder, not a String.
            //     Is str1 equal to sb?: False
            // 
            // 1b) String.Equals(Object). Object is a String.
            //  *  The value of Object o2 is 'abcd'.
            //     Is str1 equal to o2?: True
            // 
            // 2) String.Equals(String)
            //  *  The value of String str2 is 'abcd'.
            //     Is str1 equal to str2?: True
            // 
            // 3) String.Equals(String, String)
            //     Is str1 equal to str2?: True
            //</snippet1>
        }

        internal static void RunSamples()
        {
            Console.WriteLine("Samples for String.Equals():");
            Console.WriteLine("============================");
            Console.WriteLine("--== Sample 1 ==--");
            Sample1();

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
