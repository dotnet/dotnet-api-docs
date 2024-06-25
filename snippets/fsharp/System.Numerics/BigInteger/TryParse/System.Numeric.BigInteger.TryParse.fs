module tryparse

open System
open System.Globalization
open System.Numerics

let tryParse1 () =
    // <Snippet1>
    let mutable number1 = BigInteger.Zero
    let mutable number2 = BigInteger.Zero

    let succeeded1 = BigInteger.TryParse("-12347534159895123", &number1)
    let succeeded2 = BigInteger.TryParse("987654321357159852", &number2)

    if succeeded1 && succeeded2 then
        number1 <- number1 * 3I
        number2 <- number2 * 2I

        match BigInteger.Compare(number1, number2) with
        | -1 -> printfn $"{number2} is greater than {number2}."
        | 0 -> printfn $"{number1} is equal to {number2}."
        | 1
        | _ -> printfn $"{number1} is greater than {number2}."
    else
        if not succeeded1 then
            printfn "Unable to initialize the first BigInteger value."

        if not succeeded2 then
            printfn "Unable to initialize the second BigInteger value."

// The example displays the following output:
//      1975308642714319704 is greater than -37042602479685369.
// </Snippet1>

type BigIntegerFormatProvider() =
    interface IFormatProvider with
        member _.GetFormat(formatType: Type) =
            if formatType = typeof<NumberFormatInfo> then
                let numberFormat = new NumberFormatInfo()
                numberFormat.NegativeSign <- "~"
                numberFormat
            else
                null

let tryParse2 () =
    // <Snippet2>

    // Call parse with default values of style and provider
    let numericString = "  -300   "

    match BigInteger.TryParse(numericString, NumberStyles.Integer, CultureInfo.CurrentCulture) with
    | true, number -> printfn $"The string '{numericString}' parses to {number}"
    | _ -> printfn $"Conversion of {numericString} to a BigInteger failed."

    // Call parse with default values of style and provider supporting tilde as negative sign
    let numericString = "  -300   "

    match BigInteger.TryParse(numericString, NumberStyles.Integer, new BigIntegerFormatProvider()) with
    | true, number -> printfn $"The string '{numericString}' parses to {number}"
    | _ -> printfn $"Conversion of {numericString} to a BigInteger failed."

    // Call parse with only AllowLeadingWhite and AllowTrailingWhite
    // Method returns false because of presence of negative sign
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

    // Call parse with AllowHexSpecifier and a hex value
    let numericString = "FFAAC086455192"

    match BigInteger.TryParse(numericString, NumberStyles.AllowHexSpecifier, null) with
    | true, number -> printfn $"The string '{numericString}' parses to {number}, or 0x{number:x}."
    | _ -> printfn $"Conversion of {numericString} to a BigInteger failed."

    // Call parse with AllowHexSpecifier and a negative hex value
    // Conversion fails because of presence of negative sign
    let numericString = "-3af"

    match BigInteger.TryParse(numericString, NumberStyles.AllowHexSpecifier, null) with
    | true, number -> printfn $"The string '{numericString}' parses to {number}, or 0x{number:x}."
    | _ -> printfn $"Conversion of {numericString} to a BigInteger failed."

    // Call parse with only NumberStyles.None
    // Exception thrown because of presence of white space and sign
    let numericString = " -300 "

    match BigInteger.TryParse(numericString, NumberStyles.None, new BigIntegerFormatProvider()) with
    | true, number -> printfn $"The string '{numericString}' parses to {number}"
    | _ -> printfn $"Conversion of {numericString} to a BigInteger failed."

// <</Snippet2>

tryParse1 ()
tryParse2 ()
