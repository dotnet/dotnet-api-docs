// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        float result1 = 1.867e38f + 2.385e38f;
        Console.WriteLine($"{result1} (Positive Infinity: {float.IsPositiveInfinity(result1)})");

        float result2 = 1.5935e25f * 7.948e20f;
        Console.WriteLine($"{result2} (Positive Infinity: {float.IsPositiveInfinity(result2)})");
    }
}
// The example displays the following output:
//    Infinity (Positive Infinity: True)
//    Infinity (Positive Infinity: True)
// </Snippet1>
