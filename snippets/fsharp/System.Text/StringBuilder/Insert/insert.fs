// This example demonstrates StringBuilder.Insert()
//<snippet1>
open System.Text

let initialValue = "--[]--"

let show overloadNumber (sbs: StringBuilder) =
    printfn $"{overloadNumber, 2:G} = {sbs}"
    sbs.Clear().Append initialValue |> ignore

let xyz = "xyz"
let abc = [| 'a'; 'b'; 'c' |]
let star = '*'
let obj: obj = 0

let xBool = true
let xByte = 1uy
let xInt16 = 2s
let xInt32 = 3
let xInt64 = 4L
let xDecimal = 5M
let xSingle = 6.6f
let xDouble = 7.7

// The following types are not CLS-compliant.
let xUInt16 = 8us
let xUInt32 = 9u
let xUInt64 = 10uL
let xSByte = -11y

printfn "StringBuilder.Insert method"
let sb = StringBuilder initialValue

sb.Insert(3, xyz, 2) |> ignore
show 1 sb

sb.Insert(3, xyz) |> ignore
show 2 sb

sb.Insert(3, star) |> ignore
show 3 sb

sb.Insert(3, abc) |> ignore
show 4 sb

sb.Insert(3, abc, 1, 2) |> ignore
show 5 sb

sb.Insert(3, xBool) |> ignore // True
show 6 sb

sb.Insert(3, obj) |> ignore // 0
show 7 sb

sb.Insert(3, xByte) |> ignore // 1
show 8 sb

sb.Insert(3, xInt16) |> ignore // 2
show 9 sb

sb.Insert(3, xInt32) |> ignore // 3
show 10 sb

sb.Insert(3, xInt64) |> ignore // 4
show 11 sb

sb.Insert(3, xDecimal) |> ignore // 5
show 12 sb

sb.Insert(3, xSingle) |> ignore // 6.6
show 13 sb

sb.Insert(3, xDouble) |> ignore // 7.7
show 14 sb

// The following Insert methods are not CLS-compliant.
sb.Insert(3, xUInt16) |> ignore // 8
show 15 sb

sb.Insert(3, xUInt32) |> ignore // 9
show 16 sb

sb.Insert(3, xUInt64) |> ignore // 10
show 17 sb

sb.Insert(3, xSByte) |> ignore // -11
show 18 sb

// This example produces the following results:
//       StringBuilder.Insert method
//        1 = --[xyzxyz]--
//        2 = --[xyz]--
//        3 = --[*]--
//        4 = --[abc]--
//        5 = --[bc]--
//        6 = --[True]--
//        7 = --[0]--
//        8 = --[1]--
//        9 = --[2]--
//       10 = --[3]--
//       11 = --[4]--
//       12 = --[5]--
//       13 = --[6.6]--
//       14 = --[7.7]--
//       15 = --[8]--
//       16 = --[9]--
//       17 = --[10]--
//       18 = --[-11]--
//</snippet1>
