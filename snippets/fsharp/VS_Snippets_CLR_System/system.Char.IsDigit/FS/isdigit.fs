// <snippet4>
open System

let ch = '8'

printfn $"{Char.IsDigit ch}"                        // Output: "True"
printfn $"""{Char.IsDigit("sample string", 7)}"""   // Output: "False"
// </snippet4>
