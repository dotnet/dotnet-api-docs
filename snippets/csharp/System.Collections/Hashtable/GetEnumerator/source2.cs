// <Snippet2>
using System;
using System.Collections;

public class HashtableExample
{
    public static void Main()
    {
        // Creates and initializes a new Hashtable.
        Hashtable clouds = new()
        {
            { "Cirrus", "Castellanus" },
            { "Cirrocumulus", "Stratiformis" },
            { "Altostratus", "Radiatus" },
            { "Stratocumulus", "Perlucidus" },
            { "Stratus", "Fractus" },
            { "Nimbostratus", "Pannus" },
            { "Cumulus", "Humilis" },
            { "Cumulonimbus", "Incus" }
        };

        // Displays the keys and values of the Hashtable using GetEnumerator().

        IDictionaryEnumerator denum = clouds.GetEnumerator();
        DictionaryEntry dentry;

        Console.WriteLine();
        Console.WriteLine("    Cloud Type       Variation");
        Console.WriteLine("    -----------------------------");
        while (denum.MoveNext())
        {
            dentry = (DictionaryEntry)denum.Current;
            Console.WriteLine($"    {dentry.Key,-17}{dentry.Value}");
        }
        Console.WriteLine();

        // Displays the keys and values of the Hashtable using foreach statement.

        Console.WriteLine("    Cloud Type       Variation");
        Console.WriteLine("    -----------------------------");
        foreach (DictionaryEntry de in clouds)
        {
            Console.WriteLine($"    {de.Key,-17}{de.Value}");
        }
        Console.WriteLine();
    }
}

// The program displays the following output to the console:
//
//    Cloud Type       Variation
//    -----------------------------
//    Cirrocumulus     Stratiformis
//    Stratocumulus    Perlucidus
//    Cirrus           Castellanus
//    Cumulus          Humilis
//    Nimbostratus     Pannus
//    Stratus          Fractus
//    Altostratus      Radiatus
//    Cumulonimbus     Incus
//
//    Cloud Type       Variation
//    -----------------------------
//    Cirrocumulus     Stratiformis
//    Stratocumulus    Perlucidus
//    Cirrus           Castellanus
//    Cumulus          Humilis
//    Nimbostratus     Pannus
//    Stratus          Fractus
//    Altostratus      Radiatus
//    Cumulonimbus     Incus*/
// </Snippet2>
