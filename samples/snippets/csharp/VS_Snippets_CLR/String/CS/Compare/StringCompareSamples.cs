using System;
using System.Globalization;

namespace StringExamples.Compare
{
    internal static class StringCompareSamples
    {
        private static void Sample1()
        {
            //<snippet1>
            string strA = "change";
            string strB = "dollar";
            bool ignoreCase = false;

            int en_US_Result = string.Compare(strA, strB, ignoreCase, new CultureInfo("en-US"));
            int cs_CZ_Result = string.Compare(strA, strB, ignoreCase, new CultureInfo("cs-CZ"));

            char en_US_Relation = ((en_US_Result < 0) ? '<' : ((en_US_Result > 0) ? '>' : '='));
            char cs_CZ_Relation = ((cs_CZ_Result < 0) ? '<' : ((cs_CZ_Result > 0) ? '>' : '='));

            Console.WriteLine($"For en-US: {strA} {en_US_Relation} {strB}");
            Console.WriteLine($"For cs-CZ: {strA} {cs_CZ_Relation} {strB}");

            // This example produces the following results.
            // For en-US: change < dollar
            // For cs-CZ: change > dollar
            //</snippet1>
        }

        private static void Sample2()
        {
            //<snippet2>
            string strA = "machine";
            string strB = "device";

            Console.WriteLine($"strA = '{strA}', strB = '{strB}'");

            int startIndexA = 2;
            int startIndexB = 0;
            int length = 2;

            int result = string.Compare(strA, startIndexA, strB, startIndexB, length);
            string subStrA = strA.Substring(startIndexA, length);
            string subStrB = strB.Substring(startIndexB, length);

            string relation = ((result < 0) ? "less than" : ((result > 0) ? "greater than" : "equal to"));

            Console.WriteLine($"Substring '{subStrA}' in '{strA}' is {relation} substring '{subStrB}' in '{strB}'.");

            // This example produces the following results:
            // strA = 'machine', strB = 'device'
            // Substring 'ch' in 'machine' is less than substring 'de' in 'device'.
            //</snippet2>
        }

        private static void Sample3()
        {
            //<snippet3>
            string strA = "MACHINE";
            string strB = "machine";

            int startIndex = 2;
            int length = 2;

            int ignoreCaseResult = string.Compare(strA, startIndex, strB, startIndex, length, true);
            int honorCaseResult = string.Compare(strA, startIndex, strB, startIndex, length, false);

            string ignoreCaseRelation = ((ignoreCaseResult < 0) ? "less than" : ((ignoreCaseResult > 0) ? "greater than" : "equal to"));
            string honorCaseRelation = ((honorCaseResult < 0) ? "less than" : ((honorCaseResult > 0) ? "greater than" : "equal to"));

            string subStrA = strA.Substring(startIndex, length);
            string subStrB = strB.Substring(startIndex, length);

            Console.WriteLine($"strA = '{strA}', strB = '{strB}'");
            Console.WriteLine("Ignore case:");
            Console.WriteLine($"  Substring '{subStrA}' in '{strA}' is {ignoreCaseRelation} substring '{subStrB}' in '{strB}'.");
            Console.WriteLine("Honor case:");
            Console.WriteLine($"  Substring '{subStrA}' in '{strA}' is {honorCaseRelation} substring '{subStrB}' in '{strB}'.");

            // This example produces the following results:
            // strA = 'MACHINE', strB = 'machine'
            // Ignore case:
            //   Substring 'CH' in 'MACHINE' is equal to substring 'ch' in 'machine'.
            // Honor case:
            //   Substring 'CH' in 'MACHINE' is greater than substring 'ch' in 'machine'.
            //</snippet3>
        }

        private static void Sample4()
        {
            //<snippet4>
            string strA = "MACHINE";
            string strB = "machine";

            int startIndex = 4;
            int length = 2;
            bool ignoreCase = true;

            int tr_TR_Result = string.Compare(strA, startIndex, strB, startIndex, length, ignoreCase, new CultureInfo("tr-TR"));
            int invariantResult = string.Compare(strA, startIndex, strB, startIndex, length, ignoreCase, CultureInfo.InvariantCulture);

            string tr_TR_Relation = ((tr_TR_Result < 0) ? "less than" : ((tr_TR_Result > 0) ? "greater than" : "equal to"));
            string invariantRelation = ((invariantResult < 0) ? "less than" : ((invariantResult > 0) ? "greater than" : "equal to"));

            string subStrA = strA.Substring(startIndex, length);
            string subStrB = strB.Substring(startIndex, length);

            Console.WriteLine();
            Console.WriteLine($"strA = '{strA}', strB = '{strB}'");
            Console.WriteLine("Ignoring case, Turkish culture:");
            Console.WriteLine($"  Substring '{subStrA}' in '{strA}' is {tr_TR_Relation} substring '{subStrB}' in '{strB}'.");
            Console.WriteLine("Ignoring case, invariant culture:");
            Console.WriteLine($"  Substring '{subStrA}' in '{strA}' is {invariantRelation} substring '{subStrB}' in '{strB}'.");

            // This example produces the following results:
            // strA = 'MACHINE', strB = 'machine'
            // Ignore case, Turkish culture:
            //   Substring 'IN' in 'MACHINE' is less than substring 'in' in 'machine'.
            // Ignore case, invariant culture:
            //   Substring 'IN' in 'MACHINE' is equal to substring 'in' in 'machine'.
            //</snippet4>
        }

        private static void Sample5()
        {
            //<snippet5>
            string strA = "ABCD";
            string strB = "abcd";

            int result = string.CompareOrdinal(strA, strB);
            string relation = ((result < 0) ? "less than" : ((result > 0) ? "greater than" : "equal to"));

            Console.WriteLine("Compare the numeric values of the corresponding Char objects in each string.");
            Console.WriteLine($"strA = '{strA}', strB = '{strB}'");
            Console.WriteLine($"'{strA}' is {relation} '{strB}'. ");

            // This example produces the following results:
            // Compare the numeric values of the corresponding Char objects in each string.
            // strA = 'ABCD', strB = 'abcd'
            // 'ABCD' is less than 'abcd'.
            //</snippet5>
        }

        internal static void RunSamples()
        {
            Console.WriteLine("Samples for String.Compare():");
            Console.WriteLine("=============================");
            Console.WriteLine("--== Sample 1 ==--");
            Sample1();

            Console.WriteLine();
            Console.WriteLine("--== Sample 2 ==--");
            Sample2();

            Console.WriteLine();
            Console.WriteLine("--== Sample 3 ==--");
            Sample3();

            Console.WriteLine();
            Console.WriteLine("--== Sample 4 ==--");
            Sample4();

            Console.WriteLine();
            Console.WriteLine("--== Sample 5 ==--");
            Sample5();

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
