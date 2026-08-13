// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        float result1 = -8.997e37f + -2.985e38f;
        Console.WriteLine($"{result1} (Negative Infinity: {float.IsNegativeInfinity(result1)})");

        float result2 = -1.5935e25f * 7.948e32f;
        Console.WriteLine($"{result2} (Negative Infinity: {float.IsNegativeInfinity(result2)})");
    }
}
// The example displays the following output:
//    -Infinity (Negative Infinity: True)
//    -Infinity (Negative Infinity: True)
// </Snippet1>
