module parse3

// <Snippet4>
open System
open System.Globalization

// Define a list of string values.
let values = 
    [ " 987.654E-2"; " 987,654E-2"; "(98765,43210)"
      "9,876,543.210"; "9.876.543,210"; "98_76_54_32,19" ]
// Create a custom culture based on the invariant culture.
let ci = CultureInfo ""
ci.NumberFormat.NumberGroupSizes <- [| 2 |]
ci.NumberFormat.NumberGroupSeparator <- "_"

// Define a list of format providers.
let providers = 
    [ CultureInfo "en-US"
      CultureInfo "nl-NL"
      ci ]

// Define a list of styles.
let styles = [ NumberStyles.Currency; NumberStyles.Float ]

// Iterate the list of format providers.
for provider in providers do
    printfn $"""Parsing using the {if provider.Name = String.Empty then "Invariant" else provider.Name} culture:"""
    // Parse each element in the array of string values.
    for value in values do
        for style in styles do
            try
                let number = Single.Parse(value, style, provider)
                printfn $"   {value} ({style}) -> {number}"
            with
            | :? FormatException ->
                printfn $"   '{value}' is invalid using {style}."
            | :? OverflowException ->
                printfn $"   '{value}' is out of the range of a Single."
    printfn ""

// The example displays the following output:
// Parsing using the en-US culture:
//    ' 987.654E-2' is invalid using Currency.
//     987.654E-2 (Float) -> 9.87654
//    ' 987,654E-2' is invalid using Currency.
//    ' 987,654E-2' is invalid using Float.
//    (98765,43210) (Currency) -> -9.876543E+09
//    '(98765,43210)' is invalid using Float.
//    9,876,543.210 (Currency) -> 9876543
//    '9,876,543.210' is invalid using Float.
//    '9.876.543,210' is invalid using Currency.
//    '9.876.543,210' is invalid using Float.
//    '98_76_54_32,19' is invalid using Currency.
//    '98_76_54_32,19' is invalid using Float.
//
// Parsing using the nl-NL culture:
//    ' 987.654E-2' is invalid using Currency.
//    ' 987.654E-2' is invalid using Float.
//    ' 987,654E-2' is invalid using Currency.
//     987,654E-2 (Float) -> 9.87654
//    (98765,43210) (Currency) -> -98765.43
//    '(98765,43210)' is invalid using Float.
//    '9,876,543.210' is invalid using Currency.
//    '9,876,543.210' is invalid using Float.
//    9.876.543,210 (Currency) -> 9876543
//    '9.876.543,210' is invalid using Float.
//    '98_76_54_32,19' is invalid using Currency.
//    '98_76_54_32,19' is invalid using Float.
//
// Parsing using the Invariant culture:
//    ' 987.654E-2' is invalid using Currency.
//     987.654E-2 (Float) -> 9.87654
//    ' 987,654E-2' is invalid using Currency.
//    ' 987,654E-2' is invalid using Float.
//    (98765,43210) (Currency) -> -9.876543E+09
//    '(98765,43210)' is invalid using Float.
//    9,876,543.210 (Currency) -> 9876543
//    '9,876,543.210' is invalid using Float.
//    '9.876.543,210' is invalid using Currency.
//    '9.876.543,210' is invalid using Float.
//    98_76_54_32,19 (Currency) -> 9.876543E+09
//    '98_76_54_32,19' is invalid using Float.
// </Snippet4>