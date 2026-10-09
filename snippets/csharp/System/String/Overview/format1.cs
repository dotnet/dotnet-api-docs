// <Snippet8>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        DateTime date = new(2011, 3, 1);
        CultureInfo[] cultures = [CultureInfo.InvariantCulture,
                                  new CultureInfo("en-US"),
                                  new CultureInfo("fr-FR")];

        foreach (var culture in cultures)
            Console.WriteLine($"{(string.IsNullOrEmpty(culture.Name) ?
                              "Invariant" : culture.Name),-12} {date.ToString("d", culture)}");
    }
}
// The example displays the following output:
//       Invariant    03/01/2011
//       en-US        3/1/2011
//       fr-FR        01/03/2011
// </Snippet8>
