// <Snippet1>
using System;
using System.Globalization;

public class ToStringExample1
{
    public static void Main()
    {
        CultureInfo currentCulture = CultureInfo.CurrentCulture;
        DateTime exampleDate = new DateTime(2021, 5, 1, 18, 32, 6);

        // Change the current culture to en-US and display the date.
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        Console.WriteLine(exampleDate.ToString());

        // Change the current culture to fr-FR and display the date.
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("fr-FR");
        Console.WriteLine(exampleDate.ToString());

        // Change the current culture to ja-JP and display the date.
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("ja-JP");
        Console.WriteLine(exampleDate.ToString());

        // Restore the original culture
        CultureInfo.CurrentCulture = currentCulture;
    }
}

// The example displays the following output to the console:
//       5/1/2021 6:32:06 PM
//       01/05/2021 18:32:06
//       2021/05/01 18:32:06
// </Snippet1>
