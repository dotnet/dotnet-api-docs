module Delegate

// <Snippet1>
type ConvertMethod = delegate of string -> string

let uppercaseString (inputString: string) =
    inputString.ToUpper()
    
// Instantiate delegate to reference uppercaseString function
let convertMeth = ConvertMethod uppercaseString
let name = "Dakota"

// Use delegate instance to call uppercaseString function
printfn $"{convertMeth.Invoke name}"
// </Snippet1>