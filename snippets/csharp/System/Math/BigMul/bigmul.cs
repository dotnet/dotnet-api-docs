//<snippet1>
// This example demonstrates Math.BigMul()
using System;

class Sample
{
    public static void Main()
    {
        int int1 = int.MaxValue;
        int int2 = int.MaxValue;
        long longResult;
        //
        longResult = Math.BigMul(int1, int2);
        Console.WriteLine("Calculate the product of two Int32 values:");
        Console.WriteLine($"{int1} * {int2} = {longResult}");
    }
}
/*
This example produces the following results:
Calculate the product of two Int32 values:
2147483647 * 2147483647 = 4611686014132420609
*/
//</snippet1>
