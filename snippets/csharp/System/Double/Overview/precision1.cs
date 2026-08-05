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

        Console.WriteLine("Double value from literal: {0,29:R}", fromLiteral);
        Console.WriteLine("Double value from variable: {0,28:R}", fromVariable);
        Console.WriteLine("Double value from Parse method: {0,24:R}", fromParse);

        // The output is:
        //    Double value from literal:        -4.42330604244772E-305
        //    Double value from variable:       -4.42330604244772E-305
        //    Double value from Parse method:   -4.42330604244772E-305
        // </Snippet1>
    }
}
