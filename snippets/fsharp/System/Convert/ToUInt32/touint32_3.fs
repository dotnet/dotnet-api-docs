module touint32_3

// <Snippet16>
open System

let hexStrings =
    [| "80000000"; "0FFFFFFF"; "F0000000"; "00A3000"
       "D"; "-13"; "9AC61"; "GAD"; "FFFFFFFFFF" |]

for hexString in hexStrings do
    printf $"{hexString,-12}  -->  "
    try
        let number = Convert.ToUInt32(hexString, 16)
        printfn $"{number,18:N0}"
    with
    | :? FormatException ->
        printfn "%18s" "Bad Format"
    | :? OverflowException ->
        printfn "%18s" "Numeric Overflow"
    | :? ArgumentException ->
        printfn "%18s" "Invalid in Base 16"
// The example displays the following output:
//       80000000      -->       2,147,483,648
//       0FFFFFFF      -->         268,435,455
//       F0000000      -->       4,026,531,840
//       00A3000       -->             667,648
//       D             -->                  13
//       -13           -->  Invalid in Base 16
//       9AC61         -->             633,953
//       GAD           -->          Bad Format
//       FFFFFFFFFF    -->    Numeric Overflow
// </Snippet16>