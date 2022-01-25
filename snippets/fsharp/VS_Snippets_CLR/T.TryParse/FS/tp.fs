//<snippet1>
// This example demonstrates overloads of the TryParse method for
// several base types, and the TryParseExact method for DateTime.

// In most cases, this example uses the most complex overload that is, the overload
// with the most parameters for a particular type. If a complex overload specifies
// null (Nothing in Visual Basic) for the IFormatProvider parameter, formatting
// information is obtained from the culture associated with the current thread.
// If a complex overload specifies the style parameter, the parameter value is
// the default value used by the equivalent simple overload.

open System
open System.Globalization

let show parseSuccess typeName parseValue =
    if parseSuccess then
        printfn $"Parse for %s{typeName} = %s{parseValue}"
    else
        printfn $"** Parse for %s{typeName} failed. Invalid input."

[<EntryPoint>]
let main _ =
    printfn "This example demonstrates overloads of the TryParse method for\nseveral base types, as well as the TryParseExact method for DateTime.\n"

// Non-numeric types:
    printfn "Non-numeric types:\n"
// DateTime
  // TryParse:
    // Assume current culture is en-US, and dates of the form: MMDDYYYY.
    let success, datetimeVal = DateTime.TryParse "7/4/2004 12:34:56"
    show success "DateTime #1" (string datetimeVal)

    // Use fr-FR culture, and dates of the form: DDMMYYYY.
    let ci = CultureInfo "fr-FR"
    let success, datetimeVal = DateTime.TryParse("4/7/2004 12:34:56", ci, DateTimeStyles.None)
    show success "DateTime #2" (string datetimeVal)

  // TryParseExact:
    // Use fr-FR culture. The format, "G", is short date and long time.
    let success, datetimeVal = DateTime.TryParseExact("04/07/2004 12:34:56", "G", ci, DateTimeStyles.None)
    show success "DateTime #3" (string datetimeVal)

    // Assume en-US culture.
    let dateFormats = [| "f"; "F"; "g"; "G" |]
    let success, datetimeVal = DateTime.TryParseExact("7/4/2004 12:34:56 PM", dateFormats, null, DateTimeStyles.None)
    show success "DateTime #4" (string datetimeVal)

    printfn ""
// Boolean
    let success, booleanVal = Boolean.TryParse "true"
    show success "Boolean" (string booleanVal)
// Char
    let success, charVal = Char.TryParse "A"
    show success "Char" (string charVal)

// Numeric types:
    printfn "\nNumeric types:\n"
// Byte
    let success, byteVal = Byte.TryParse("1", NumberStyles.Integer, null)
    show success "Byte" (string byteVal)
// Int16
    let success, int16Val = Int16.TryParse("-2", NumberStyles.Integer, null)
    show success "Int16" (string int16Val)
// Int32
    let success, int32Val = Int32.TryParse("3", NumberStyles.Integer, null)
    show success "Int32" (string int32Val)
// Int64
    let success, int64Val = Int64.TryParse("4", NumberStyles.Integer, null)
    show success "Int64" (string int64Val)
// Decimal
    let success, decimalVal = Decimal.TryParse("-5.5", NumberStyles.Number, null)
    show success "Decimal" (string decimalVal)
// Single
    let success, singleVal = Single.TryParse("6.6", NumberStyles.Float ||| NumberStyles.AllowThousands, null)
    show success "Single" (string singleVal)
// Double
    let success, doubleVal = Double.TryParse("-7", NumberStyles.Float ||| NumberStyles.AllowThousands, null)
    show success "Double" (string doubleVal)

// Use the simple Double.TryParse overload, but specify an invalid value.

    let success, doubleVal = Double.TryParse "abc"
    show success "Double #2" (string doubleVal)
//
    printfn "\nThe following types are not CLS-compliant:\n"
// SByte
    let success, sbyteVal = SByte.TryParse("-8", NumberStyles.Integer, null)
    show success "SByte" (string sbyteVal)
// UInt16
    let success, uint16Val = UInt16.TryParse("9", NumberStyles.Integer, null)
    show success "UInt16" (string uint16Val)
// UInt32
    let success, uint32Val = UInt32.TryParse("10", NumberStyles.Integer, null)
    show success "UInt32" (string uint32Val)
// UInt64
    let success, uint64Val = UInt64.TryParse("11", NumberStyles.Integer, null)
    show success "UInt64" (string uint64Val)

    0

// This example produces the following results:
//
// This example demonstrates overloads of the TryParse method for
// several base types, as well as the TryParseExact method for DateTime.
//
// Non-numeric types:
//
// Parse for DateTime #1 = 7/4/2004 12:34:56
// Parse for DateTime #2 = 7/4/2004 12:34:56
// Parse for DateTime #3 = 7/4/2004 12:34:56
// Parse for DateTime #4 = 7/4/2004 12:34:56
//
// Parse for Boolean = True
// Parse for Char = A
//
// Numeric types:
//
// Parse for Byte = 1
// Parse for Int16 = -2
// Parse for Int32 = 3
// Parse for Int64 = 4
// Parse for Decimal = -5.5
// Parse for Single = 6.6
// Parse for Double = -7
// ** Parse for Double #2 failed. Invalid input.
//
// The following types are not CLS-compliant:
//
// Parse for SByte = -8
// Parse for UInt16 = 9
// Parse for UInt32 = 10
// Parse for UInt64 = 11
//</snippet1>