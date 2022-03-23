module touint32_2

// <Snippet15>
open System
open System.Globalization

// Create a NumberFormatInfo object and set several of its
// properties that apply to numbers.
let provider = NumberFormatInfo()
provider.PositiveSign <- "pos "
provider.NegativeSign <- "neg "

// Define an array of numeric strings.
let values =
    [| "123456789"; "+123456789"; "pos 123456789"
       "123456789."; "123,456,789"; "4294967295"
       "4294967296"; "-1"; "neg 1" |]

for value in values do
    printf $"{value,-20} -->"
    
    try
        printfn $"{Convert.ToUInt32(value, provider),20}"
    with
    | :? FormatException ->
        printfn "%20s" "Bad Format"
    | :? OverflowException ->
        printfn "%20s" "Numeric Overflow"
// The example displays the following output:
//       123456789            -->           123456789
//       +123456789           -->          Bad Format
//       pos 123456789        -->           123456789
//       123456789.           -->          Bad Format
//       123,456,789          -->          Bad Format
//       4294967295           -->          4294967295
//       4294967296           -->    Numeric Overflow
//       -1                   -->          Bad Format
//       neg 1                -->    Numeric Overflow
// </Snippet15>