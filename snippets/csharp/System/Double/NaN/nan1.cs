using System;

public class Example
{
    public static void Main()
    {
        // <Snippet1>
        double zero = 0.0;
        Console.WriteLine($"{zero} / {zero} = {zero / zero}");
        // The example displays the following output:
        //         0 / 0 = NaN
        // </Snippet1>

        // <Snippet2>
        double nan1 = double.NaN;

        Console.WriteLine($"{3} + {nan1} = {3 + nan1}");
        Console.WriteLine($"Abs({nan1}) = {Math.Abs(nan1)}");
        // The example displays the following output:
        //       3 + NaN = NaN
        //       Abs(NaN) = NaN
        // </Snippet2>
        Console.WriteLine();

        // <Snippet3>
        double result = double.NaN;
        Console.WriteLine($"{result} = Double.Nan: {result == double.NaN}");
        // The example displays the following output:
        //         NaN = Double.Nan: False
        // </Snippet3>
    }
}
