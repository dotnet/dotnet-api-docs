module tostring3

open System
open System.Globalization

let convertDateTimeWithProvider () =
    // <Snippet13>
    // Specify the date to be formatted using various cultures.
    let tDate = DateTime(2010, 4, 15, 20, 30, 40, 333)
    // Specify the cultures.
    let cultureNames = 
        [| "en-US"; "es-AR"; "fr-FR"; "hi-IN";
            "ja-JP"; "nl-NL"; "ru-RU"; "ur-PK" |]

    printfn $"Converting the date {Convert.ToString(tDate, CultureInfo.InvariantCulture)}: "

    for cultureName in cultureNames do
        let culture = CultureInfo cultureName
        let dateString = Convert.ToString(tDate, culture)
        printfn $"   {culture.Name}:  {dateString,-12}"
    // The example displays the following output:
    //       Converting the date 04/15/2010 20:30:40:
    //          en-US:  4/15/2010 8:30:40 PM
    //          es-AR:  15/04/2010 08:30:40 p.m.
    //          fr-FR:  15/04/2010 20:30:40
    //          hi-IN:  15-04-2010 20:30:40
    //          ja-JP:  2010/04/15 20:30:40
    //          nl-NL:  15-4-2010 20:30:40
    //          ru-RU:  15.04.2010 20:30:40
    //          ur-PK:  15/04/2010 8:30:40 PM
    // </Snippet13>

let convertDecimalWithProvider () =
    // <Snippet14>
    // Define an array of numbers to display.
    let numbers = 
        [| 1734231911290.16m; -17394.32921m; 3193.23m; 98012368321.684m |]
    // Define the culture names used to display them.
    let cultureNames = [| "en-US"; "fr-FR"; "ja-JP"; "ru-RU" |]

    for number in numbers do
        printfn $"{Convert.ToString(number, CultureInfo.InvariantCulture)}:"
        for cultureName in cultureNames do
            let culture = CultureInfo cultureName
            printfn $"   {culture.Name}: {Convert.ToString(number, culture),20}"
        printfn ""
    // The example displays the following output:
    //    1734231911290.16:
    //       en-US:     1734231911290.16
    //       fr-FR:     1734231911290,16
    //       ja-JP:     1734231911290.16
    //       ru-RU:     1734231911290,16
    //
    //    -17394.32921:
    //       en-US:         -17394.32921
    //       fr-FR:         -17394,32921
    //       ja-JP:         -17394.32921
    //       ru-RU:         -17394,32921
    //
    //    3193.23:
    //       en-US:              3193.23
    //       fr-FR:              3193,23
    //       ja-JP:              3193.23
    //       ru-RU:              3193,23
    //
    //    98012368321.684:
    //       en-US:      98012368321.684
    //       fr-FR:      98012368321,684
    //       ja-JP:      98012368321.684
    //       ru-RU:      98012368321,684
    // </Snippet14>

let convertDoubleWithProvider () =
    // <Snippet15>
    // Define an array of numbers to display.
    let numbers = [| -1.5345e16; -123.4321; 19092.123; 1.1734231911290e16 |]
    // Define the culture names used to display them.
    let cultureNames = [| "en-US"; "fr-FR"; "ja-JP"; "ru-RU" |]

    for number in numbers do
        printfn $"{Convert.ToString(number, CultureInfo.InvariantCulture)}:"
        for cultureName in cultureNames do
            let culture = CultureInfo cultureName
            printfn "   {culture.Name}: {Convert.ToString(number, culture),20}"
        printfn ""
    // The example displays the following output:
    //    -1.5345E+16:
    //       en-US:          -1.5345E+16
    //       fr-FR:          -1,5345E+16
    //       ja-JP:          -1.5345E+16
    //       ru-RU:          -1,5345E+16
    //
    //    -123.4321:
    //       en-US:            -123.4321
    //       fr-FR:            -123,4321
    //       ja-JP:            -123.4321
    //       ru-RU:            -123,4321
    //
    //    19092.123:
    //       en-US:            19092.123
    //       fr-FR:            19092,123
    //       ja-JP:            19092.123
    //       ru-RU:            19092,123
    //
    //    1.173423191129E+16:
    //       en-US:   1.173423191129E+16
    //       fr-FR:   1,173423191129E+16
    //       ja-JP:   1.173423191129E+16
    //       ru-RU:   1,173423191129E+16
    // </Snippet15>

let convertByteWithProvider () =
    // <Snippet16>
    let numbers = [| 12uy; 100uy; Byte.MaxValue |]
    // Define the culture names used to display them.
    let cultureNames = [| "en-US"; "fr-FR" |]

    for number in numbers do
        printfn $"{Convert.ToString(number, CultureInfo.InvariantCulture)}:"
        for cultureName in cultureNames do
            let culture = CultureInfo cultureName
            printfn $"   {culture.Name}: {Convert.ToString(number, culture),20}"
        printfn ""
    // The example displays the following output:
    //       12:
    //          en-US:                   12
    //          fr-FR:                   12
    //
    //       100:
    //          en-US:                  100
    //          fr-FR:                  100
    //
    //       255:
    //          en-US:                  255
    //          fr-FR:                  255
    // </Snippet16>

let convertSByteWithProvider () =
    // <Snippet17>
    let numbers = [| SByte.MinValue; -12y; 17y; SByte.MaxValue |]
    let nfi = NumberFormatInfo()
    nfi.NegativeSign <- "~"
    nfi.PositiveSign <- "!"
    for number in numbers do
        printfn $"{Convert.ToString(number, nfi)}"
    // The example displays the following output:
    //       ~128
    //       ~12
    //       17
    //       127
    // </Snippet17>

let convertSingleWithProvider () =
    // <Snippet18>
    // Define an array of numbers to display.
    let numbers = [| -1.5345e16f; -123.4321f; 19092.123f; 1.1734231911290e16f |]
    // Define the culture names used to display them.
    let cultureNames = [| "en-US"; "fr-FR"; "ja-JP"; "ru-RU" |]

    for number in numbers do
        printfn $"{Convert.ToString(number, CultureInfo.InvariantCulture)}:"
        for cultureName in cultureNames do
            let culture = CultureInfo cultureName
            printfn $"   {culture.Name}: {Convert.ToString(number, culture),20}"
        printfn ""
    // The example displays the following output:
    //    -1.5345E+16:
    //       en-US:          -1.5345E+16
    //       fr-FR:          -1,5345E+16
    //       ja-JP:          -1.5345E+16
    //       ru-RU:          -1,5345E+16
    //
    //    -123.4321:
    //       en-US:            -123.4321
    //       fr-FR:            -123,4321
    //       ja-JP:            -123.4321
    //       ru-RU:            -123,4321
    //
    //    19092.123:
    //       en-US:            19092.123
    //       fr-FR:            19092,123
    //       ja-JP:            19092.123
    //       ru-RU:            19092,123
    //
    //    1.173423191129E+16:
    //       en-US:   1.173423191129E+16
    //       fr-FR:   1,173423191129E+16
    //       ja-JP:   1.173423191129E+16
    //       ru-RU:   1,173423191129E+16
    // </Snippet18>

let convertInt16WithProvider () =
    // <Snippet19>
    let numbers = [| Int16.MinValue; Int16.MaxValue |]
    let nfi = NumberFormatInfo()
    nfi.NegativeSign <- "~"
    nfi.PositiveSign <- "!"

    for number in numbers do
        printfn $"{Convert.ToString(number, CultureInfo.InvariantCulture),-8}  -->  {Convert.ToString(number, nfi),8}"
    // The example displays the following output:
    //       -32768    -->    ~32768
    //       32767     -->     32767
    // </Snippet19>

let convertInt32WithProvider () =
    // <Snippet20>
    let numbers = [| Int32.MinValue; Int32.MaxValue |]
    let nfi = NumberFormatInfo()
    nfi.NegativeSign <- "~"
    nfi.PositiveSign <- "!"

    for number in numbers do
        printfn $"{Convert.ToString(number, CultureInfo.InvariantCulture),-12}  -->  {Convert.ToString(number, nfi),12}"
    // The example displays the following output:
    //       -2147483648  -->  ~2147483648
    //       2147483647  -->  2147483647
    // </Snippet20>

let convertInt64WithProvider () =
    // <Snippet21>
    let numbers = [| (int64 Int32.MinValue) * 2L; (int64 Int32.MaxValue) * 2L |]
    let nfi = NumberFormatInfo()
    nfi.NegativeSign <- "~"
    nfi.PositiveSign <- "!"

    for number in numbers do
        printfn $"{Convert.ToString(number, CultureInfo.InvariantCulture),-12}  -->  {Convert.ToString(number, nfi),12}"
    // The example displays the following output:
    //       -4294967296  -->  ~4294967296
    //       4294967294  -->  4294967294
    // </Snippet21>

let convertUInt16WithProvider () =
    // <Snippet22>
    let number = UInt16.MaxValue
    let nfi = NumberFormatInfo()
    nfi.NegativeSign <- "~"
    nfi.PositiveSign <- "!"

    printfn $"{Convert.ToString(number, CultureInfo.InvariantCulture),-6}  -->  {Convert.ToString(number, nfi),6}"
    // The example displays the following output:
    //       65535   -->   65535
    // </Snippet22>

let convertUInt32WithProvider () =
    // <Snippet23>
    let number = UInt32.MaxValue
    let nfi = NumberFormatInfo()
    nfi.NegativeSign <- "~"
    nfi.PositiveSign <- "!"

    printfn $"{Convert.ToString(number, CultureInfo.InvariantCulture),-8}  -->  {Convert.ToString(number, nfi),8}"
    // The example displays the following output:
    //       4294967295  -->  4294967295
    // </Snippet23>

let convertUInt64WithProvider () =
    // <Snippet24>
    let number = UInt64.MaxValue
    let nfi = NumberFormatInfo()
    nfi.NegativeSign <- "~"
    nfi.PositiveSign <- "!"

    printfn $"{Convert.ToString(number, CultureInfo.InvariantCulture),-12}  -->  {Convert.ToString(number, nfi),12}"
    // The example displays the following output:
    //    18446744073709551615  -->  18446744073709551615
    // </Snippet24>

convertDateTimeWithProvider ()
printfn "-----"
convertDecimalWithProvider ()
printfn "-----"
convertDoubleWithProvider ()
printfn "-----"
convertByteWithProvider ()
printfn "-----"
convertSByteWithProvider ()
printfn "-----"
convertSingleWithProvider ()
printfn "-----"
convertInt16WithProvider ()
printfn "-----"
convertInt32WithProvider ()
printfn "-----"
convertInt64WithProvider ()
printfn "-----"
convertUInt16WithProvider ()
printfn "-----"
convertUInt32WithProvider ()
printfn "-----"
convertUInt64WithProvider ()
