open System
open System.Globalization

let callParse () =
    // <Snippet1>
    // Parse an integer with thousands separators.
    let value = "16,523,421"
    let number = Decimal.Parse value
    printfn $"'{value}' converted to {number}."
    // Displays:
    //    '16,523,421' converted to 16523421.

    // Parse a floating point value with thousands separators
    let value = "25,162.1378"
    let number = Decimal.Parse value
    printfn $"'{value}' converted to {number}."
    // Displays:
    //    '25,162.1378' converted to 25162.1378.

    // Parse a floating point number with US currency symbol.
    let value = "$16,321,421.75"
    try
        let number = Decimal.Parse value
        printfn $"'{value}' converted to {number}."
    with :? FormatException ->
        printfn $"Unable to parse '{value}'."
    // Displays:
    //    Unable to parse '$16,321,421.75'.

    // Parse a number in exponential notation
    let value = "1.62345e-02"
    try
        let number = Decimal.Parse value
        printfn $"'{value}' converted to {number}."
    with :? FormatException ->
        printfn $"Unable to parse '{value}'."
    // Displays:
    //    Unable to parse '1.62345e-02'.
    // </Snippet1>

let callParseWithStyles () = 
    // <Snippet2>
    // Parse string with a floating point value using NumberStyles.None.
    let value = "8694.12"
    let style = NumberStyles.None
    try
        let number = Decimal.Parse(value, style)
        printfn $"'{value}' converted to {number}."
    with :? FormatException ->
        printfn $"Unable to parse '{value}'."
    // Displays:
    //    Unable to parse '8694.12'.

    // Parse string with a floating point value and allow decimal point.
    let style = NumberStyles.AllowDecimalPoint
    let number = Decimal.Parse(value, style)
    printfn $"'{value}' converted to {number}."
    // Displays:
    //    '8694.12' converted to 8694.12.

    // Parse string with negative value in parentheses
    let value = "(1,789.34)"
    let style = 
        NumberStyles.AllowDecimalPoint ||| 
        NumberStyles.AllowThousands ||| 
        NumberStyles.AllowParentheses
    let number = Decimal.Parse(value, style)
    printfn $"'{value}' converted to {number}."
    // Displays:
    //    '(1,789.34)' converted to -1789.34.

    // Parse string using Number style
    let value = " -17,623.49 "
    let style = NumberStyles.Number
    let number = Decimal.Parse(value, style)
    printfn $"'{value}' converted to {number}."
    // Displays:
    //    ' -17,623.49 ' converted to -17623.49.
    // </Snippet2>

let callParseWithStylesAndProvider () =
    // <Snippet3>
    // Parse string using " " as the thousands separator
    // and "," as the decimal separator for fr-FR culture.
    let value = "892 694,12"
    let style = NumberStyles.AllowDecimalPoint ||| NumberStyles.AllowThousands
    let provider = CultureInfo "fr-FR"

    let number = Decimal.Parse(value, style, provider)
    printfn $"'{value}' converted to {number}."
    // Displays:
    //    '892 694,12' converted to 892694.12.

    try
        let number = Decimal.Parse(value, style, CultureInfo.InvariantCulture)
        printfn $"'{value}' converted to {number}."
    with :? FormatException ->
        printfn $"Unable to parse '{value}'."
    // Displays:
    //    Unable to parse '892 694,12'.

    // Parse string using "$" as the currency symbol for en-GB and
    // en-US cultures.
    let value = "$6,032.51"
    let style = NumberStyles.Number ||| NumberStyles.AllowCurrencySymbol
    let provider = CultureInfo "en-GB"

    try
        let number = Decimal.Parse(value, style, provider)
        printfn $"'{value}' converted to {number}."
    with :? FormatException ->
        printfn $"Unable to parse '{value}'."
    // Displays:
    //    Unable to parse '$6,032.51'.

    let provider = CultureInfo "en-US"
    let number = Decimal.Parse(value, style, provider)
    printfn $"'{value}' converted to {number}."
    // Displays:
    //    '$6,032.51' converted to 6032.51.
    // </Snippet3>

callParse ()
printfn "-----"
callParseWithStyles ()
printfn "-----"
callParseWithStylesAndProvider () 