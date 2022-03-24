module CreateInstance5
// <Snippet5>
open System

// Initialize array of characters from a to z.
let chars = [| 'a' .. 'z' |]

let obj = Activator.CreateInstance(typeof<string>, chars[13..22])

printfn $"{obj}"

// The example displays the following output:
//       nopqrstuvw
// </Snippet5>
