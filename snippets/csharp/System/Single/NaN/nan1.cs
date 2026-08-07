using System;

public class Example
{
    public static void Main()
    {
        // <Snippet1>
        float zero = 0.0f;
        Console.WriteLine($"{zero} / {zero} = {zero / zero}");
        // The example displays the following output:
        //         0 / 0 = NaN
        // </Snippet1>

        // <Snippet2>
        float nan1 = float.NaN;

        Console.WriteLine($"{3} + {nan1} = {3 + nan1}");
        Console.WriteLine($"Abs({nan1}) = {Math.Abs(nan1)}");
        // The example displays the following output:
        //       3 + NaN = NaN
        //       Abs(NaN) = NaN
        // </Snippet2>
        Console.WriteLine();

        // <Snippet3>
        float result = float.NaN;
        Console.WriteLine($"{result} = Single.NaN: {result == float.NaN}");
        // The example displays the following output:
        //         NaN = Single.Nan: False
        // </Snippet3>
    }
}
