module tostring

//<snippet1>
open System

[<EntryPoint>]
let main _ =
    let str1 = "123"
    let str2 = "abc"
    printfn $"Original str1: {str1}"
    printfn $"Original str2: {str2}"
    printfn $"str1 same as str2?: {Object.ReferenceEquals(str1, str2)}"

    let str2 = str1.ToString()
    printfn $"\nNew str2:      {str2}"
    printfn $"str1 same as str2?: {Object.ReferenceEquals(str1, str2)}"
    0

(*
This code produces the following output:
Original str1: 123
Original str2: abc
str1 same as str2?: False

New str2:      123
str1 same as str2?: True
*)
//</snippet1>