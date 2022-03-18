// <snippet12>
open System

let str = "non-symbolic characters"

printfn $"{Char.IsSymbol '+'}"      // Output: "True"
printfn $"{Char.IsSymbol(str, 8)}"  // Output: "False"

// </snippet12>
