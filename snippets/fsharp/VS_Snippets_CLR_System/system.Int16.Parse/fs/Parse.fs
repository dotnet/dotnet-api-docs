module Parse

open System
open System.Globalization


let callParse1 () =
    // <Snippet1>
    let value = " 12603 "
    try
        let number = Int16.Parse value
        printfn $"Converted '{value}' to {number}." 
    with :? FormatException -> 
        printfn $"Unable to convert '{value}' to a 16-bit signed integer."

    let value = " 16,054"
    try
        let number = Int16.Parse value
        printfn $"Converted '{value}' to {number}."
    with :? FormatException ->
        printfn "Unable to convert '{value}' to a 16-bit signed integer."
                        
    let value = " -17264"
    try
        let number = Int16.Parse value
        printfn $"Converted '{value}' to {number}."
    with :? FormatException ->
        printfn "Unable to convert '{value}' to a 16-bit signed integer."
        

    // The example displays the following output to the console:
    //       Converted ' 12603 ' to 12603.
    //       Unable to convert ' 16,054' to a 16-bit signed integer.
    //       Converted ' -17264' to -17264.
    // </Snippet1>

let callParse3 () =
    // <Snippet3>
    // Parse string using "." as the thousands separator
    // and " " as the decimal separator.
    let value = "19 694,00"
    let style = NumberStyles.AllowDecimalPoint ||| NumberStyles.AllowThousands
    let provider = CultureInfo "fr-FR"

    let number = Int16.Parse(value, style, provider)
    printfn $"'{value}' converted to {number}." 
    // Displays:
    //    '19 694,00' converted to 19694.

    try
        let number = Int16.Parse(value, style, CultureInfo.InvariantCulture)
        printfn $"'{value}' converted to {number}." 
    with :? FormatException ->
        printfn $"Unable to parse '{value}'."
    // Displays:
    //    Unable to parse '19 694,00'.

    // Parse string using "$" as the currency symbol for en_GB and
    // en-US cultures.
    let value = "$6,032.00"
    let style = NumberStyles.Number ||| NumberStyles.AllowCurrencySymbol

    try
        let number = Int16.Parse(value, style, CultureInfo.InvariantCulture)
        printfn $"'{value}' converted to {number}." 
    with :? FormatException ->
        printfn $"Unable to parse '{value}'."
    // Displays:
    //    Unable to parse '$6,032.00'.

    let provider = CultureInfo "en-US"
    let number = Int16.Parse(value, style, provider)
    printfn $"'{value}' converted to {number}."
    // Displays:
    //    '$6,032.00' converted to 6032.
    // </Snippet3>


let callParse4 () =
    // <Snippet4>
    let stringToConvert = " 214 "
    try
        let number = Int16.Parse(stringToConvert, CultureInfo.InvariantCulture)
        printfn $"Converted '{stringToConvert}' to {number}." 
    with 
    | :? FormatException ->
        printfn $"Unable to parse '{stringToConvert}'."
    | :? OverflowException ->
        printfn $"'{stringToConvert}' is out of range of the Int16 data type."

    let stringToConvert = " + 214"
    try
        let number = Int16.Parse(stringToConvert, CultureInfo.InvariantCulture)
        printfn $"Converted '{stringToConvert}' to {number}." 
    with 
    | :? FormatException ->
        printfn $"Unable to parse '{stringToConvert}'."
    | :? OverflowException -> 
        printfn $"'{stringToConvert}' is out of range of the Int16 data type."

    let stringToConvert = " +214 "
    try
        let number = Int16.Parse(stringToConvert, CultureInfo.InvariantCulture)
        printfn $"Converted '{stringToConvert}' to {number}." 
    with
    | :? FormatException ->
        printfn $"Unable to parse '{stringToConvert}'."
    | :? OverflowException ->
        printfn $"'{stringToConvert}' is out of range of the Int16 data type."
    
    // The example displays the following output to the console:
    //       Converted ' 214 ' to 214.
    //       Unable to parse ' + 214'.
    //       Converted ' +214 ' to 214.
    // </Snippet4>


callParse1 ()
printfn "-----"
callParse3 ()
printfn "-----"
callParse4 ()