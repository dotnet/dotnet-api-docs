//<snippet1>
using System;

class stringToString
{
    public static void Main()
    {
        string str1 = "123";
        string str2 = "abc";

        Console.WriteLine($"Original str1: {str1}");
        Console.WriteLine($"Original str2: {str2}");
        Console.WriteLine($"str1 same as str2?: {object.ReferenceEquals(str1, str2)}");

        str2 = str1.ToString();
        Console.WriteLine();
        Console.WriteLine($"New str2:      {str2}");
        Console.WriteLine($"str1 same as str2?: {object.ReferenceEquals(str1, str2)}");
    }
}
/*
This code produces the following output:
Original str1: 123
Original str2: abc
str1 same as str2?: False

New str2:      123
str1 same as str2?: True
*/
//</snippet1>
