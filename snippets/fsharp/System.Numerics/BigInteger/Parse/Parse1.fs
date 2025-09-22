module parse1

open System
open System.Globalization
open System.Numerics

let parseString () =
    // <Snippet1>
    let mutable stringToParse = ""

    try
        // Parse two strings.
        let string1 = "12347534159895123"
        let string2 = "987654321357159852"
        stringToParse <- string1
        let number1 = BigInteger.Parse stringToParse
        printfn $"Converted '{stringToParse}' to {number1:N0}."
        stringToParse <- string2
        let number2 = BigInteger.Parse stringToParse
        printfn $"Converted '{stringToParse}' to {number2:N0}."
        // Perform arithmetic operations on the two numbers.
        let number1 = number1 * bigint 3
        let number2 = number2 * bigint 2
        // Compare the numbers.
        let result = BigInteger.Compare(number1, number2)

        match result with
        | -1 -> printfn $"{number2:N0} is greater than {number1:N0}."
        | 0 -> printfn $"{number1:N0} is equal to {number2:N0}."
        | 1
        | _ -> printfn $"{number1:N0} is greater than {number2:N0}."
    with :? FormatException ->
        printfn $"Unable to parse {stringToParse}."

// The example displays the following output:
//    Converted '12347534159895123' to 12,347,534,159,895,123.
//    Converted '987654321357159852' to 987,654,321,357,159,852.
//    1975308642714319704 is greater than 37042602479685369.
// </Snippet1>

// <Snippet4>
type BigIntegerFormatProvider() =
    interface IFormatProvider with

        member _.GetFormat(formatType: Type) =
            if formatType = typeof<NumberFormatInfo> then
                let numberFormat = NumberFormatInfo()
                numberFormat.NegativeSign <- "~"
                numberFormat
            else
                null
// </Snippet4>


let parseWithStyleAndProvider () =
    // <Snippet2>
    // Call parse with default values of style and provider
    printfn $"""{BigInteger.Parse("  -300   ", NumberStyles.Integer, CultureInfo.CurrentCulture)}"""

    // Call parse with default values of style and provider supporting tilde as negative sign
    printfn $"""{BigInteger.Parse("   ~300  ", NumberStyles.Integer, new BigIntegerFormatProvider())}"""

    // Call parse with only AllowLeadingWhite and AllowTrailingWhite
    // Exception thrown because of presence of negative sign
    try
        printfn
            $"""{BigInteger.Parse(
                     "    ~300   ",
                     NumberStyles.AllowLeadingWhite ||| NumberStyles.AllowTrailingWhite,
                     new BigIntegerFormatProvider()
                 )}"""
    with :? FormatException as e ->
        printfn $"{e.GetType().Name}: \n   {e.Message}"

    // Call parse with only AllowHexSpecifier
    // Exception thrown because of presence of negative sign
    try
        printfn $"""{BigInteger.Parse("-3af", NumberStyles.AllowHexSpecifier, new BigIntegerFormatProvider())}"""
    with :? FormatException as e ->
        printfn $"{e.GetType().Name}: \n   {e.Message}"

    // Call parse with only NumberStyles.None
    // Exception thrown because of presence of white space and sign
    try
        printfn $"""{BigInteger.Parse(" -300 ", NumberStyles.None, new BigIntegerFormatProvider())}"""
    with :? FormatException as e ->
        printfn $"{e.GetType().Name}: \n   {e.Message}"
// The example displays the followingoutput:
//       -300
//       -300
//       FormatException:
//          The value could not be parsed.
//       FormatException:
//          The value could not be parsed.
//       FormatException:
//          The value could not be parsed.
// </Snippet2>

parseString ()
parseWithStyleAndProvider ()
