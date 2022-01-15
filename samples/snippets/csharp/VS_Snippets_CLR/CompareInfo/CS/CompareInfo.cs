﻿// Types:System.Globalization.CompareInfo
//<snippet1>
using System;
using System.Text;
using System.Globalization;

public sealed class App
{
    static void Main(string[] args)
    {
        String[] sign = new String[] { "<", "=", ">" };

        // The code below demonstrates how strings compare
        // differently for different cultures.
        String s1 = "Coté", s2 = "coté", s3 = "côte";

        // Set sort order of strings for French in France.
        CompareInfo ci = new CultureInfo("fr-FR").CompareInfo;
        Console.WriteLine("The LCID for {0} is {1}.", ci.Name, ci.LCID);

        // Display the result using fr-FR Compare of Coté = coté.  	
        Console.WriteLine("fr-FR Compare: {0} {2} {1}",
            s1, s2, sign[ci.Compare(s1, s2, CompareOptions.IgnoreCase) + 1]);

        // Display the result using fr-FR Compare of coté > côte.
        Console.WriteLine("fr-FR Compare: {0} {2} {1}",
            s2, s3, sign[ci.Compare(s2, s3, CompareOptions.None) + 1]);

        // Set sort order of strings for Japanese as spoken in Japan.
        ci = new CultureInfo("ja-JP").CompareInfo;
        Console.WriteLine("The LCID for {0} is {1}.", ci.Name, ci.LCID);

        // Display the result using ja-JP Compare of coté < côte.
        Console.WriteLine("ja-JP Compare: {0} {2} {1}",
            s2, s3, sign[ci.Compare(s2, s3) + 1]);
    }
}

// This code produces the following output.
//
// The LCID for fr-FR is 1036.
// fr-FR Compare: Coté = coté
// fr-FR Compare: coté > côte
// The LCID for ja-JP is 1041.
// ja-JP Compare: coté < côte
//</snippet1>
