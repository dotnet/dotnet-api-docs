using System;

public class Example8
{
    public static void Run()
    {
        // <Snippet1>
        double value = -4.42330604244772E-305;

        double fromLiteral = -4.42330604244772E-305;
        double fromVariable = value;
        double fromParse = double.Parse("-4.42330604244772E-305");

        Console.WriteLine($"Double value from literal: {fromLiteral,29:R}");
        Console.WriteLine($"Double value from variable: {fromVariable,28:R}");
        Console.WriteLine($"Double value from Parse method: {fromParse,24:R}");

        // The output is:
        //    Double value from literal:        -4.42330604244772E-305
        //    Double value from variable:       -4.42330604244772E-305
        //    Double value from Parse method:   -4.42330604244772E-305
        // </Snippet1>
    }
}
