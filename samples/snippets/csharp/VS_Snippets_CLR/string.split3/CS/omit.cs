﻿using System;

class Sample
{
    public static void Main()
    {
    //<snippet1>
    // This example demonstrates the String() methods that use
    // the StringSplitOptions enumeration.
    string s1 = ",ONE,,TWO,,,THREE,,";
    string s2 = "[stop]" +
                "ONE[stop][stop]" +
                "TWO[stop][stop][stop]" +
                "THREE[stop][stop]";
    char[] charSeparators = new char[] {','};
    string[] stringSeparators = new string[] {"[stop]"};
    string[] result;
    // ------------------------------------------------------------------------------
    // Split a string delimited by characters.
    // ------------------------------------------------------------------------------
    Console.WriteLine("1) Split a string delimited by characters:\n");

    // Display the original string and delimiter characters.
    Console.WriteLine("1a )The original string is \"{0}\".", s1);
    Console.WriteLine("The delimiter character is '{0}'.\n",
                       charSeparators[0]);

    // Split a string delimited by characters and return all elements.
    Console.WriteLine("1b) Split a string delimited by characters and " +
                      "return all elements:");
    result = s1.Split(charSeparators, StringSplitOptions.None);
    Show(result);

    // Split a string delimited by characters and return all non-empty elements.
    Console.WriteLine("1c) Split a string delimited by characters and " +
                      "return all non-empty elements:");
    result = s1.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
    Show(result);

    // Split the original string into the string and empty string before the
    // delimiter and the remainder of the original string after the delimiter.
    Console.WriteLine("1d) Split a string delimited by characters and " +
                      "return 2 elements:");
    result = s1.Split(charSeparators, 2, StringSplitOptions.None);
    Show(result);

    // Split the original string into the string after the delimiter and the
    // remainder of the original string after the delimiter.
    Console.WriteLine("1e) Split a string delimited by characters and " +
                      "return 2 non-empty elements:");
    result = s1.Split(charSeparators, 2, StringSplitOptions.RemoveEmptyEntries);
    Show(result);

    // ------------------------------------------------------------------------------
    // Split a string delimited by another string.
    // ------------------------------------------------------------------------------
    Console.WriteLine("2) Split a string delimited by another string:\n");

    // Display the original string and delimiter string.
    Console.WriteLine("2a) The original string is \"{0}\".", s2);
    Console.WriteLine("The delimiter string is \"{0}\".\n", stringSeparators[0]);

    // Split a string delimited by another string and return all elements.
    Console.WriteLine("2b) Split a string delimited by another string and " +
                      "return all elements:");
    result = s2.Split(stringSeparators, StringSplitOptions.None);
    Show(result);

    // Split the original string at the delimiter and return all non-empty elements.
    Console.WriteLine("2c) Split a string delimited by another string and " +
                      "return all non-empty elements:");
    result = s2.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
    Show(result);

    // Split the original string into the empty string before the
    // delimiter and the remainder of the original string after the delimiter.
    Console.WriteLine("2d) Split a string delimited by another string and " +
                      "return 2 elements:");
    result = s2.Split(stringSeparators, 2, StringSplitOptions.None);
    Show(result);

    // Split the original string into the string after the delimiter and the
    // remainder of the original string after the delimiter.
    Console.WriteLine("2e) Split a string delimited by another string and " +
                      "return 2 non-empty elements:");
    result = s2.Split(stringSeparators, 2, StringSplitOptions.RemoveEmptyEntries);
    Show(result);

    // Display the array of separated strings using a local function
    void Show(string[] entries)
    {
        Console.WriteLine("The return value contains these {0} elements:", entries.Length);
        foreach (string entry in entries)
        {
            Console.Write("<{0}>", entry);
        }
        Console.Write("\n\n");
    }

    /*
    This example produces the following results:

    1) Split a string delimited by characters:

    1a )The original string is ",ONE,,TWO,,,THREE,,".
    The delimiter character is ','.

    1b) Split a string delimited by characters and return all elements:
    The return value contains these 9 elements:
    <><ONE><><TWO><><><THREE><><>

    1c) Split a string delimited by characters and return all non-empty elements:
    The return value contains these 3 elements:
    <ONE><TWO><THREE>

    1d) Split a string delimited by characters and return 2 elements:
    The return value contains these 2 elements:
    <><ONE,,TWO,,,THREE,,>

    1e) Split a string delimited by characters and return 2 non-empty elements:
    The return value contains these 2 elements:
    <ONE><TWO,,,THREE,,>

    2) Split a string delimited by another string:

    2a) The original string is "[stop]ONE[stop][stop]TWO[stop][stop][stop]THREE[stop][stop]".
    The delimiter string is "[stop]".

    2b) Split a string delimited by another string and return all elements:
    The return value contains these 9 elements:
    <><ONE><><TWO><><><THREE><><>

    2c) Split a string delimited by another string and return all non-empty elements:
    The return value contains these 3 elements:
    <ONE><TWO><THREE>

    2d) Split a string delimited by another string and return 2 elements:
    The return value contains these 2 elements:
    <><ONE[stop][stop]TWO[stop][stop][stop]THREE[stop][stop]>

    2e) Split a string delimited by another string and return 2 non-empty elements:
    The return value contains these 2 elements:
    <ONE><TWO[stop][stop][stop]THREE[stop][stop]>

    */
    //</snippet1>
    }
}
