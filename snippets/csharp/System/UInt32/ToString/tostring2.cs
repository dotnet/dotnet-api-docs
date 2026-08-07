// <Snippet2>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        // Define an array of CultureInfo objects.
        CultureInfo[] ci = { new CultureInfo("en-US"),
                           new CultureInfo("fr-FR"),
                           CultureInfo.InvariantCulture };
        uint value = 1870924;
        Console.WriteLine($"  {GetName(ci[0]),12}   {GetName(ci[1]),12}   {GetName(ci[2]),12}");
        Console.WriteLine($"  {value.ToString(ci[0]),12}   {value.ToString(ci[1]),12}   {value.ToString(ci[2]),12}");
    }

    private static string GetName(CultureInfo ci)
    {
        if (ci.Equals(CultureInfo.InvariantCulture))
            return "Invariant";
        else
            return ci.Name;
    }
}
// The example displays the following output:
//             en-US          fr-FR      Invariant
//           1870924        1870924        1870924
// </Snippet2>
