module tosbyte

//<Snippet4>
// Example of the Convert.ToSByte( string ) and
// Convert.ToSByte( string, IFormatProvider ) methods.
open System
open System.Globalization

let format obj1 obj2 obj3 = printfn $"{obj1,-20}{obj2,-20}{obj3}"

// Get the exception type name; remove the namespace prefix.
let getExceptionType (ex: exn) =
    let exceptionType = ex.GetType() |> string
    exceptionType.Substring(exceptionType.LastIndexOf '.' + 1 )

let convertToSByte (numericStr: string) (provider: IFormatProvider) =
    // Convert numericStr to SByte without a format provider.
    let defaultValue =
        try
            Convert.ToSByte numericStr
            |> string
        with ex -> 
            getExceptionType ex

    // Convert numericStr to SByte with a format provider.
    let providerValue = 
        try
            Convert.ToSByte(numericStr, provider)
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
provider.NumberNegativePattern <- 0

printfn
    """This example of
  Convert.ToSByte( string ) and 
  Convert.ToSByte( string, IFormatProvider ) 
generates the following output. It converts several strings to 
SByte values, using default formatting or a NumberFormatInfo object.
"""
format "String to convert" "Default/exception" "Provider/exception"
format "-----------------" "-----------------" "------------------"

// Convert strings, with and without an IFormatProvider.
convertToSByte "123" provider
convertToSByte "+123" provider
convertToSByte "pos 123" provider
convertToSByte "-123" provider 
convertToSByte "neg 123" provider 
convertToSByte "123." provider 
convertToSByte "(123)" provider 
convertToSByte "128" provider 
convertToSByte "-129" provider 


// This example of
//   Convert.ToSByte( string ) and
//   Convert.ToSByte( string, IFormatProvider )
// generates the following output. It converts several strings to
// SByte values, using default formatting or a NumberFormatInfo object.

// String to convert   Default/exception   Provider/exception
// -----------------   -----------------   ------------------
// 123                 123                 123
// +123                123                 FormatException
// pos 123             FormatException     123
// -123                -123                FormatException
// neg 123             FormatException     -123
// 123.                FormatException     FormatException
// (123)               FormatException     FormatException
// 128                 OverflowException   OverflowException
// -129                OverflowException   FormatException
//</Snippet4>