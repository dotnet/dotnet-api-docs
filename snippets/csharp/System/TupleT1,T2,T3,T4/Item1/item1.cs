// <Snippet1>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        Tuple<string, int, double, double>[] temperatures =
              [ Tuple.Create("New York, NY", 4, 61.0, 43.0),
              Tuple.Create("Chicago, IL", 2, 34.0, 18.0),
              Tuple.Create("Newark, NJ", 4, 61.0, 43.0),
              Tuple.Create("Boston, MA", 6, 77.0, 59.0),
              Tuple.Create("Detroit, MI", 9, 74.0, 53.0),
              Tuple.Create("Minneapolis, MN", 8, 81.0, 61.0) ];
        // Display the array of 4-tuple objects.
        Console.WriteLine($"{"Temperatures",41}");
        Console.WriteLine($"{"City",-20} {"Month",5}    {"High",4}  {"Low",4}\n");
        foreach (var temperature in temperatures)
            Console.WriteLine($"{temperature.Item1,-20} {DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(temperature.Item2 - 1),5}    {temperature.Item3,4:N1}  {temperature.Item4,4:N1}");
    }
}
// The example displays the following output:
//                                    Temperatures
//       City                 Month    High   Low
//
//       New York, NY           Mar    61.0  43.0
//       Chicago, IL            Jan    34.0  18.0
//       Newark, NJ             Mar    61.0  43.0
//       Boston, MA             May    77.0  59.0
//       Detroit, MI            Aug    74.0  53.0
//       Minneapolis, MN        Jul    81.0  61.0
// </Snippet1>
