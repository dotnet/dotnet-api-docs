// <Snippet1>
using System;


public class Class1
{
    public static void Main()
    {
        // Create tuples containing population data for New York, Chicago,
        // and Los Angeles, 1960-2000.
        Tuple<string, int, int, int, int, int>[] cities =
             [ Tuple.Create("New York", 7781984, 7894862, 7071639, 7322564, 8008278),
             Tuple.Create("Los Angeles", 2479015, 2816061, 2966850, 3485398, 3694820),
             Tuple.Create("Chicago", 3550904, 3366957, 3005072, 2783726, 2896016) ];

        // Display tuple data in table.
        string header = "Population in";
        Console.WriteLine($"{"City",-12} {new string('-', (60 - header.Length) / 2) + header +
                                  new string('-', (60 - header.Length) / 2),60}");
        Console.WriteLine($"{"1960",25}{"1970",12}{"1980",12}{"1990",12}{"2000",12}\n");

        foreach (var city in cities)
            Console.WriteLine($"{city.Item1,-12} {city.Item2,12:N0}{city.Item3,12:N0}{city.Item4,12:N0}{city.Item5,12:N0}{city.Item6,12:N0}");
    }
}
// The example displays the following output:
//    City          -----------------------Population in-----------------------
//                         1960        1970        1980        1990        2000
//
//    New York        7,781,984   7,894,862   7,071,639   7,322,564   8,008,278
//    Los Angeles     2,479,015   2,816,061   2,966,850   3,485,398   3,694,820
//    Chicago         3,550,904   3,366,957   3,005,072   2,783,726   2,896,016
// </Snippet1>
