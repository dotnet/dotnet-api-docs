open System
open System.Numerics

// <Snippet1>
let number1 = BigInteger.Pow(int64 System.Int64.MaxValue, 100)
let number2 = number1 + 1I
let relation = 
    match BigInteger.Compare(number1, number2) with
    | -1 -> "<"
    | 0 -> "="
    | 1 | _ -> ">"

printfn $"{number1} {relation} {number2}"
// The example displays the following output:
//    3.0829940252776347122742186219E+1896 < 3.0829940252776347122742186219E+1896
// </Snippet1>
