using System;

public class Example4
{
    public static void Main()
    {
        //<snippet1>
        string errString = "This docment uses 3 other docments to docment the docmentation";

        Console.WriteLine($"The original string is:{Environment.NewLine}'{errString}'{Environment.NewLine}");

        // Correct the spelling of "document".
        string correctString = errString.Replace("docment", "document");

        Console.WriteLine($"After correcting the string, the result is:{Environment.NewLine}'{correctString}'");

        // This code example produces the following output:
        //
        // The original string is:
        // 'This docment uses 3 other docments to docment the docmentation'
        //
        // After correcting the string, the result is:
        // 'This document uses 3 other documents to document the documentation'
        //
        //</snippet1>
    }
}
