module EnumParse

//<snippet1>
open System

[<Flags>]
type Colors =
    | Red = 1
    | Green = 2
    | Blue = 4
    | Yellow = 8

printfn "The entries of the Colors enumeration are:"
for colorName in Enum.GetNames typeof<Colors> do
    printfn $"{colorName} = {Enum.Parse(typeof<Colors>, colorName):D}"
printfn ""

let orange = Enum.Parse(typeof<Colors>, "Red, Yellow") :?> Colors
printfn $"The orange value {orange:D} has the combined entries of {orange}"

// This code example produces the following results:
//     The entries of the Colors Enum are:
//     Red = 1
//     Green = 2
//     Blue = 4
//     Yellow = 8
//    
//     The orange value 9 has the combined entries of Red, Yellow

//</snippet1>