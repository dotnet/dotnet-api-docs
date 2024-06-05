module isdefined2

// <Snippet2>
open System

[<Flags>]
type Pets =
    | None = 0
    | Dog = 1
    | Cat = 2
    | Bird = 4
    | Rodent = 8
    | Other = 16

let value = Pets.Dog ||| Pets.Cat
printfn $"{value:D} Exists: {Pets.IsDefined(typeof<Pets>, value)}"
let name = string value
printfn $"{name} Exists: {Pets.IsDefined(typeof<Pets>, name)}"
// The example displays the following output:
//       3 Exists: False
//       Dog, Cat Exists: False
// </Snippet2>