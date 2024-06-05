// <Snippet1>
open System

let displayTuple obj =
    // String interpolation implicitly calls .ToString().
    printfn $"{obj}"

let tuple1Double = Tuple.Create 3.456e-18
displayTuple tuple1Double

let tuple1String = Tuple.Create "Australia"
displayTuple tuple1String

let tuple1Bool = Tuple.Create true
displayTuple tuple1Bool

let tuple1Char = Tuple.Create 'a'
displayTuple tuple1Char
// The example displays the following output:
//       (3.456E-18)
//       (Australia)
//       (True)
//       (a)
// </Snippet1>