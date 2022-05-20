module single1

// <Snippet1>
// In F#, 'float', 'float64', and 'double' are aliases for System.Double...
// 'float32' and 'single' are aliases for System.Single
open System

let value = 16.325f
printfn $"Widening Conversion of {value:R} (type {value.GetType().Name}) to {double value:R} (type {(double value).GetType().Name}): "
printfn $"{Math.Round(decimal value, 2)}"
printfn $"{Math.Round(decimal value, 2, MidpointRounding.AwayFromZero)}"
printfn ""

let decValue = decimal value
printfn $"Cast of {value:R} (type {value.GetType().Name}) to {decValue} (type {decValue.GetType().Name}): "
printfn $"{Math.Round(decValue, 2)}"
printfn $"{Math.Round(decValue, 2, MidpointRounding.AwayFromZero)}"

// The example displays the following output:
//    Widening Conversion of 16.325 (type Single) to 16.325000762939453 (type Double):
//    16.33
//    16.33
//
//    Cast of 16.325 (type Single) to 16.325 (type Decimal):
//    16.32
//    16.33
// </Snippet1>