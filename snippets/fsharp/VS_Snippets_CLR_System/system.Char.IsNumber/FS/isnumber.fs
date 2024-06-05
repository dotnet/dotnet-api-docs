module isnumber

// <snippet8>
open System

let str = "non-numeric"

printfn $"{Char.IsNumber '8'}"      // Output: "True"
printfn $"{Char.IsNumber(str, 3)}"  // Output: "False"

// </snippet8>
