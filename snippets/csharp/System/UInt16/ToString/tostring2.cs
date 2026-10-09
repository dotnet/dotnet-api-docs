// <Snippet2>
using System;
using System.Globalization;

public class UInt16ToStringExample2
{
    public static void Run()
    {
        // Define an array of CultureInfo objects.
        CultureInfo[] ci = { new CultureInfo("en-US"),
                           new CultureInfo("fr-FR"),
                           CultureInfo.InvariantCulture };
        ushort value = 18924;
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
//          en-US          fr-FR      Invariant
//          18924          18924          18924
// </Snippet2>
