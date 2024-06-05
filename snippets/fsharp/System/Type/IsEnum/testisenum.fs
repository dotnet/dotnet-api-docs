// <Snippet1>
open System
type Color =
    | Red = 0
    | Blue = 1
    | Green = 2

let colorType = typeof<Color>
let enumType = typeof<Enum>
printfn $"Is Color an enum? {colorType.IsEnum}."
printfn $"Is Color a value type? {colorType.IsValueType}."
printfn $"Is Enum an enum Type? {enumType.IsEnum}."
printfn $"Is Enum a value type? {enumType.IsValueType}."
// The example displays the following output:
//     Is Color an enum? True.
//     Is Color a value type? True.
//     Is Enum an enum type? False.
//     Is Enum a value type? False.
// </Snippet1>