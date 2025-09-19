module trueforall1

// <Snippet1>
open System

let values = [| "Y2K"; "A2000"; "DC2A6"; "MMXIV"; "0C3" |]
if Array.TrueForAll(values, 
    fun value -> 
        value.Substring(value.Length - 1) 
        |> Int32.TryParse 
        |> fst) then
    printfn "All elements end with an integer."
else
    printfn "Not all elements end with an integer."
   
   
// The example displays the following output:
//        Not all elements end with an integer.
// </Snippet1>