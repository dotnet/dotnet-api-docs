// <Snippet2>
open System
open System.Globalization

let parseToInt16 (value: string) (style: NumberStyles) =
    try
        let number = Int16.Parse(value, style)
        printfn $"Converted '{value}' to {number}."
    with
    | :? FormatException ->
        printfn $"Unable to parse '{value}' with style {style}."
    | :? OverflowException ->
        printfn $"'{value}' is out of range of the Int16 type."

[<EntryPoint>]
let main _ =
    // Parse a number with a thousands separator (throws an exception).
    let value = "14,644"
    let style = NumberStyles.None
    parseToInt16 value style

    let style = NumberStyles.AllowThousands
    parseToInt16 value style

    // Parse a number with a thousands separator and decimal point.
    let value = "14,644.00"
    let style = NumberStyles.AllowThousands ||| NumberStyles.Integer ||| NumberStyles.AllowDecimalPoint
    parseToInt16 value style

    // Parse a number with a fractional component (throws an exception).
    let value = "14,644.001"
    parseToInt16 value style

    // Parse a number in exponential notation.
    let value = "145E02"
    let style = style ||| NumberStyles.AllowExponent
    parseToInt16 value style

    // Parse a number in exponential notation with a positive sign.
    let value = "145E+02"
    parseToInt16 value style

    // Parse a number in exponential notation with a negative sign
    // (throws an exception).
    let value = "145E-02"
    parseToInt16 value style

    0

// The example displays the following output to the console:
//       Unable to parse '14,644' with style None.
//       Converted '14,644' to 14644.
//       Converted '14,644.00' to 14644.
//       '14,644.001' is out of range of the Int16 type.
//       Converted '145E02' to 14500.
//       Converted '145E+02' to 14500.
//       '145E-02' is out of range of the Int16 type.
// </Snippet2>
