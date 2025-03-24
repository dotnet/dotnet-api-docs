module tobyte4

// <Snippet14>
open System
open System.Globalization

// Create a NumberFormatInfo object and set several of its
// properties that apply to unsigned bytes.
let provider = NumberFormatInfo()

// These properties affect the conversion.
provider.PositiveSign <- "pos "
provider.NegativeSign <- "neg "

// This property does not affect the conversion.
// The input string cannot have a decimal separator.
provider.NumberDecimalSeparator <- "."

// Define an array of numeric strings.
let numericStrings = 
    [| "234"; "+234"; "pos 234"
       "234."; "255"; "256"; "-1" |]

for numericString in numericStrings do
    printf $"'{numericString,-8}' ->   "
    try
        let number = Convert.ToByte(numericString, provider)
        printfn $"{number}"
    with
    | :? FormatException ->
        printfn "Incorrect Format"
    | :? OverflowException ->
        printfn "Overflows a Byte"

// The example displays the following output:
//       '234     ' ->   234
//       '+234    ' ->   Incorrect Format
//       'pos 234 ' ->   234
//       '234.    ' ->   Incorrect Format
//       '255     ' ->   255
//       '256     ' ->   Overflows a Byte
//       '-1      ' ->   Incorrect Format
// </Snippet14>