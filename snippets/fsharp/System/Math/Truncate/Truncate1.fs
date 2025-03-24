
open System

let main _ =
    // <Snippet1>
    let floatNumber = 32.7865
    // Displays 32
    printfn $"{Math.Truncate floatNumber}"
    // printfn $"{truncate floatNumber}"
 
    let floatNumber = -32.9012
    // Displays -32
    printfn $"{Math.Truncate floatNumber}"
    // </Snippet1>
 
    // <Snippet2>
    let decimalNumber = 32.7865m
    // Displays 32
    printfn $"{Math.Truncate decimalNumber}"
 
    let decimalNumber = -32.9012m
    // Displays -32
    printfn $"{Math.Truncate decimalNumber}"
    // </Snippet2>
    0