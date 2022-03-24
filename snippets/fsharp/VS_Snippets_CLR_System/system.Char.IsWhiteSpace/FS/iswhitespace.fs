// <snippet14>
open System

let str = "black matter"

printfn $"{Char.IsWhiteSpace 'A'}"      // Output: "False"
printfn $"{Char.IsWhiteSpace(str, 5)}"  // Output: "True"

// </snippet14>
