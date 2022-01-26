// <snippet9>
open System

let ch = '.'

printfn $"{Char.IsPunctuation ch}"                       // Output: "True"
printfn $"""{Char.IsPunctuation("no punctuation", 3)}""" // Output: "False"

// </snippet9>
