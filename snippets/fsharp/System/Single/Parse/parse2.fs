module parse2

// <Snippet3>
open System
open System.Globalization
open System.Threading

let showNumericValue value (styles: NumberStyles) =
    try
        let number = Single.Parse(value, styles)
        printfn $"Converted '{value}' using {styles} to {number}."
    with :? FormatException ->
        printfn $"Unable to parse '{value}' with styles {styles}."
    printfn ""

[<EntryPoint>]
let main _ =
    // Set current thread culture to en-US.
    Thread.CurrentThread.CurrentCulture <- CultureInfo.CreateSpecificCulture "en-US"
    
    // Parse a string in exponential notation with only the AllowExponent flag. 
    let value = "-1.063E-02"
    let styles = NumberStyles.AllowExponent
    showNumericValue value styles
    
    // Parse a string in exponential notation
    // with the AllowExponent and Number flags.
    let styles = NumberStyles.AllowExponent ||| NumberStyles.Number
    showNumericValue value styles

    // Parse a currency value with leading and trailing white space, and
    // white space after the U.S. currency symbol.
    let value = " $ 6,164.3299  "
    let styles = NumberStyles.Number ||| NumberStyles.AllowCurrencySymbol
    showNumericValue value styles
    
    // Parse negative value with thousands separator and decimal.
    let value = "(4,320.64)"
    let styles = NumberStyles.AllowParentheses ||| NumberStyles.AllowTrailingSign ||| NumberStyles.Float 
    showNumericValue value styles
    
    let styles = NumberStyles.AllowParentheses ||| NumberStyles.AllowTrailingSign ||| NumberStyles.Float ||| NumberStyles.AllowThousands
    showNumericValue value styles
    0
// The example displays the following output to the console:
//    Unable to parse '-1.063E-02' with styles AllowExponent.
//    
//    Converted '-1.063E-02' using AllowTrailingSign, AllowThousands, Float to -0.01063.
//    
//    Converted ' $ 6,164.3299  ' using Number, AllowCurrencySymbol to 6164.3299.
//    
//    Unable to parse '(4,320.64)' with styles AllowTrailingSign, AllowParentheses, Float.
//    
//    Converted '(4,320.64)' using AllowTrailingSign, AllowParentheses, AllowThousands, Float to -4320.64.   
// </Snippet3>