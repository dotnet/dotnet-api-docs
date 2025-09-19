module touint64

// <Snippet16>
open System

let hexStrings =
    [| "8000000000000000"; "0FFFFFFFFFFFFFFF"
       "F000000000000000"; "00A3000000000000"
       "D"; "-13"; "9AC61"; "GAD"
       "FFFFFFFFFFFFFFFFF" |]

for hexString in hexStrings do
    printf $"{hexString,-18}  -->  "
    try
        let number = Convert.ToUInt64(hexString, 16)
        printfn $"{number,26:N0}"
    with
    | :? FormatException ->
        printfn "%26s" "Bad Format"
    | :? OverflowException ->
        printfn "%26s" "Numeric Overflow"
    | :? ArgumentException ->
        printfn "%26s" "Invalid in Base 16"
// The example displays the following output:
//    8000000000000000    -->   9,223,372,036,854,775,808
//    0FFFFFFFFFFFFFFF    -->   1,152,921,504,606,846,975
//    F000000000000000    -->  17,293,822,569,102,704,640
//    00A3000000000000    -->      45,880,421,203,836,928
//    D                   -->                          13
//    -13                 -->          Invalid in Base 16
//    9AC61               -->                     633,953
//    GAD                 -->                  Bad Format
//    FFFFFFFFFFFFFFFFF   -->            Numeric Overflow
// </Snippet16>