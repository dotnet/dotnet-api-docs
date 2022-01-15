// <snippet1>
open System

let ch2 = '2'
let str = "Upper Case"

printfn $"{Char.GetUnicodeCategory 'a'}"        // Output: "LowercaseLetter"
printfn $"{Char.GetUnicodeCategory ch2}"        // Output: "DecimalDigitNumber"
printfn $"{Char.GetUnicodeCategory(str, 6)}"    // Output: "UppercaseLetter"
// </snippet1>