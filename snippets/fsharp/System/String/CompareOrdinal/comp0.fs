module comp0

//<snippet1>
// Sample for String.CompareOrdinal(String, String)
open System

let str1 = "ABCD"
let str2 = "abcd"

printfn "\nCompare the numeric values of the corresponding Char objects in each string."
printfn $"str1 = '{str1}', str2 = '{str2}'"
let result = String.CompareOrdinal(str1, str2)
let str = if result < 0 then "less than" elif result > 0 then "greater than" else "equal to"
printf $"String '{str1}' is "
printf $"{str} "
printfn $"String '{str2}'."

(*
This example produces the following results:

Compare the numeric values of the corresponding Char objects in each string.
str1 = 'ABCD', str2 = 'abcd'
String 'ABCD' is less than String 'abcd'.
*)
//</snippet1>