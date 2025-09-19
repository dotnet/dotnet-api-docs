// <snippet11>
open System

let str = "\U00010F00" // Unicode values between 0x10000 and 0x10FFF are represented by two 16-bit "surrogate" characters

printfn $"{Char.IsSurrogate 'a'}"       // Output: "False"
printfn $"{Char.IsSurrogate(str, 0)}"   // Output: "True"

// </snippet11>
