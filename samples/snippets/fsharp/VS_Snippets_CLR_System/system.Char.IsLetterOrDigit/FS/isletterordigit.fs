// <snippet6>
open System

let str = "newline:\n"

printfn $"{Char.IsLetterOrDigit '8'}"       // Output: "True"
printfn $"{Char.IsLetterOrDigit(str, 8)}"   // Output: "False", because it's a newline

// </snippet6>
