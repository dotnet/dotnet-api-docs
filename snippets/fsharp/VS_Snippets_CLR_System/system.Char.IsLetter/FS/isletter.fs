// <snippet5>
open System

let ch = '8'

printfn $"{Char.IsLetter ch}"                       // False
printfn $"""{Char.IsLetter("sample string", 7)}"""  // True

// </snippet5>
