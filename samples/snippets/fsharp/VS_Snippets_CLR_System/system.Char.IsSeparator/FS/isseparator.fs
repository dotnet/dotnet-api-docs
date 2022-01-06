module isseparator

// <snippet10>
open System

let str = "twain1 twain2"

printfn $"{Char.IsSeparator 'a'}"       // Output: "False"
printfn $"{Char.IsSeparator(str, 6)}"   // Output: "True"

// </snippet10>
