module OOR1
// <Snippet1>
open System

let dimension1 = 10
let dimension2 = -1
try
    let arr = Array.CreateInstance(typeof<string>, dimension1, dimension2)
    printfn "%A" arr
with 
| :? ArgumentOutOfRangeException as e ->
    if not (isNull e.ActualValue) then
        printfn $"{e.ActualValue} is an invalid value for {e.ParamName}: "
    printfn $"{e.Message}"

// The example displays the following output:
//     Non-negative number required. (Parameter 'length2')
// </Snippet1>

module Example2 =
    let makeValid () =
        // <Snippet2>
        let dimension1 = 10
        let dimension2 = 10
        let arr = Array.CreateInstance(typeof<string>, dimension1, dimension2)
        printfn "%A" arr
        // </Snippet2>

    let validate () =
        let dimension1 = 10
        let dimension2 = 10
        // <Snippet3>
        if dimension1 < 0 || dimension2 < 0 then
            printfn "Unable to create the array."
            printfn "Specify non-negative values for the two dimensions."
        else
            let arr = Array.CreateInstance(typeof<string>, dimension1, dimension2)
            printfn "%A" arr
        // </Snippet3>