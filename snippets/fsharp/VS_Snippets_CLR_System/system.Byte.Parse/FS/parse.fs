open System
open System.Globalization

let callParse1 () =
    // <Snippet1>
    let stringToConvert = " 162"
    try
        let byteValue = Byte.Parse stringToConvert
        printfn $"Converted '{stringToConvert}' to {byteValue}."
    with
    | :? FormatException ->
        printfn $"Unable to parse '{stringToConvert}'."
    | :? OverflowException ->
        printfn $"'{stringToConvert}' is greater than {Byte.MaxValue} or less than {Byte.MinValue}."

    // The example displays the following output to the console:
    //       Converted ' 162' to 162.
    // </Snippet1>

let callParse2 () =
    // <Snippet2>
    let stringToConvert = " 214 "
    try
        let byteValue = Byte.Parse(stringToConvert, CultureInfo.InvariantCulture)
        printfn $"Converted '{stringToConvert}' to {byteValue}." 
    with
    | :? FormatException ->
        printfn $"Unable to parse '{stringToConvert}'."
    | :? OverflowException ->
        printfn $"'{stringToConvert}' is greater than {Byte.MaxValue} or less than {Byte.MinValue}." 

    let stringToConvert = " + 214 "
    try
        let byteValue = Byte.Parse(stringToConvert, CultureInfo.InvariantCulture)
        printfn $"Converted '{stringToConvert}' to {byteValue}." 
    with
    | :? FormatException ->
        printfn $"Unable to parse '{stringToConvert}'."
    | :? OverflowException ->
        printfn $"'{stringToConvert}' is greater than {Byte.MaxValue} or less than {Byte.MinValue}." 

    let stringToConvert = " +214 "
    try
        let byteValue = Byte.Parse(stringToConvert, CultureInfo.InvariantCulture)
        printfn $"Converted '{stringToConvert}' to {byteValue}." 
    with
    | :? FormatException ->
        printfn $"Unable to parse '{stringToConvert}'."
    | :? OverflowException ->
        printfn $"'{stringToConvert}' is greater than {Byte.MaxValue} or less than {Byte.MinValue}." 

    // The example displays the following output to the console:
    //       Converted ' 214 ' to 214.
    //       Unable to parse ' + 214 '.
    //       Converted ' +214 ' to 214.
    // </Snippet2>

let callParse3 () =
    // <Snippet3>
    // Parse value with no styles allowed.
    let style = NumberStyles.None
    let value = " 241 "
    try
        let number = Byte.Parse(value, style);
        printfn $"Converted '{value}' to {number}."
    with :? FormatException ->
        printfn $"Unable to parse '{value}'."

    // Parse value with trailing sign.
    let style = NumberStyles.Integer ||| NumberStyles.AllowTrailingSign
    let value = " 163+"
    let number = Byte.Parse(value, style)
    printfn $"Converted '{value}' to {number}."

    // Parse value with leading sign.
    let value = "   +253  "
    let number = Byte.Parse(value, style)
    printfn $"Converted '{value}' to {number}."

    // This example displays the following output to the console:
    //       Unable to parse ' 241 '.
    //       Converted ' 163+' to 163.
    //       Converted '   +253  ' to 253.
    // </Snippet3>

let callParse4 () =
    // <Snippet4>
    // Parse number with decimals.
    // NumberStyles.Float includes NumberStyles.AllowDecimalPoint.
    let style = NumberStyles.Float
    let culture = CultureInfo.CreateSpecificCulture "fr-FR"
    let value = "12,000"

    let number = Byte.Parse(value, style, culture)
    printfn $"Converted '{value}' to {number}."

    let culture = CultureInfo.CreateSpecificCulture "en-GB"
    try
        let number = Byte.Parse(value, style, culture)
        printfn $"Converted '{value}' to {number}."
    with :? FormatException ->
        printfn $"Unable to parse '{value}'."

    let value = "12.000"
    let number = Byte.Parse(value, style, culture)
    printfn $"Converted '{value}' to {number}."
    
    // The example displays the following output to the console:
    //       Converted '12,000' to 12.
    //       Unable to parse '12,000'.
    //       Converted '12.000' to 12.
    // </Snippet4>

callParse1 ()
printfn ""
callParse2 ()
printfn ""
callParse3 ()
printfn ""
callParse4 ()