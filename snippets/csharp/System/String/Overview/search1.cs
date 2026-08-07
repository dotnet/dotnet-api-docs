// <Snippet22>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        string[] cultureNames = { "da-DK", "en-US" };
        CompareInfo ci;
        string str = "aerial";
        char ch = 'æ';  // U+00E6

        Console.Write("Ordinal comparison -- ");
        Console.WriteLine($"Position of '{ch}' in {str}: {str.IndexOf(ch)}");

        foreach (string cultureName in cultureNames)
        {
            ci = CultureInfo.CreateSpecificCulture(cultureName).CompareInfo;
            Console.Write($"{cultureName} cultural comparison -- ");
            Console.WriteLine($"Position of '{ch}' in {str}: {ci.IndexOf(str, ch)}");
        }
    }
}
// The example displays the following output:
//       Ordinal comparison -- Position of 'æ' in aerial: -1
//       da-DK cultural comparison -- Position of 'æ' in aerial: -1
//       en-US cultural comparison -- Position of 'æ' in aerial: 0
// </Snippet22>
