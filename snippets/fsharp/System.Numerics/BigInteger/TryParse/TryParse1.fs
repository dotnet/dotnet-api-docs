module tryparse1

open System
open System.Globalization
open System.Numerics

// <Snippet3>
type BigIntegerFormatProvider() =
    interface IFormatProvider with
        member _.GetFormat(formatType: Type) =
            if formatType = typeof<NumberFormatInfo> then
                let numberFormat = new NumberFormatInfo()
                numberFormat.NegativeSign <- "~"
                numberFormat
            else
                null
// </Snippet3>

do
    // <Snippet2>
    // Call TryParse with default values of style and provider.
    let numericString = "  -300   "

    match BigInteger.TryParse(numericString, NumberStyles.Integer, null) with
    | true, number -> printfn $"The string '{numericString}' parses to {number}"
    | _ -> printfn $"Conversion of {numericString} to a BigInteger failed."

    // Call TryParse with the default value of style and
    // a provider supporting the tilde as negative sign.
    let numericString = "  -300   "

    match BigInteger.TryParse(numericString, NumberStyles.Integer, new BigIntegerFormatProvider()) with
    | true, number -> printfn $"The string '{numericString}' parses to {number}"
    | _ -> printfn $"Conversion of {numericString} to a BigInteger failed."

    // Call TryParse with only AllowLeadingWhite and AllowTrailingWhite.
    // Method returns false because of presence of negative sign.
    let numericString = "  -500   "

    match
        BigInteger.TryParse(
            numericString,
            NumberStyles.AllowLeadingWhite ||| NumberStyles.AllowTrailingWhite,
            new BigIntegerFormatProvider()
        )
    with
    | true, number -> printfn $"The string '{numericString}' parses to {number}"
    | _ -> printfn $"Conversion of {numericString} to a BigInteger failed."

    // Call TryParse with AllowHexSpecifier and a hex value.
    let numericString = "F14237FFAAC086455192"

    match BigInteger.TryParse(numericString, NumberStyles.AllowHexSpecifier, null) with
    | true, number -> printfn $"The string '{numericString}' parses to {number}, or 0x{number:x}."
    | _ -> printfn $"Conversion of {numericString} to a BigInteger failed."

    // Call TryParse with AllowHexSpecifier and a negative hex value.
    // Conversion fails because of presence of negative sign.
    let numericString = "-3af"

    match BigInteger.TryParse(numericString, NumberStyles.AllowHexSpecifier, null) with
    | true, number -> printfn $"The string '{numericString}' parses to {number}, or 0x{number:x}."
    | _ -> printfn $"Conversion of {numericString} to a BigInteger failed."

    // Call TryParse with only NumberStyles.None.
    // Conversion fails because of presence of white space and sign.
    let numericString = " -300 "

    match BigInteger.TryParse(numericString, NumberStyles.None, new BigIntegerFormatProvider()) with
    | true, number -> printfn $"The string '{numericString}' parses to {number}"
    | _ -> printfn $"Conversion of {numericString} to a BigInteger failed."

    // Call TryParse with NumberStyles.Any and a provider for the fr-FR culture.
    // Conversion fails because the string is formatted for the en-US culture.
    let numericString = "9,031,425,666,123,546.00"

    match BigInteger.TryParse(numericString, NumberStyles.Any, new CultureInfo("fr-FR")) with
    | true, number -> printfn $"The string '{numericString}' parses to {number}"
    | _ -> printfn $"Conversion of {numericString} to a BigInteger failed."

    // Call TryParse with NumberStyles.Any and a provider for the fr-FR culture.
    // Conversion succeeds because the string is properly formatted
    // For the fr-FR culture.
    let numericString = "9 031 425 666 123 546,00"

    match BigInteger.TryParse(numericString, NumberStyles.Any, new CultureInfo("fr-FR")) with
    | true, number -> printfn $"The string '{numericString}' parses to {number}"
    | _ -> printfn $"Conversion of {numericString} to a BigInteger failed."

// The example displays the following output:
//    '  -300   ' was converted to -300.
//    Conversion of '  -300   ' to a BigInteger failed.
//    Conversion of '  -500   ' to a BigInteger failed.
//    'F14237FFAAC086455192' was converted to -69613977002644837412462 (0xf14237ffaac086455192).
//    Conversion of '-3af' to a BigInteger failed.
//    Conversion of ' -300 ' to a BigInteger failed.
//    Conversion of '9,031,425,666,123,546.00' to a BigInteger failed.
//    '9 031 425 666 123 546,00' was converted to 9031425666123546.
// </Snippet2>
