// <Snippet1>
open System

let integerValue = 1216

if integerValue >= int UInt16.MinValue && integerValue <= int UInt16.MaxValue then
    let uIntegerValue = uint16 integerValue
    printfn $"{uIntegerValue}"
else
    printfn $"Unable to convert {integerValue} to a UInt16t."
// </Snippet1>