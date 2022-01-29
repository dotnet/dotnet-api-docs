module Func2_1

// <Snippet2>
open System

let uppercaseString (inputString: string) =
    inputString.ToUpper()

// Instantiate delegate to reference uppercaseString function
let convertMethod = Func<string, string> uppercaseString
let name = "Dakota"

// Use delegate instance to call uppercaseString function
printfn $"{convertMethod.Invoke name}"

// This code example produces the following output:
//    DAKOTA
// </Snippet2>