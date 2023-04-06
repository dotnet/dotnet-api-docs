open System
open System.Globalization

let callDefaultToString () =
    // <Snippet2>
    let value = -16325.62m
    // Display value using default ToString method.
    printfn $"{value.ToString()}"            // Displays -16325.62
    // Display value using some standard format specifiers.
    printfn $"""{value.ToString "G"}"""      // Displays -16325.62
    printfn $"""{value.ToString "C"}"""      // Displays ($16,325.62)
    printfn $"""{value.ToString "F"}"""      // Displays -16325.62
    // </Snippet2>

let callToStringWithSpecificCultures () =
    // <Snippet3>
    let value = -16325.62m
    // Display value using the invariant culture.
    printfn $"{value.ToString CultureInfo.InvariantCulture}"
    // Display value using the en-GB culture.
    printfn $"""{value.ToString(CultureInfo.CreateSpecificCulture "en-GB")}"""
    // Display value using the de-DE culture.
    printfn $"""{value.ToString(CultureInfo.CreateSpecificCulture "de-DE")}"""
    // This example displays the following output to the console:
    //       -16325.62
    //       -16325.62
    //       -16325,62
    // </Snippet3>

let callWithSpecificSpecifiers () =
    // <Snippet4>
    let value = 16325.62m

    // Use standard numeric format specifiers.
    let specifier = "G"
    printfn $"{specifier}: {value.ToString specifier}"
    // Displays:    G: 16325.62
    let specifier = "C"
    printfn $"{specifier}: {value.ToString specifier}"
    // Displays:    C: $16,325.62
    let specifier = "E04"
    printfn $"{specifier}: {value.ToString specifier}"
    // Displays:    E04: 1.6326E+004
    let specifier = "F"
    printfn $"{specifier}: {value.ToString specifier}"
    // Displays:    F: 16325.62
    let specifier = "N"
    printfn $"{specifier}: {value.ToString specifier}"
    // Displays:    N: 16,325.62
    let specifier = "P"
    printfn $"{specifier}: {(value / 10000m).ToString specifier}"
    // Displays:    P: 163.26 %

    // Use custom numeric format specifiers.
    let specifier = "0,0.000"
    printfn $"{specifier}: {value.ToString specifier}"
    // Displays:    0,0.000: 16,325.620
    let specifier = "#,#.00#(#,#.00#)"
    printfn $"{specifier}: {(value * -1m).ToString specifier}"
    // Displays:    #,#.00#(#,#.00#): (16,325.62)
    // </Snippet4>

let callWithSpecificSpecifiersAndCultures () =
    // <Snippet5>
    let value = 16325.62m

    // Use standard numeric format specifiers.
    let specifier = "G"
    let culture = CultureInfo.CreateSpecificCulture "eu-ES"
    Console.WriteLine(value.ToString(specifier, culture))
    // Displays:    16325,62
    Console.WriteLine(value.ToString(specifier, CultureInfo.InvariantCulture))
    // Displays:    16325.62

    let specifier = "C"
    let culture = CultureInfo.CreateSpecificCulture "en-US"
    Console.WriteLine(value.ToString(specifier, culture))
    // Displays:    $16,325.62
    let culture = CultureInfo.CreateSpecificCulture "en-GB"
    Console.WriteLine(value.ToString(specifier, culture))
    // Displays:    £16,325.62

    let specifier = "E04"
    let culture = CultureInfo.CreateSpecificCulture "sv-SE"
    Console.WriteLine(value.ToString(specifier, culture))
    // Displays: 1,6326E+004
    let culture = CultureInfo.CreateSpecificCulture "en-NZ"
    Console.WriteLine(value.ToString(specifier, culture))
    // Displays:    1.6326E+004

    let specifier = "F"
    let culture = CultureInfo.CreateSpecificCulture "fr-FR"
    Console.WriteLine(value.ToString(specifier, culture))
    // Displays:    16325,62
    let culture = CultureInfo.CreateSpecificCulture "en-CA"
    Console.WriteLine(value.ToString(specifier, culture))
    // Displays:    16325.62

    let specifier = "N"
    let culture = CultureInfo.CreateSpecificCulture "es-ES"
    Console.WriteLine(value.ToString(specifier, culture))
    // Displays:    16.325,62
    let culture = CultureInfo.CreateSpecificCulture "fr-CA"
    Console.WriteLine(value.ToString(specifier, culture))
    // Displays:    16 325,62

    let specifier = "P"
    let culture = CultureInfo.InvariantCulture
    printfn $"{(value / 10000m).ToString(specifier, culture)}"
    // Displays:    163.26 %
    let culture = CultureInfo.CreateSpecificCulture "ar-EG"
    printfn $"{(value / 10000m).ToString(specifier, culture)}"
    // Displays:    163.256 %
    // </Snippet5>

callDefaultToString()
printfn "-----"
callToStringWithSpecificCultures()
printfn "-----"
callWithSpecificSpecifiers()
printfn "-----"
callWithSpecificSpecifiersAndCultures() 