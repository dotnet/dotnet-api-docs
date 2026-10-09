// <Snippet9>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        string dateString = "07/10/2011";
        CultureInfo[] cultures = [CultureInfo.InvariantCulture,
                                  CultureInfo.CreateSpecificCulture("en-GB"),
                                  CultureInfo.CreateSpecificCulture("en-US")];
        Console.WriteLine($"{"Date String",-12} {"Culture",10} {"Month",8} {"Day",8}\n");
        foreach (var culture in cultures)
        {
            DateTime date = DateTime.Parse(dateString, culture);
            Console.WriteLine($"{dateString,-12} {(string.IsNullOrEmpty(culture.Name) ?
                              "Invariant" : culture.Name),10} {date.Month,8} {date.Day,8}");
        }
    }
}
// The example displays the following output:
//       Date String     Culture    Month      Day
//
//       07/10/2011    Invariant        7       10
//       07/10/2011        en-GB       10        7
//       07/10/2011        en-US        7       10
// </Snippet9>
