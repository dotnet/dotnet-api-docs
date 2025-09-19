module TryParse1

// <Snippet1>
open System

let values = 
   [ null; "160519"; "9432.0"; "16,667"
     "   -322   "; "+4302"; "(100);"; "01FA" ]
for value in values do
    match Int32.TryParse value with
    | true, number -> 
        printfn $"Converted '{value}' to {number}."
    | _ -> 
        printfn $"""Attempted conversion of '{if isNull value then "<null>" else value}' failed."""
         
// The example displays the following output:
//       Attempted conversion of '<null>' failed.
//       Converted '160519' to 160519.
//       Attempted conversion of '9432.0' failed.
//       Attempted conversion of '16,667' failed.
//       Converted '   -322   ' to -322.
//       Converted '+4302' to 4302.
//       Attempted conversion of '(100);' failed.
//       Attempted conversion of '01FA' failed.
// </Snippet1>
