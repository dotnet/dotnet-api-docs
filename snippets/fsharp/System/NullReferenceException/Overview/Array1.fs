module Array1

// <Snippet8>
open System

let values = [| "one"; null; "two" |]
for i = 0 to values.GetUpperBound 0 do
    printfn $"""{values[i].Trim()}{if i = values.GetUpperBound 0 then "" else ", "}"""
printfn ""
// The example displays the following output:
//    Unhandled Exception:
//       System.NullReferenceException: Object reference not set to an instance of an object.
//       at <StartupCode$fs>.main()
// </Snippet8>