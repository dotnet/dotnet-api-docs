using System;
using System.Globalization;

class Sample0
{
    //<snippet1>
    public static void Main()
    {
        string str1 = "change";
        string str2 = "dollar";
        string relation;

        relation = symbol(string.Compare(str1, str2, false, new CultureInfo("en-US")));
        Console.WriteLine($"For en-US: {str1} {relation} {str2}");

        relation = symbol(string.Compare(str1, str2, false, new CultureInfo("cs-CZ")));
        Console.WriteLine($"For cs-CZ: {str1} {relation} {str2}");
    }

    private static string symbol(int r)
    {
        string s = "=";
        if (r < 0) s = "<";
        else if (r > 0) s = ">";
        return s;
    }

    /*
    This example produces the following results.
    For en-US: change < dollar
    For cs-CZ: change > dollar
    */

    //</snippet1>
}
