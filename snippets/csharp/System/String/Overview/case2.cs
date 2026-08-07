// <Snippet17>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
    const string disallowed = "file";

    public static void Main() => IsAccessAllowed(@"FILE:\\\c:\users\user001\documents\FinancialInfo.txt");

    private static void IsAccessAllowed(string resource)
    {
        CultureInfo[] cultures = { CultureInfo.CreateSpecificCulture("en-US"),
                                 CultureInfo.CreateSpecificCulture("tr-TR") };
        string scheme = null;
        int index = resource.IndexOfAny(new char[] { '\\', '/' });
        if (index > 0)
            scheme = resource.Substring(0, index - 1);

        // Change the current culture and perform the comparison.
        foreach (var culture in cultures)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Console.WriteLine($"Culture: {CultureInfo.CurrentCulture.DisplayName}");
            Console.WriteLine(resource);
            Console.WriteLine($"Access allowed: {!string.Equals(disallowed, scheme, StringComparison.CurrentCultureIgnoreCase)}");
            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//       Culture: English (United States)
//       FILE:\\\c:\users\user001\documents\FinancialInfo.txt
//       Access allowed: False
//
//       Culture: Turkish (Turkey)
//       FILE:\\\c:\users\user001\documents\FinancialInfo.txt
//       Access allowed: True
// </Snippet17>
