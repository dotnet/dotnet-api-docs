// This example demonstrates the Math.Round() method in conjunction
// with the MidpointRounding enumeration and decimal places.
using System;

class MPR
{
    public static void DecimalExample()
    {
        //<snippet1>
        decimal result;

        // Round a positive value using different strategies.
        // The precision of the result is 1 decimal place.

        result = Math.Round(3.45m, 1, MidpointRounding.ToEven);
        Console.WriteLine($"{result} = Math.Round({3.45m}, 1, MidpointRounding.ToEven)");
        result = Math.Round(3.45m, 1, MidpointRounding.AwayFromZero);
        Console.WriteLine($"{result} = Math.Round({3.45m}, 1, MidpointRounding.AwayFromZero)");
        result = Math.Round(3.47m, 1, MidpointRounding.ToZero);
        Console.WriteLine($"{result} = Math.Round({3.47m}, 1, MidpointRounding.ToZero)\n");

        // Round a negative value using different strategies.
        // The precision of the result is 1 decimal place.

        result = Math.Round(-3.45m, 1, MidpointRounding.ToEven);
        Console.WriteLine($"{result} = Math.Round({-3.45m}, 1, MidpointRounding.ToEven)");
        result = Math.Round(-3.45m, 1, MidpointRounding.AwayFromZero);
        Console.WriteLine($"{result} = Math.Round({-3.45m}, 1, MidpointRounding.AwayFromZero)");
        result = Math.Round(-3.47m, 1, MidpointRounding.ToZero);
        Console.WriteLine($"{result} = Math.Round({-3.47m}, 1, MidpointRounding.ToZero)\n");

        /*
        This code example produces the following results:

        3.4 = Math.Round(3.45, 1, MidpointRounding.ToEven)
        3.5 = Math.Round(3.45, 1, MidpointRounding.AwayFromZero)
        3.4 = Math.Round(3.47, 1, MidpointRounding.ToZero)

        -3.4 = Math.Round(-3.45, 1, MidpointRounding.ToEven)
        -3.5 = Math.Round(-3.45, 1, MidpointRounding.AwayFromZero)
        -3.4 = Math.Round(-3.47, 1, MidpointRounding.ToZero)
        */

        //</snippet1>
    }

    public static void DoubleExample()
    {
        // <snippet4>

        // Round a positive and a negative value using the default.
        double result = Math.Round(3.45, 1);
        Console.WriteLine($"{result,4} = Math.Round({3.45,5}, 1)");
        result = Math.Round(-3.45, 1);
        Console.WriteLine($"{result,4} = Math.Round({-3.45,5}, 1)\n");

        // Round a positive value using a MidpointRounding value.
        result = Math.Round(3.45, 1, MidpointRounding.ToEven);
        Console.WriteLine($"{result,4} = Math.Round({3.45,5}, 1, MidpointRounding.ToEven)");
        result = Math.Round(3.45, 1, MidpointRounding.AwayFromZero);
        Console.WriteLine($"{result,4} = Math.Round({3.45,5}, 1, MidpointRounding.AwayFromZero)");
        result = Math.Round(3.47, 1, MidpointRounding.ToZero);
        Console.WriteLine($"{result,4} = Math.Round({3.47,5}, 1, MidpointRounding.ToZero)\n");

        // Round a negative value using a MidpointRounding value.
        result = Math.Round(-3.45, 1, MidpointRounding.ToEven);
        Console.WriteLine($"{result,4} = Math.Round({-3.45,5}, 1, MidpointRounding.ToEven)");
        result = Math.Round(-3.45, 1, MidpointRounding.AwayFromZero);
        Console.WriteLine($"{result,4} = Math.Round({-3.45,5}, 1, MidpointRounding.AwayFromZero)");
        result = Math.Round(-3.47, 1, MidpointRounding.ToZero);
        Console.WriteLine($"{result,4} = Math.Round({-3.47,5}, 1, MidpointRounding.ToZero)\n");

        // The example displays the following output:

        //         3.4 = Math.Round( 3.45, 1)
        //         -3.4 = Math.Round(-3.45, 1)

        //         3.4 = Math.Round(3.45, 1, MidpointRounding.ToEven)
        //         3.5 = Math.Round(3.45, 1, MidpointRounding.AwayFromZero)
        //         3.4 = Math.Round(3.47, 1, MidpointRounding.ToZero)

        //         -3.4 = Math.Round(-3.45, 1, MidpointRounding.ToEven)
        //         -3.5 = Math.Round(-3.45, 1, MidpointRounding.AwayFromZero)
        //         -3.4 = Math.Round(-3.47, 1, MidpointRounding.ToZero)

        // </snippet4>
    }
}
