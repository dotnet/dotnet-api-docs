module touint16_4

// <Snippet18>
open System
open System.Globalization

// Create a NumberFormatInfo object and set several of its
// properties that apply to numbers.
let provider = NumberFormatInfo()
provider.PositiveSign <- "pos "
provider.NegativeSign <- "neg "

// Define an array of strings to convert to UInt16 values.
let values =
    [| "34567"; "+34567"; "pos 34567"; "34567."
       "34567."; "65535"; "65535"; "65535" |]

for value in values do
    printf $"{value,-12}  -->  "
    try
        printfn $"{Convert.ToUInt16(value, provider),17}"
    with :? FormatException as e ->
        printfn $"{e.GetType().Name,17}"
// The example displays the following output:
//       34567         -->              34567
//       +34567        -->    FormatException
//       pos 34567     -->              34567
//       34567.        -->    FormatException
//       34567.        -->    FormatException
//       65535         -->              65535
//       65535         -->              65535
//       65535         -->              65535
// </Snippet18>