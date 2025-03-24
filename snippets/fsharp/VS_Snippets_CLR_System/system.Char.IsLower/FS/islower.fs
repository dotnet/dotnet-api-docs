// <snippet7>
open System

let ch = 'a'

printfn $"{Char.IsLower ch}"                    // Output: "True"
printfn $"""{Char.IsLower("upperCase", 5)}"""   // Output: "False"
// </snippet7>