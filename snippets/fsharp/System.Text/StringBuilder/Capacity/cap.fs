// This example demonstrates StringBuilder.EnsureCapacity
//                           StringBuilder.Capacity
//                           StringBuilder.Length
//                           StringBuilder.Equals
//<snippet1>
open System.Text

let sb1 = StringBuilder "abc"
let sb2 = StringBuilder("abc", 16)

printfn $"a1) sb1.Length = {sb1.Length}, sb1.Capacity = {sb1.Capacity}"
printfn $"a2) sb2.Length = {sb2.Length}, sb2.Capacity = {sb2.Capacity}"
printfn $"a3) sb1.ToString() = \"{sb1}\", sb2.ToString() = \"{sb2}\""
printfn $"a4) sb1 equals sb2: {sb1.Equals sb2}"

printfn "\nEnsure sb1 has a capacity of at least 50 characters."
sb1.EnsureCapacity 50 |> ignore

printfn $"\nb1) sb1.Length = {sb1.Length}, sb1.Capacity = {sb1.Capacity}"
printfn $"b2) sb2.Length = {sb2.Length}, sb2.Capacity = {sb2.Capacity}"
printfn $"b3) sb1.ToString() = \"{sb1}\", sb2.ToString() = \"{sb2}\""
printfn $"b4) sb1 equals sb2: {sb1.Equals sb2}"

printfn "\nSet the length of sb1 to zero."
printfn "Set the capacity of sb2 to 51 characters."
sb1.Length <- 0
sb2.Capacity <- 51

printfn $"\nc1) sb1.Length = {sb1.Length}, sb1.Capacity = {sb1.Capacity}"
printfn $"c2) sb2.Length = {sb2.Length}, sb2.Capacity = {sb2.Capacity}"
printfn $"c3) sb1.ToString() = \"{sb1}\", sb2.ToString() = \"{sb2}\""
printfn $"c4) sb1 equals sb2: {sb1.Equals sb2}"

// The example displays the following output:
//       a1) sb1.Length = 3, sb1.Capacity = 16
//       a2) sb2.Length = 3, sb2.Capacity = 16
//       a3) sb1.ToString() = "abc", sb2.ToString() = "abc"
//       a4) sb1 equals sb2: True
//
//       Ensure sb1 has a capacity of at least 50 characters.
//       
//       b1) sb1.Length = 3, sb1.Capacity = 50
//       b2) sb2.Length = 3, sb2.Capacity = 16
//       b3) sb1.ToString() = "abc", sb2.ToString() = "abc"
//       b4) sb1 equals sb2: False
//       
//       Set the length of sb1 to zero.
//       Set the capacity of sb2 to 51 characters.
//       
//       c1) sb1.Length = 0, sb1.Capacity = 50
//       c2) sb2.Length = 3, sb2.Capacity = 51
//       c3) sb1.ToString() = "", sb2.ToString() = "abc"
//       c4) sb1 equals sb2: False
//</snippet1>