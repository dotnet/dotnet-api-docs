// Sample for String.Compare(String, Int32, String, Int32, Int32, Boolean)
using System;

class Sample4
{
    public static void Main()
    {
        //<snippet1>
        string str1 = "MACHINE";
        string str2 = "machine";
        string str;
        int result;

        Console.WriteLine();
        Console.WriteLine($"str1 = '{str1}', str2 = '{str2}'");

        Console.WriteLine("Ignore case:");
        result = string.Compare(str1, 2, str2, 2, 2, true);
        str = ((result < 0) ? "less than" : ((result > 0) ? "greater than" : "equal to"));
        Console.Write($"Substring '{str1.Substring(2, 2)}' in '{str1}' is ");
        Console.Write($"{str} ");
        Console.WriteLine($"substring '{str2.Substring(2, 2)}' in '{str2}'.");
        Console.WriteLine();

        Console.WriteLine("Honor case:");
        result = string.Compare(str1, 2, str2, 2, 2, false);
        str = ((result < 0) ? "less than" : ((result > 0) ? "greater than" : "equal to"));
        Console.Write($"Substring '{str1.Substring(2, 2)}' in '{str1}' is ");
        Console.Write($"{str} ");
        Console.WriteLine($"substring '{str2.Substring(2, 2)}' in '{str2}'.");

        /*
        This example produces the following results:

        str1 = 'MACHINE', str2 = 'machine'
        Ignore case:
        Substring 'CH' in 'MACHINE' is equal to substring 'ch' in 'machine'.

        Honor case:
        Substring 'CH' in 'MACHINE' is greater than substring 'ch' in 'machine'.
        */
        //</snippet1>
    }
}
