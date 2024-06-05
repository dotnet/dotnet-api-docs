// <Snippet5>
using System;
using System.Globalization;

public class ToStringExample5
{
    public static void Main3()
    {
        string[] formats = { "G", "MM/yyyy", @"MM\/dd\/yyyy HH:mm", "yyyyMMdd" };
        string[] cultureNames = { "en-US", "fr-FR" };
        DateTime date = new DateTime(2015, 8, 18, 13, 31, 17);
        foreach (var cultureName in cultureNames)
        {
            var culture = new CultureInfo(cultureName);
            CultureInfo.CurrentCulture = culture;
            Console.WriteLine(culture.NativeName);
            foreach (var format in formats)
                Console.WriteLine($"   {format}: {date.ToString(format)}");
            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//       English (United States)
//          G: 8/18/2015 1:31:17 PM
//          MM/yyyy: 08/2015
//          MM\/dd\/yyyy HH:mm: 08/18/2015 13:31
//          yyyyMMdd: 20150818
//
//       français (France)
//          G: 18/08/2015 13:31:17
//          MM/yyyy: 08/2015
//          MM\/dd\/yyyy HH:mm: 08/18/2015 13:31
//          yyyyMMdd: 20150818
// </Snippet5>
