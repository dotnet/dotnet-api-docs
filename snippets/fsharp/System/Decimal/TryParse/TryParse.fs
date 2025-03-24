open System
open System.Globalization

let callTryParse1 () =
    // <Snippet1>
    // Parse a floating-point value with a thousands separator.
    let value = "1,643.57"
    match Decimal.TryParse value with
    | true, number ->
        printfn $"{number}"
    | _ ->
        printfn $"Unable to parse '{value}'."

    // Parse a floating-point value with a currency symbol and a
    // thousands separator.
    let value = "$1,643.57"
    match Decimal.TryParse value with
    | true, number ->
        printfn $"{number}"
    | _ -> 
        printfn $"Unable to parse '{value}'."

    // Parse value in exponential notation.
    let value = "-1.643e6"
    match Decimal.TryParse value with
    | true, number ->
        printfn $"{number}"
    | _ -> 
        printfn $"Unable to parse '{value}'."

    // Parse a negative integer value.
    let value = "-1689346178821"
    match Decimal.TryParse value with
    | true, number ->
        printfn $"{number}"
    | _ -> 
        printfn $"Unable to parse '{value}'."
    // The example displays the following output to the console:
    //       1643.57
    //       Unable to parse '$1,643.57'.
    //       Unable to parse '-1.643e6'.
    //       -1689346178821
    // </Snippet1>

let callTryParse2 () =
    // <Snippet2>
    // Parse currency value using en-GB culture.
    let value = "£1,097.63"
    let style = NumberStyles.Number ||| NumberStyles.AllowCurrencySymbol
    let culture = CultureInfo.CreateSpecificCulture "en-GB"
    match Decimal.TryParse(value, style, culture) with
    | true, number ->
        printfn $"Converted '{value}' to {number}."
    | _ -> 
        printfn $"Unable to convert '{value}'."
    // Displays:
    //       Converted '£1,097.63' to 1097.63.

    let value = "1345,978"
    let style = NumberStyles.AllowDecimalPoint
    let culture = CultureInfo.CreateSpecificCulture "fr-FR"
    match Decimal.TryParse(value, style, culture) with
    | true, number ->
        printfn $"Converted '{value}' to {number}."
    | _ -> 
        printfn $"Unable to convert '{value}'."
    // Displays:
    //       Converted '1345,978' to 1345.978.

    let value = "1.345,978"
    let style = NumberStyles.AllowDecimalPoint ||| NumberStyles.AllowThousands
    let culture = CultureInfo.CreateSpecificCulture "es-ES"
    match Decimal.TryParse(value, style, culture) with
    | true, number ->
        printfn $"Converted '{value}' to {number}."
    | _ -> 
        printfn $"Unable to convert '{value}'."
    // Displays:
    //       Converted '1.345,978' to 1345.978.

    let value = "1 345,978"
    match Decimal.TryParse(value, style, culture) with
    | true, number ->
        printfn $"Converted '{value}' to {number}."
    | _ -> 
        printfn $"Unable to convert '{value}'."
    // Displays:
    //       Unable to convert '1 345,978'.
    // </Snippet2>

callTryParse1 ()
printfn "----------"
callTryParse2 ()