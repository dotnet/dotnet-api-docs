module mpr

// This example demonstrates the Math.Round() method in conjunction
// with the MidpointRounding enumeration and decimal places.
open System

let decimalExample () =
    //<snippet1>
    // Round a positive value using different strategies.
    // The precision of the result is 1 decimal place.

    let result = Math.Round(3.45m, 1, MidpointRounding.ToEven)
    printfn $"{result} = Math.Round({3.45m}, 1, MidpointRounding.ToEven)"
    let result = Math.Round(3.45m, 1, MidpointRounding.AwayFromZero)
    printfn $"{result} = Math.Round({3.45m}, 1, MidpointRounding.AwayFromZero)"
    let result = Math.Round(3.47m, 1, MidpointRounding.ToZero)
    printfn $"{result} = Math.Round({3.47m}, 1, MidpointRounding.ToZero)\n"

    // Round a negative value using different strategies.
    // The precision of the result is 1 decimal place.

    let result = Math.Round(-3.45m, 1, MidpointRounding.ToEven)
    printfn $"{result} = Math.Round({-3.45m}, 1, MidpointRounding.ToEven)"
    let result = Math.Round(-3.45m, 1, MidpointRounding.AwayFromZero)
    printfn $"{result} = Math.Round({-3.45m}, 1, MidpointRounding.AwayFromZero)"
    let result = Math.Round(-3.47m, 1, MidpointRounding.ToZero)
    printfn $"{result} = Math.Round({-3.47m}, 1, MidpointRounding.ToZero)\n"

    // This code example produces the following results:

    // 3.4 = Math.Round(3.45, 1, MidpointRounding.ToEven)
    // 3.5 = Math.Round(3.45, 1, MidpointRounding.AwayFromZero)
    // 3.4 = Math.Round(3.47, 1, MidpointRounding.ToZero)

    // -3.4 = Math.Round(-3.45, 1, MidpointRounding.ToEven)
    // -3.5 = Math.Round(-3.45, 1, MidpointRounding.AwayFromZero)
    // -3.4 = Math.Round(-3.47, 1, MidpointRounding.ToZero)

    //</snippet1>

let doubleExample () =
    // <snippet4>
    // Round a positive and a negative value using the default.
    let result = Math.Round(3.45, 1)
    printfn $"{result,4} = Math.Round({3.45,5}, 1)"
    let result = Math.Round(-3.45, 1)
    printfn $"{result,4} = Math.Round({-3.45,5}, 1)\n"

    // Round a positive value using a MidpointRounding value.
    let result = Math.Round(3.45, 1, MidpointRounding.ToEven)
    printfn $"{result,4} = Math.Round({3.45,5}, 1, MidpointRounding.ToEven)"
    let result = Math.Round(3.45, 1, MidpointRounding.AwayFromZero)
    printfn $"{result,4} = Math.Round({3.45,5}, 1, MidpointRounding.AwayFromZero)"
    let result = Math.Round(3.47, 1, MidpointRounding.ToZero)
    printfn $"{result,4} = Math.Round({3.47,5}, 1, MidpointRounding.ToZero)\n"

    // Round a negative value using a MidpointRounding value.
    let result = Math.Round(-3.45, 1, MidpointRounding.ToEven)
    printfn $"{result,4} = Math.Round({-3.45,5}, 1, MidpointRounding.ToEven)"
    let result = Math.Round(-3.45, 1, MidpointRounding.AwayFromZero)
    printfn $"{result,4} = Math.Round({-3.45,5}, 1, MidpointRounding.AwayFromZero)"
    let result = Math.Round(-3.47, 1, MidpointRounding.ToZero)
    printfn $"{result,4} = Math.Round({-3.47,5}, 1, MidpointRounding.ToZero)\n"

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