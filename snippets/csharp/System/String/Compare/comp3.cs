// Sample for String.Compare(String, Int32, String, Int32, Int32)
using System;

class Sample3
{
    public static void Main()
    {
        //<snippet1>
        string str1 = "machine";
        string str2 = "device";
        string str;
        int result;

        Console.WriteLine();
        Console.WriteLine($"str1 = '{str1}', str2 = '{str2}'");
        result = string.Compare(str1, 2, str2, 0, 2);
        str = ((result < 0) ? "less than" : ((result > 0) ? "greater than" : "equal to"));
        Console.Write($"Substring '{str1.Substring(2, 2)}' in '{str1}' is ");
        Console.Write($"{str} ");
        Console.WriteLine($"substring '{str2.Substring(0, 2)}' in '{str2}'.");

        /*
        This example produces the following results:

        str1 = 'machine', str2 = 'device'
        Substring 'ch' in 'machine' is less than substring 'de' in 'device'.
        */
        //</snippet1>
    }
}
