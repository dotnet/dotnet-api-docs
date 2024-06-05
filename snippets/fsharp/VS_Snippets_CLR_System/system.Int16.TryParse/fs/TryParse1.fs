module TryParse1

// <Snippet1>
open System

let tryToParse (value: string) =
    match Int16.TryParse value with
    | true, number -> printfn "Converted '{value}' to {number}."
    | _ ->
        let value = if isNull value then "" else value
        printfn $"Attempted conversion of '{value}' failed."

tryToParse null
tryToParse "16051"
tryToParse "9432.0"
tryToParse "16,667"
tryToParse "   -322   "
tryToParse "+4302"
tryToParse "(100);"
tryToParse "01FA"

// The example displays the following output to the console:
//       Attempted conversion of '' failed.
//       Converted '16051' to 16051.
//       Attempted conversion of '9432.0' failed.
//       Attempted conversion of '16,667' failed.
//       Converted '   -322   ' to -322.
//       Converted '+4302' to 4302.
//       Attempted conversion of '(100)' failed.
//       Attempted conversion of '01FA' failed.
// </Snippet1>
