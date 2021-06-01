// This example demonstrates the Math.Round() method in conjunction
// with the MidpointRounding enumeration and decimal places.
using System;

class MPR
{
    public static void Example()
    {
        //<snippet1>
        decimal result = 0.0m;
        decimal positiveValue = 3.45m;
        decimal negativeValue = -3.45m;

        // Round a positive value using different strategies.
        // The precision of the result is 1 decimal place.

        result = Math.Round(positiveValue, 1, MidpointRounding.ToEven);
        Console.WriteLine($"{result} = Math.Round({positiveValue}, 1, MidpointRounding.ToEven)");
        result = Math.Round(positiveValue, 1, MidpointRounding.AwayFromZero);
        Console.WriteLine($"{result} = Math.Round({positiveValue}, 1, MidpointRounding.AwayFromZero)");
        result = Math.Round(positiveValue, 1, MidpointRounding.ToZero);
        Console.WriteLine($"{result} = Math.Round({positiveValue}, 1, MidpointRounding.ToZero)");
        Console.WriteLine();

        // Round a negative value using different strategies.
        // The precision of the result is 1 decimal place.

        result = Math.Round(negativeValue, 1, MidpointRounding.ToEven);
        Console.WriteLine($"{result} = Math.Round({negativeValue}, 1, MidpointRounding.ToEven)");
        result = Math.Round(negativeValue, 1, MidpointRounding.AwayFromZero);
        Console.WriteLine($"{result} = Math.Round({negativeValue}, 1, MidpointRounding.AwayFromZero)");
        result = Math.Round(negativeValue, 1, MidpointRounding.ToZero);
        Console.WriteLine($"{result} = Math.Round({negativeValue}, 1, MidpointRounding.ToZero)");
        Console.WriteLine();

        /*
        This code example produces the following results:

        3.4 = Math.Round(3.45, 1, MidpointRounding.ToEven)
        3.5 = Math.Round(3.45, 1, MidpointRounding.AwayFromZero)
        3.4 = Math.Round(3.45, 1, MidpointRounding.ToZero)

        -3.4 = Math.Round(-3.45, 1, MidpointRounding.ToEven)
        -3.5 = Math.Round(-3.45, 1, MidpointRounding.AwayFromZero)
        -3.4 = Math.Round(-3.45, 1, MidpointRounding.ToZero)
        */
        //</snippet1>
    }
}
