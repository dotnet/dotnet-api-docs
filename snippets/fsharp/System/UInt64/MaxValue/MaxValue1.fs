// <Snippet1>
open System

let decimalValue = -1.5

// Discard fractional portion of Double value
let decimalInteger = floor decimalValue

if decimalInteger <= float UInt64.MaxValue && decimalInteger >= float UInt64.MinValue then
    let integerValue = uint64 decimalValue
    printfn $"Converted {decimalValue} to {integerValue}."
else
    let rangeLimit, relationship =
        if decimalInteger > float UInt64.MaxValue then
            UInt64.MaxValue, "greater"
        else
            UInt64.MinValue, "less"

    printfn $"Conversion failure: {decimalInteger} is {relationship} than {rangeLimit}."
// </Snippet1>