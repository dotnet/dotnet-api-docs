module trueforall2

// <Snippet2>
open System

let endsWithANumber (value: string) =
    value.Substring(value.Length - 1)
    |> Int32.TryParse
    |> fst

let values1 = [| "Y2K"; "A2000"; "DC2A6"; "MMXIV"; "0C3" |]
let values2 = [| "Y2"; "A2000"; "DC2A6"; "MMXIV_0"; "0C3" |]

if Array.TrueForAll(values1, endsWithANumber) then
    printfn "All elements end with an integer."
else
    printfn "Not all elements end with an integer."

if Array.TrueForAll(values2, endsWithANumber) then
    printfn "All elements end with an integer."
else
    printfn "Not all elements end with an integer."


// The example displays the following output:
//       Not all elements end with an integer.
//       All elements end with an integer.
// </Snippet2>
