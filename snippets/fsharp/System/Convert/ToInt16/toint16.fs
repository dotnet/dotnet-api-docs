module toint16

//<Snippet3>
// Example of the Convert.ToInt16( string ) and
// Convert.ToInt16( string, IFormatProvider ) methods.
open System
open System.Globalization

let format obj1 obj2 obj3 = printfn $"{obj1,-20}{obj2,-20}{obj3}"

// Get the exception type name; remove the namespace prefix.
let getExceptionType (ex: exn) =
    let exceptionType = ex.GetType() |> string
    exceptionType.Substring(exceptionType.LastIndexOf '.' + 1)

let convertToInt16 (numericStr: string) (provider: IFormatProvider) =
    // Convert numericStr to Int16 without a format provider.
    let defaultValue = 
        try
            Convert.ToInt16 numericStr
            |> string
        with ex ->
            getExceptionType ex

    // Convert numericStr to Int16 with a format provider.
    let providerValue = 
        try
            Convert.ToInt16(numericStr, provider)
            |> string
        with ex ->
            getExceptionType ex

    format numericStr defaultValue providerValue

// Create a NumberFormatInfo object and set several of its
// properties that apply to numbers.
let provider = NumberFormatInfo()

// These properties affect the conversion.
provider.NegativeSign <- "neg "
provider.PositiveSign <- "pos "

// These properties do not affect the conversion.
// The input string cannot have decimal and group separators.
provider.NumberDecimalSeparator <- "."
provider.NumberGroupSeparator <- ","
provider.NumberGroupSizes <- [| 3 |]
provider.NumberNegativePattern <- 0

printfn
    """This example of
  Convert.ToInt16( string ) and 
  Convert.ToInt16( string, IFormatProvider ) 
generates the following output. It converts several strings to 
short values, using default formatting or a NumberFormatInfo object.
"""
format "String to convert" "Default/exception" "Provider/exception"
format "-----------------" "-----------------" "------------------"

// Convert strings, with and without an IFormatProvider.
convertToInt16 "12345" provider
convertToInt16 "+12345" provider
convertToInt16 "pos 12345" provider
convertToInt16 "-12345" provider
convertToInt16 "neg 12345" provider
convertToInt16 "12345." provider
convertToInt16 "12,345" provider
convertToInt16 "(12345)" provider
convertToInt16 "32768" provider
convertToInt16 "-32769" provider

// This example of
//   Convert.ToInt16( string ) and
//   Convert.ToInt16( string, IFormatProvider )
// generates the following output. It converts several strings to
// short values, using default formatting or a NumberFormatInfo object.
//
// String to convert   Default/exception   Provider/exception
// -----------------   -----------------   ------------------
// 12345               12345               12345
// +12345              12345               FormatException
// pos 12345           FormatException     12345
// -12345              -12345              FormatException
// neg 12345           FormatException     -12345
// 12345.              FormatException     FormatException
// 12,345              FormatException     FormatException
// (12345)             FormatException     FormatException
// 32768               OverflowException   OverflowException
// -32769              OverflowException   FormatException
//</Snippet3>