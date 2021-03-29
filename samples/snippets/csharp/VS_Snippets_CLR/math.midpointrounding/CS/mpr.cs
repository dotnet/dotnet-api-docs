// This example demonstrates the Math.Round() method in conjunction
// with the MidpointRounding enumeration.
using System;

class Sample
{
    public static void Main()
    {
//<snippet1>
    decimal result = 0.0m;
    decimal positiveValue = 3.45m;
    decimal negativeValue = -3.45m;

    // By default, round a positive and a negative value to the nearest even number.
    // The precision of the result is 1 decimal place.

    result = Math.Round(positiveValue, 1);
    Console.WriteLine($"{result} = Math.Round({positiveValue}, 1)");
    result = Math.Round(negativeValue, 1);
    Console.WriteLine($"{result} = Math.Round({negativeValue}, 1)");
    Console.WriteLine();

    // Round a positive value to the nearest even number, then to the nearest number away from zero.
    // The precision of the result is 1 decimal place.

    result = Math.Round(positiveValue, 1, MidpointRounding.ToEven);
    Console.WriteLine($"{result} = Math.Round({positiveValue}, 1, MidpointRounding.ToEven)");
    result = Math.Round(positiveValue, 1, MidpointRounding.AwayFromZero);
    Console.WriteLine($"{result} = Math.Round({positiveValue}, 1, MidpointRounding.AwayFromZero)");
    Console.WriteLine();

    // Round a negative value to the nearest even number, then to the nearest number away from zero.
    // The precision of the result is 1 decimal place.

    result = Math.Round(negativeValue, 1, MidpointRounding.ToEven);
    Console.WriteLine($"{result} = Math.Round({negativeValue}, 1, MidpointRounding.ToEven)");
    result = Math.Round(negativeValue, 1, MidpointRounding.AwayFromZero);
    Console.WriteLine($"{result} = Math.Round({negativeValue}, 1, MidpointRounding.AwayFromZero)");
    Console.WriteLine();
    /*
    This code example produces the following results:

    3.4 = Math.Round(3.45, 1)
    -3.4 = Math.Round(-3.45, 1)

    3.4 = Math.Round(3.45, 1, MidpointRounding.ToEven)
    3.5 = Math.Round(3.45, 1, MidpointRounding.AwayFromZero)

    -3.4 = Math.Round(-3.45, 1, MidpointRounding.ToEven)
    -3.5 = Math.Round(-3.45, 1, MidpointRounding.AwayFromZero)

    */
    //</snippet1>
    }
}
