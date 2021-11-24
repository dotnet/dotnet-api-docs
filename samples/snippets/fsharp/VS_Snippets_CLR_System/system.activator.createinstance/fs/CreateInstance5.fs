module CreateInstance5
// <Snippet5>
open System

// Initialize array of characters from a to z.

let chars = Array.zeroCreate 26

for i = 0 to 25 do
    chars[i] <- char (i + 0x0061)

let obj = Activator.CreateInstance(typeof<string>, chars[13..22])

printfn $"{obj}"

// The example displays the following output:
//       nopqrstuvw
// </Snippet5>
