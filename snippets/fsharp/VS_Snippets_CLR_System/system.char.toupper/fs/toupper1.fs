module toupper1

// <Snippet1>
open System

let chars = [| 'e'; 'E'; '6'; ','; 'ж'; 'ä' |]

for ch in chars do
    printfn $"""{ch} --> {Char.ToUpper ch} {if ch = Char.ToUpper ch then "(Same Character)" else ""}"""

// The example displays the following output:
//       e --> E
//       E --> E (Same Character)
//       6 --> 6 (Same Character)
//       , --> , (Same Character)
//       ж --> Ж
//       ä --> Ä
// </Snippet1>
