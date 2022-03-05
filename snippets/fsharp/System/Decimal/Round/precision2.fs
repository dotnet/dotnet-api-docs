module precision2

// <Snippet8>
open System

let roundApproximate dbl digits margin mode =
    let fraction = dbl * Math.Pow(10, digits)
    let value = Math.Truncate fraction
    let fraction = fraction - value
    if fraction = 0 then
        dbl
    else
        let tolerance = margin * dbl
        // Determine whether this is a midpoint value.
        if (fraction >= 0.5 - tolerance) && (fraction <= 0.5 + tolerance) then
            if mode = MidpointRounding.AwayFromZero then
                (value + 1.) / Math.Pow(10, digits)
            elif value % 2. <> 0 then
                (value + 1.) / Math.Pow(10, digits)
            else
                value / Math.Pow(10, digits)
        // Any remaining fractional value greater than .5 is not a midpoint value.
        elif fraction > 0.5 then
            (value + 1.) / Math.Pow(10, digits)
        else
            value / Math.Pow(10, digits)


let roundValueAndAdd value =
    let tolerance = 8e-14
    let round = roundApproximate value 0 tolerance

    printfn $"{value,5:N1} {value,20:R}  {round MidpointRounding.ToEven,12} {round MidpointRounding.AwayFromZero,15}"
    value + 0.1

printfn "%5s %20s  %12s %15s\n" "Value" "Full Precision" "ToEven" "AwayFromZero"
let mutable value = 11.1
for _ = 0 to 5 do
    value <- roundValueAndAdd value

printfn ""

value <- 11.5
roundValueAndAdd value 
|> ignore

// The example displays the following output:
//       Value       Full Precision        ToEven    AwayFromZero
//
//        11.1                 11.1            11              11
//        11.2                 11.2            11              11
//        11.3   11.299999999999999            11              11
//        11.4   11.399999999999999            11              11
//        11.5   11.499999999999998            12              12
//        11.6   11.599999999999998            12              12
//
//        11.5                 11.5            12              12
// </Snippet8>