module Parse3

// <Snippet3>
open System
open System.Globalization

let convert (value: string) (style: NumberStyles) (provider: IFormatProvider) =
    try
        let number = Int32.Parse(value, style, provider)
        printfn $"Converted '{value}' to {number}."
    with 
    | :? FormatException ->
        printfn $"Unable to convert '{value}'."
    | :? OverflowException ->
        printfn $"'{value}' is out of range of the Int32 type."

convert "12,000" (NumberStyles.Float ||| NumberStyles.AllowThousands) (CultureInfo "en-GB")
convert "12,000" (NumberStyles.Float ||| NumberStyles.AllowThousands) (CultureInfo "fr-FR")
convert "12,000" NumberStyles.Float (CultureInfo "en-US")
convert "12 425,00" (NumberStyles.Float ||| NumberStyles.AllowThousands) (CultureInfo "sv-SE")
convert "12,425.00" (NumberStyles.Float ||| NumberStyles.AllowThousands) NumberFormatInfo.InvariantInfo
convert "631,900" (NumberStyles.Integer ||| NumberStyles.AllowDecimalPoint) (CultureInfo "fr-FR")
convert "631,900" (NumberStyles.Integer ||| NumberStyles.AllowDecimalPoint) (CultureInfo "en-US")
convert "631,900" (NumberStyles.Integer ||| NumberStyles.AllowThousands) (CultureInfo "en-US")

// This example displays the following output to the console:
//       Converted '12,000' to 12000.
//       Converted '12,000' to 12.
//       Unable to convert '12,000'.
//       Converted '12 425,00' to 12425.
//       Converted '12,425.00' to 12425.
//       '631,900' is out of range of the Int32 type.
//       Unable to convert '631,900'.
//       Converted '631,900' to 631900.
// </Snippet3>
