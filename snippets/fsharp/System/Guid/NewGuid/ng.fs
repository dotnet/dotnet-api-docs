//<snippet1>
open System

// Create and display the value of two GUIDs.
let g = Guid.NewGuid()
printfn $"{g}"
printfn $"{Guid.NewGuid()}"

// This code example produces a result similar to the following:
//     0f8fad5b-d9cb-469f-a165-70867728950e
//     7c9e6679-7425-40de-944b-e07fc1f90ae7
//</snippet1>