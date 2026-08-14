//<snippet1>
// Sample for String.Compare(String, Int32, String, Int32, Int32, Boolean, CultureInfo)
using System;
using System.Globalization;

class Sample5
{
    public static void Main()
    {
        //                 0123456
        string str1 = "MACHINE";
        string str2 = "machine";
        string str;
        int result;

        Console.WriteLine();
        Console.WriteLine($"str1 = '{str1}', str2 = '{str2}'");
        Console.WriteLine("Ignore case, Turkish culture:");
        result = string.Compare(str1, 4, str2, 4, 2, true, new CultureInfo("tr-TR"));
        str = ((result < 0) ? "less than" : ((result > 0) ? "greater than" : "equal to"));
        Console.Write($"Substring '{str1.Substring(4, 2)}' in '{str1}' is ");
        Console.Write($"{str} ");
        Console.WriteLine($"substring '{str2.Substring(4, 2)}' in '{str2}'.");

        Console.WriteLine();
        Console.WriteLine("Ignore case, invariant culture:");
        result = string.Compare(str1, 4, str2, 4, 2, true, CultureInfo.InvariantCulture);
        str = ((result < 0) ? "less than" : ((result > 0) ? "greater than" : "equal to"));
        Console.Write($"Substring '{str1.Substring(4, 2)}' in '{str1}' is ");
        Console.Write($"{str} ");
        Console.WriteLine($"substring '{str2.Substring(4, 2)}' in '{str2}'.");
    }
}
/*
This example produces the following results:

str1 = 'MACHINE', str2 = 'machine'
Ignore case, Turkish culture:
Substring 'IN' in 'MACHINE' is less than substring 'in' in 'machine'.

Ignore case, invariant culture:
Substring 'IN' in 'MACHINE' is equal to substring 'in' in 'machine'.
*/
//</snippet1>
