//<snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;

class TestCollectionsUtils
{
    public static void Main()
    {
        Hashtable population1 = CollectionsUtil.CreateCaseInsensitiveHashtable();

        population1["Trapperville"] = 15;
        population1["Doggerton"] = 230;
        population1["New Hollow"] = 1234;
        population1["McHenry"] = 185;

        // Select cities from the table using mixed case.
        Console.WriteLine("Case insensitive hashtable results:\n");
        Console.WriteLine($"{"Trapperville"}'s population is: {population1["trapperville"]}");
        Console.WriteLine($"{"Doggerton"}'s population is: {population1["DOGGERTON"]}");
        Console.WriteLine($"{"New Hollow"}'s population is: {population1["New hoLLow"]}");
        Console.WriteLine($"{"McHenry"}'s population is: {population1["MchenrY"]}");

        SortedList population2 = CollectionsUtil.CreateCaseInsensitiveSortedList();

        foreach (string city in population1.Keys)
        {
            population2.Add(city, population1[city]);
        }

        // Select cities from the sorted list using mixed case.
        Console.WriteLine("\nCase insensitive sorted list results:\n");
        Console.WriteLine($"{"Trapperville"}'s population is: {population2["trapPeRVille"]}");
        Console.WriteLine($"{"Doggerton"}'s population is: {population2["dOGGeRtON"]}");
        Console.WriteLine($"{"New Hollow"}'s population is: {population2["nEW hOLLOW"]}");
        Console.WriteLine($"{"McHenry"}'s population is: {population2["MchEnrY"]}");
    }
}

// This program displays the following output to the console.
//
// Case insensitive hashtable results:
//
// Trapperville's population is: 15
// Doggerton's population is: 230
// New Hollow's population is: 1234
// McHenry's population is: 185
//
// Case insensitive sorted list results:
//
// Trapperville's population is: 15
// Doggerton's population is: 230
// New Hollow's population is: 1234
// McHenry's population is: 185
//</snippet1>
