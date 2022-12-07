open System
      
let defaultTryParse () =
    // <Snippet1>
    // Parse a floating-point value with a thousands separator.
    let value = "1,643.57"
    match Single.TryParse value with
    | true, number ->
        printfn $"{number}"
    | _ ->
        printfn $"Unable to parse '{value}'."

    // Parse a floating-point value with a currency symbol and a
    // thousands separator.
    let value = "$1,643.57"
    match Single.TryParse value with
    | true, number ->
        printfn $"{number}"
    | _ ->
        printfn $"Unable to parse '{value}'."

    // Parse value in exponential notation.
    let value = "-1.643e6"
    match Single.TryParse value with
    | true, number ->
        printfn $"{number}"
    | _ ->
        printfn $"Unable to parse '{value}'."

    // Parse a negative integer value.
    let value = "-168934617882109132"
    match Single.TryParse value with
    | true, number ->
        printfn $"{number}"
    | _ ->
        printfn $"Unable to parse '{value}'."
    // The example displays the following output:
    //       1643.57
    //       Unable to parse '$1,643.57'.
    //       -164300
    //       -1.689346E+17
    // </Snippet1>

let tryParseWithConstraints () =
    // <Snippet2>
    // Parse currency value using en-GB culture.
    let value = "£1,097.63"
    let style = System.Globalization.NumberStyles.Number ||| System.Globalization.NumberStyles.AllowCurrencySymbol
    let culture = System.Globalization.CultureInfo.CreateSpecificCulture "en-GB"
    match Single.TryParse(value, style, culture) with
    | true, number ->
        printfn $"Converted '{value}' to {number}."
    | _ ->
        printfn $"Unable to convert '{value}'."

    let value = "1345,978"
    let style = System.Globalization.NumberStyles.AllowDecimalPoint
    let culture = System.Globalization.CultureInfo.CreateSpecificCulture "fr-FR"
    match Single.TryParse(value, style, culture) with
    | true, number ->
        printfn $"Converted '{value}' to {number}."
    | _ ->
        printfn $"Unable to convert '{value}'."

    let value = "1.345,978"
    let style = System.Globalization.NumberStyles.AllowDecimalPoint ||| System.Globalization.NumberStyles.AllowThousands
    let culture = System.Globalization.CultureInfo.CreateSpecificCulture "es-ES"
    match Single.TryParse(value, style, culture) with
    | true, number ->
        printfn $"Converted '{value}' to {number}."
    | _ ->
        printfn $"Unable to convert '{value}'."

    let value = "1 345,978"
    match Single.TryParse(value, style, culture) with
    | true, number ->
        printfn $"Converted '{value}' to {number}."
    | _ ->
        printfn $"Unable to convert '{value}'."
    // The example displays the following output:
    //       Converted '£1,097.63' to 1097.63.
    //       Converted '1345,978' to 1345.978.
    //       Converted '1.345,978' to 1345.978.
    //       Unable to convert '1 345,978'.
    // </Snippet2>

defaultTryParse ()
printfn "----------"
tryParseWithConstraints ()