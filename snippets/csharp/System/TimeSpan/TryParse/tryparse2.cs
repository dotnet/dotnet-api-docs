// <Snippet2>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        string[] values = [ "6", "6:12", "6:12:14", "6:12:14:45",
                          "6.12:14:45", "6:12:14:45.3448",
                          "6:12:14:45,3448", "6:34:14:45" ];
        CultureInfo[] cultures = [ new CultureInfo("en-US"),
                                 new CultureInfo("ru-RU"),
                                 CultureInfo.InvariantCulture ];

        string header = $"{"String",-17}";
        foreach (CultureInfo culture in cultures)
            header += culture.Equals(CultureInfo.InvariantCulture) ?
                         $"{"Invariant",20}" :
                         $"{culture.Name,20}";

        Console.WriteLine(header);
        Console.WriteLine();

        foreach (string value in values)
        {
            Console.Write($"{value,-17}");
            foreach (CultureInfo culture in cultures)
            {
                TimeSpan interval = new();
                if (TimeSpan.TryParse(value, culture, out interval))
                    Console.Write($"{interval.ToString("c"),20}");
                else
                    Console.Write($"{"Unable to Parse",20}");
            }
            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//    String                          en-US               ru-RU           Invariant
//
//    6                          6.00:00:00          6.00:00:00          6.00:00:00
//    6:12                         06:12:00            06:12:00            06:12:00
//    6:12:14                      06:12:14            06:12:14            06:12:14
//    6:12:14:45                 6.12:14:45          6.12:14:45          6.12:14:45
//    6.12:14:45                 6.12:14:45          6.12:14:45          6.12:14:45
//    6:12:14:45.3448    6.12:14:45.3448000     Unable to Parse  6.12:14:45.3448000
//    6:12:14:45,3448       Unable to Parse  6.12:14:45.3448000     Unable to Parse
//    6:34:14:45            Unable to Parse     Unable to Parse     Unable to Parse
// </Snippet2>
