module Substring10.fs
open System

//<snippet10>
let info = 
    [| "Name: Felica Walker"; "Title: Mz."
       "Age: 47"; "Location: Paris"; "Gender: F" |]

printfn "The initial values in the array are:"
for s in info do
    printfn $"{s}"

printfn "\nWe want to retrieve only the key information. That is:"
for s in info do
    let found = s.IndexOf ": "
    printfn $"   {s.Substring(found + 2)}"

// The example displays the following output:
//       The initial values in the array are:
//       Name: Felica Walker
//       Title: Mz.
//       Age: 47
//       Location: Paris
//       Gender: F
//
//       We want to retrieve only the key information. That is:
//          Felica Walker
//          Mz.
//          47
//          Paris
//          F
//</snippet10>
