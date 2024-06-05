open System

// <Snippet1>
let longValue = -130L

if longValue <= int64 SByte.MaxValue && longValue >= int64 SByte.MinValue then
    let byteValue = int8 longValue
    printfn $"Converted long integer value to {byteValue}."
else
    let rangeLimit, relationship =
        if longValue > int64 SByte.MaxValue then
            SByte.MaxValue, "greater"
        else
            SByte.MinValue, "less"

    printfn $"Conversion failure: {longValue:n0} is {relationship} than {rangeLimit}."
// </Snippet1>