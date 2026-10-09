//<snippet1>
// Sample for String.CompareOrdinal(String, String)
using System;

class Sample
{
    public static void Main()
    {
        string str1 = "ABCD";
        string str2 = "abcd";
        string str;
        int result;

        Console.WriteLine();
        Console.WriteLine("Compare the numeric values of the corresponding Char objects in each string.");
        Console.WriteLine($"str1 = '{str1}', str2 = '{str2}'");
        result = string.CompareOrdinal(str1, str2);
        str = ((result < 0) ? "less than" : ((result > 0) ? "greater than" : "equal to"));
        Console.Write($"String '{str1}' is ");
        Console.Write($"{str} ");
        Console.WriteLine($"String '{str2}'.");
    }
}
/*
This example produces the following results:

Compare the numeric values of the corresponding Char objects in each string.
str1 = 'ABCD', str2 = 'abcd'
String 'ABCD' is less than String 'abcd'.
*/
//</snippet1>
