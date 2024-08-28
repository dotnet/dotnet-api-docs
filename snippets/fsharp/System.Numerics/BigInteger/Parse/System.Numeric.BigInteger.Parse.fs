module parse

open System
open System.Globalization
open System.Numerics


// <Snippet2>
type BigIntegerFormatProvider() =
    interface IFormatProvider with

        member _.GetFormat(formatType: Type) =
            if formatType = typeof<NumberFormatInfo> then
                let numberFormat = NumberFormatInfo()
                numberFormat.NegativeSign <- "~"
                numberFormat
            else
                null
// </Snippet2>


let parseString () =
    // <Snippet1>
    try
        // <Snippet7>
        let number1 = BigInteger.Parse "12347534159895123"
        let number2 = BigInteger.Parse "987654321357159852"
        // </Snippet7>

        let number1 = number1 * bigint 3
        let number2 = number2 * bigint 2
        let result = BigInteger.Compare(number1, number2)

        match result with
        | -1 -> printfn $"{number2:N0} is greater than {number1:N0}."
        | 0 -> printfn $"{number1:N0} is equal to {number2:N0}."
        | 1
        | _ -> printfn $"{number1:N0} is greater than {number2:N0}."
    with :? FormatException ->
        printfn $"Unable to initialize integer because of invalid format in string."

// </Snippet1>

let parseStringWithIFormatProvider () =
    // <Snippet4>
    let fmt = NumberFormatInfo()
    fmt.NegativeSign <- "~"

    let number = BigInteger.Parse("~6354129876", fmt)
    printfn $"{number.ToString fmt}"
    printfn $"{number}"
// </Snippet4>

let parseWithCustomIFormatProvider () =
    // <Snippet3>
    let number = BigInteger.Parse("~6354129876", BigIntegerFormatProvider())
    printfn $"{number.ToString(BigIntegerFormatProvider())}"
    printfn $"{number}"
// </Snippet3>

let parseWithStyle () =
    // <Snippet5>
    let number = BigInteger.Parse("   -68054   ", NumberStyles.Integer)
    printfn $"{number}"
    let number = BigInteger.Parse("68054", NumberStyles.AllowHexSpecifier)
    printfn $"{number}"

    try
        let number =
            BigInteger.Parse("   -68054  ", NumberStyles.AllowLeadingWhite ||| NumberStyles.AllowTrailingWhite)

        printfn $"{number}"
    with :? FormatException as e ->
        printfn $"{e.Message}"

    try
        let number = BigInteger.Parse("   68054  ", NumberStyles.AllowLeadingSign)
        printfn $"{number}"
    with :? FormatException as e ->
        printfn $"{e.Message}"
// The method produces the following output:
//     -68054
//     426068
//     Input string was not in a correct format.
//     Input string was not in a correct format.
// </Snippet5>

let parseOverload4 () =
    // <Snippet6>
    // Call parse with default values of style and provider
    printfn $"""{BigInteger.Parse("  -300   ", NumberStyles.Integer, CultureInfo.CurrentCulture)}"""

    // Call parse with default values of style and provider supporting tilde as negative sign
    printfn $"""{BigInteger.Parse("   ~300  ", NumberStyles.Integer, BigIntegerFormatProvider())}"""

    // Call parse with only AllowLeadingWhite and AllowTrailingWhite
    // Exception thrown because of presence of negative sign
    try
        printfn
            $"""{BigInteger.Parse(
                     "    ~300   ",
                     NumberStyles.AllowLeadingWhite ||| NumberStyles.AllowTrailingWhite,
                     BigIntegerFormatProvider()
                 )}"""
    with :? FormatException as e ->
        printfn $"{e.GetType().Name}: \n   {e.Message}"

    // Call parse with only AllowHexSpecifier
    // Exception thrown because of presence of negative sign
    try
        printfn $"""{BigInteger.Parse("-3af", NumberStyles.AllowHexSpecifier, BigIntegerFormatProvider())}"""
    with :? FormatException as e ->
        printfn $"{e.GetType().Name}: \n   {e.Message}"

    // Call parse with only NumberStyles.None
    // Exception thrown because of presence of white space and sign
    try
        printfn $"""{BigInteger.Parse(" -300 ", NumberStyles.None, BigIntegerFormatProvider())}"""
    with :? FormatException as e ->
        printfn $"{e.GetType().Name}: \n   {e.Message}"
// <</Snippet6>

parseString ()
Console.WriteLine()
parseStringWithIFormatProvider ()
Console.WriteLine()
parseWithCustomIFormatProvider ()
Console.WriteLine()
parseWithStyle ()
parseOverload4 ()
