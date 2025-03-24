module isdefnied1

// <Snippet1>
open System

[<Flags>]
type PetType =
    | None = 0
    | Dog = 1
    | Cat = 2
    | Rodent = 4
    | Bird = 8
    | Reptile = 16
    | Other = 32

[<EntryPoint>]
let main _ =
    // Call IsDefined with underlying integral value of member.
    let value = 1
    printfn $"{value}: {Enum.IsDefined(typeof<PetType>, value)}"
    // Call IsDefined with invalid underlying integral value.
    let value = 64
    printfn $"{value}: {Enum.IsDefined(typeof<PetType>, value)}"
    // Call IsDefined with string containing member name.
    let value = "Rodent"
    printfn $"{value}: {Enum.IsDefined(typeof<PetType>, value)}"
    // Call IsDefined with a variable of type PetType.
    let value = PetType.Dog
    printfn $"{value}: {Enum.IsDefined(typeof<PetType>, value)}"
    let value = PetType.Dog ||| PetType.Cat
    printfn $"{value}: {Enum.IsDefined(typeof<PetType>, value)}"
    // Call IsDefined with uppercase member name.
    let value = "None"
    printfn $"{value}: {Enum.IsDefined(typeof<PetType>, value)}"
    let value = "NONE"
    printfn $"{value}: {Enum.IsDefined(typeof<PetType>, value)}"
    // Call IsDefined with combined value
    let value = PetType.Dog ||| PetType.Bird
    printfn $"{value:D}: {Enum.IsDefined(typeof<PetType>, value)}"
    let value = value.ToString()
    printfn $"{value:D}: {Enum.IsDefined(typeof<PetType>, value)}"
    0
// The example displays the following output:
//       1: True
//       64: False
//       Rodent: True
//       Dog: True
//       Dog, Cat: False
//       None: True
//       NONE: False
//       9: False
//       Dog, Bird: False
// </Snippet1>