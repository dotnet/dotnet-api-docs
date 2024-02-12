module toint64_3

// <Snippet16>
open System
open System.Globalization

// Create a NumberFormatInfo object and set the properties that
// affect conversions using Convert.ToInt64(String, IFormatProvider).
let customProvider = NumberFormatInfo()
customProvider.NegativeSign <- "neg "
customProvider.PositiveSign <- "pos "

// Create an array of providers with the custom provider and the
// NumberFormatInfo object for the invariant culture.
let providers =
    [| customProvider; NumberFormatInfo.InvariantInfo |]

// Define an array of strings to parse.
let numericStrings =
    [| "123456789"; "+123456789"; "pos 123456789"
       "-123456789"; "neg 123456789"; "123456789."
       "123,456,789"; "(123456789)"
       "9223372036854775808"; "-9223372036854775809" |]

for i = 0 to 2 do
    let provider = providers[i]
    printfn $"""{if i = 0 then "Custom Provider:" else "Invariant Culture:"}"""
    for numericString in numericStrings do
        printf $"   {numericString,-22} -->  "
        try
            printfn $"{Convert.ToInt32(numericString, provider),22}"
        with
        | :? FormatException ->
            printfn "%22s" "Unrecognized Format"
        | :? OverflowException ->
            printfn "%22s" "Overflow"
    printfn ""

// The example displays the following output:
//       Custom Provider:
//          123456789              -->               123456789
//          +123456789             -->     Unrecognized Format
//          pos 123456789          -->               123456789
//          -123456789             -->     Unrecognized Format
//          neg 123456789          -->              -123456789
//          123456789.             -->     Unrecognized Format
//          123,456,789            -->     Unrecognized Format
//          (123456789)            -->     Unrecognized Format
//          9223372036854775808    -->                Overflow
//          -9223372036854775809   -->     Unrecognized Format
//
//       Invariant Culture:
//          123456789              -->               123456789
//          +123456789             -->               123456789
//          pos 123456789          -->     Unrecognized Format
//          -123456789             -->              -123456789
//          neg 123456789          -->     Unrecognized Format
//          123456789.             -->     Unrecognized Format
//          123,456,789            -->     Unrecognized Format
//          (123456789)            -->     Unrecognized Format
//          9223372036854775808    -->                Overflow
//          -9223372036854775809   -->                Overflow
// </Snippet16>