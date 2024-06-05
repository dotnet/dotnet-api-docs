// <Snippet15>
open System
open System.Globalization

// Create a custom NumberFormatInfo object and set its two properties
// used by default in parsing numeric strings.
let customProvider = NumberFormatInfo()
customProvider.NegativeSign <- "neg "
customProvider.PositiveSign <- "pos "

// Add custom and invariant provider to an array of providers.
let providers =
    [| customProvider; NumberFormatInfo.InvariantInfo |]

// Define an array of strings to convert.
let numericStrings =
    [| "123456789"; "+123456789"; "pos 123456789"
       "-123456789"; "neg 123456789"; "123456789."
       "123,456,789"; "(123456789)"; "2147483648"
       "-2147483649"; |]

// Use each provider to parse all the numeric strings.
for i = 0 to 1 do
    let provider = providers[i]
    printfn $"""{if i = 0 then "Custom Provider:" else "Invariant Provider:"}"""
    for numericString in numericStrings do
        printf $"{numericString,15}  --> "
        try
            printfn $"{Convert.ToInt32(numericString, provider),20}"
        with
        | :? FormatException ->
            printfn "%20s" "FormatException"
        | :? OverflowException ->
            printfn "%20s" "OverflowException"
    printfn ""
// The example displays the following output:
//       Custom Provider:
//             123456789  -->            123456789
//            +123456789  -->      FormatException
//         pos 123456789  -->            123456789
//            -123456789  -->      FormatException
//         neg 123456789  -->           -123456789
//            123456789.  -->      FormatException
//           123,456,789  -->      FormatException
//           (123456789)  -->      FormatException
//            2147483648  -->    OverflowException
//           -2147483649  -->      FormatException
//
//       Invariant Provider:
//             123456789  -->            123456789
//            +123456789  -->            123456789
//         pos 123456789  -->      FormatException
//            -123456789  -->           -123456789
//         neg 123456789  -->      FormatException
//            123456789.  -->      FormatException
//           123,456,789  -->      FormatException
//           (123456789)  -->      FormatException
//            2147483648  -->    OverflowException
//           -2147483649  -->    OverflowException
// </Snippet15>