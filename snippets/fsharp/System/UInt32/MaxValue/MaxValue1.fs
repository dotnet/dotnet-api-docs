open System 

// <Snippet1>
let longValue = Int64.MaxValue / 2L

if longValue <= int64 UInt32.MaxValue && longValue >= int64 UInt32.MinValue then
    let integerValue = uint longValue 
    printfn $"Converted long integer value to {integerValue:n0}." 
else
    let rangeLimit, relationship = 
        if longValue > int64 UInt32.MaxValue then
            UInt32.MaxValue, "greater" 
        else
            UInt32.MinValue, "less" 

    printfn $"Conversion failure: {longValue:n0} is {relationship} than {rangeLimit:n0}"
// </Snippet1>