// <Snippet3>
using System;
using System.Globalization;
using System.Threading;

public class Example3
{
    public static void Main()
    {
        String[] cultureNames = { "en-US", "th-TH", "tr-TR" };
        String[] strings1 = { "a", "i", "case", };
        String[] strings2 = { "a-", "\u0130", "Case" };
        StringComparison[] comparisons = (StringComparison[])Enum.GetValues(typeof(StringComparison));

        foreach (var cultureName in cultureNames)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.Name);
            for (int ctr = 0; ctr <= strings1.GetUpperBound(0); ctr++)
            {
                foreach (var comparison in comparisons)
                    Console.WriteLine("   {0} = {1} ({2}): {3}", strings1[ctr],
                                      strings2[ctr], comparison,
                                      String.Equals(strings1[ctr], strings2[ctr], comparison));

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//    Current Culture: en-US
//       a = a- (CurrentCulture): False
//       a = a- (CurrentCultureIgnoreCase): False
//       a = a- (InvariantCulture): False
//       a = a- (InvariantCultureIgnoreCase): False
//       a = a- (Ordinal): False
//       a = a- (OrdinalIgnoreCase): False
//
//       i = İ (CurrentCulture): False
//       i = İ (CurrentCultureIgnoreCase): False
//       i = İ (InvariantCulture): False
//       i = İ (InvariantCultureIgnoreCase): False
//       i = İ (Ordinal): False
//       i = İ (OrdinalIgnoreCase): False
//
//       case = Case (CurrentCulture): False
//       case = Case (CurrentCultureIgnoreCase): True
//       case = Case (InvariantCulture): False
//       case = Case (InvariantCultureIgnoreCase): True
//       case = Case (Ordinal): False
//       case = Case (OrdinalIgnoreCase): True
//
//
//    Current Culture: th-TH
//       a = a- (CurrentCulture): True
//       a = a- (CurrentCultureIgnoreCase): True
//       a = a- (InvariantCulture): False
//       a = a- (InvariantCultureIgnoreCase): False
//       a = a- (Ordinal): False
//       a = a- (OrdinalIgnoreCase): False
//
//       i = İ (CurrentCulture): False
//       i = İ (CurrentCultureIgnoreCase): False
//       i = İ (InvariantCulture): False
//       i = İ (InvariantCultureIgnoreCase): False
//       i = İ (Ordinal): False
//       i = İ (OrdinalIgnoreCase): False
//
//       case = Case (CurrentCulture): False
//       case = Case (CurrentCultureIgnoreCase): True
//       case = Case (InvariantCulture): False
//       case = Case (InvariantCultureIgnoreCase): True
//       case = Case (Ordinal): False
//       case = Case (OrdinalIgnoreCase): True
//
//
//    Current Culture: tr-TR
//       a = a- (CurrentCulture): False
//       a = a- (CurrentCultureIgnoreCase): False
//       a = a- (InvariantCulture): False
//       a = a- (InvariantCultureIgnoreCase): False
//       a = a- (Ordinal): False
//       a = a- (OrdinalIgnoreCase): False
//
//       i = İ (CurrentCulture): False
//       i = İ (CurrentCultureIgnoreCase): True
//       i = İ (InvariantCulture): False
//       i = İ (InvariantCultureIgnoreCase): False
//       i = İ (Ordinal): False
//       i = İ (OrdinalIgnoreCase): False
//
//       case = Case (CurrentCulture): False
//       case = Case (CurrentCultureIgnoreCase): True
//       case = Case (InvariantCulture): False
//       case = Case (InvariantCultureIgnoreCase): True
//       case = Case (Ordinal): False
//       case = Case (OrdinalIgnoreCase): True
// </Snippet3>
