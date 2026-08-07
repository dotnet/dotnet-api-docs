// Sample for String.Join(String, String[], int int)
using System;

class Sample
{
    public static void Main()
    {
        //<snippet1>
        string[] val = { "apple", "orange", "grape", "pear" };
        string sep = ", ";
        string result;

        Console.WriteLine($"sep = '{sep}'");
        Console.WriteLine($"val[] = {{'{val[0]}' '{val[1]}' '{val[2]}' '{val[3]}'}}");
        result = string.Join(sep, val, 1, 2);
        Console.WriteLine($"String.Join(sep, val, 1, 2) = '{result}'");

        // This example produces the following results:
        // sep = ', '
        // val[] = {'apple' 'orange' 'grape' 'pear'}
        // String.Join(sep, val, 1, 2) = 'orange, grape'
        //</snippet1>
    }
}
