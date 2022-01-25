module getnumericvalue1

// <snippet1>
open System

let str = "input: 1"

printfn $"{Char.GetNumericValue '8'}"       // Output: "8"
printfn $"{Char.GetNumericValue(str, 7)}"   // Output: "1"

// </snippet1>