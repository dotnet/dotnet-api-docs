//<snippet1>
// Sample for String.GetTypeCode()
using System;

class Sample
{
    public static void Main()
    {
        string str = "abc";
        TypeCode tc = str.GetTypeCode();
        Console.WriteLine($"The type code for '{str}' is {tc.ToString("D")}, which represents {tc.ToString("F")}.");
    }
}
/*
This example produces the following results:
The type code for 'abc' is 18, which represents String.
*/
//</snippet1>
