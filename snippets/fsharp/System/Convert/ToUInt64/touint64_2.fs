module touint64_2

// <Snippet15>
open System
open System.Globalization

// Create a NumberFormatInfo object and set several properties.
let provider = NumberFormatInfo()
provider.PositiveSign <- "pos "
provider.NegativeSign <- "neg "

// Define an array of numeric strings.
let values =
    [| "123456789012"; "+123456789012"
       "pos 123456789012"; "123456789012."
       "123,456,789,012"; "18446744073709551615"
       "18446744073709551616"; "neg 1"; "-1" |]

// Convert the strings using the format provider.
for value in values do
    printf $"{value,-20}  -->  "
    try
        printfn $"{Convert.ToUInt64(value, provider),20}"
    with
    | :? FormatException ->
        printfn "%20s" "Invalid Format"
    | :? OverflowException ->
        printfn "%20s" "Numeric Overflow"
// The example displays the following output:
//    123456789012          -->          123456789012
//    +123456789012         -->        Invalid Format
//    pos 123456789012      -->          123456789012
//    123456789012.         -->        Invalid Format
//    123,456,789,012       -->        Invalid Format
//    18446744073709551615  -->  18446744073709551615
//    18446744073709551616  -->      Numeric Overflow
//    neg 1                 -->      Numeric Overflow
//    -1                    -->        Invalid Format
// </Snippet15>