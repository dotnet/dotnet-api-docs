module ToString1

open System.Globalization

let callDefaultToString () =
    // <Snippet1>
    let number = 1.6E20F
    // Displays 1.6E+20.
    printfn $"{number.ToString()}"

    let number = 1.6E2F
    // Displays 160.
    printfn $"{number.ToString()}"
    
    let number = -3.541F
    // Displays -3.541.
    printfn $"{number.ToString()}"

    let number = -1502345222199E-07F
    // Displays -150234.5222199.
    printfn $"{number.ToString()}"
    
    let number = -15023452221990199574E-09F
    // Displays -15023452221.9902.
    printfn $"{number.ToString()}"
    
    let number = 0.60344F
    // Displays 0.60344.
    printfn $"{number.ToString()}"
    
    let number = 0.000000001F
    // Displays 1E-09.
    printfn $"{number.ToString()}"
    // </Snippet1>

let callToStringWithFormatProvider () =
    // <Snippet2>
    let value = -16325.62015F
    // Display value using the invariant culture.
    printfn $"{value.ToString CultureInfo.InvariantCulture}"
    // Display value using the en-GB culture.
    printfn $"""{value.ToString(CultureInfo.CreateSpecificCulture "en-GB")}"""
    // Display value using the de-DE culture.
    printfn $"""{value.ToString(CultureInfo.CreateSpecificCulture "de-DE")}"""

    let value = 16034.125E21F
    // Display value using the invariant culture.
    printfn $"{value.ToString CultureInfo.InvariantCulture}"
    // Display value using the en-GB culture.
    printfn $"""{value.ToString(CultureInfo.CreateSpecificCulture "en-GB")}"""
    // Display value using the de-DE culture.
    printfn $"""{value.ToString(CultureInfo.CreateSpecificCulture "de-DE")}"""
    // This example displays the following output to the console:
    //       -16325.62015
    //       -16325.62015
    //       -16325,62015
    //       1.6034125E+25
    //       1.6034125E+25
    //       1,6034125E+25
    // </Snippet2>      

let callToStringWithFormatString () =
    // <Snippet3>
    let numbers = 
        [| 1054.32179F; -195489100.8377F; 1.0437E21F; -1.0573e-05F |]
    let specifiers = 
        [| "C"; "E"; "e"; "F"; "G"; "N"; "P" 
           "R"; "#,000.000"; "0.###E-000"
           "000,000,000,000.00###" |]

    for number in numbers do
        printfn $"Formatting of {number}:"
        for specifier in specifiers do
            printfn $"   {specifier,5}: {number.ToString specifier}" 
        printfn ""
    // The example displays the following output to the console:
    //       Formatting of 1054.32179:
    //              C: $1,054.32
    //              E: 1.054322E+003
    //              e: 1.054322e+003
    //              F: 1054.32
    //              G: 1054.32179
    //              N: 1,054.32
    //              P: 105,432.18 %
    //              R: 1054.32179
    //          #,000.000: 1,054.322
    //          0.###E-000: 1.054E003
    //          000,000,000,000.00###: 000,000,001,054.322
    //       
    //       Formatting of -195489100.8377:
    //              C: ($195,489,100.84)
    //              E: -1.954891E+008
    //              e: -1.954891e+008
    //              F: -195489100.84
    //              G: -195489100.8377
    //              N: -195,489,100.84
    //              P: -19,548,910,083.77 %
    //              R: -195489100.8377
    //          #,000.000: -195,489,100.838
    //          0.###E-000: -1.955E008
    //          000,000,000,000.00###: -000,195,489,100.00
    //       
    //       Formatting of 1.0437E+21:
    //              C: $1,043,700,000,000,000,000,000.00
    //              E: 1.043700E+021
    //              e: 1.043700e+021
    //              F: 1043700000000000000000.00
    //              G: 1.0437E+21
    //              N: 1,043,700,000,000,000,000,000.00
    //              P: 104,370,000,000,000,000,000,000.00 %
    //              R: 1.0437E+21
    //          #,000.000: 1,043,700,000,000,000,000,000.000
    //          0.###E-000: 1.044E021
    //          000,000,000,000.00###: 1,043,700,000,000,000,000,000.00
    //       
    //       Formatting of -1.0573E-05:
    //              C: $0.00
    //              E: -1.057300E-005
    //              e: -1.057300e-005
    //              F: 0.00
    //              G: -1.0573E-05
    //              N: 0.00
    //              P: 0.00 %
    //              R: -1.0573E-05
    //          #,000.000: 000.000
    //          0.###E-000: -1.057E-005
    //          000,000,000,000.00###: -000,000,000,000.00001 
    // </Snippet3>       

let callToStringWithFormatStringAndProvider () =
    // <Snippet4>
    let value = 16325.62901F

    // Use standard numeric format specifiers.
    let specifier = "G"
    let culture = CultureInfo.CreateSpecificCulture "eu-ES"
    printfn $"{value.ToString(specifier, culture)}"
    // Displays:    16325,62901
    printfn $"{value.ToString(specifier, CultureInfo.InvariantCulture)}"
    // Displays:    16325.62901
    
    let specifier = "C"
    let culture = CultureInfo.CreateSpecificCulture "en-US"
    printfn $"{value.ToString(specifier, culture)}"
    // Displays:    $16,325.63
    let culture = CultureInfo.CreateSpecificCulture "en-GB"
    printfn $"{value.ToString(specifier, culture)}"
    // Displays:    £16,325.63
    
    let specifier = "E04"
    let culture = CultureInfo.CreateSpecificCulture "sv-SE"
    printfn $"{value.ToString(specifier, culture)}"
    // Displays: 1,6326E+004   
    let culture = CultureInfo.CreateSpecificCulture "en-NZ"
    printfn $"{value.ToString(specifier, culture)}"
    // Displays:    1.6326E+004   
    
    let specifier = "F"
    let culture = CultureInfo.CreateSpecificCulture "fr-FR"
    printfn $"{value.ToString(specifier, culture)}"
    // Displays:    16325,63
    let culture = CultureInfo.CreateSpecificCulture "en-CA"
    printfn $"{value.ToString(specifier, culture)}"
    // Displays:    16325.63
    
    let specifier = "N"
    let culture = CultureInfo.CreateSpecificCulture "es-ES"
    printfn $"{value.ToString(specifier, culture)}"
    // Displays:    16.325,63
    let culture = CultureInfo.CreateSpecificCulture "fr-CA"
    printfn $"{value.ToString(specifier, culture)}"
    // Displays:    16 325,63
    
    let specifier = "P"
    let culture = CultureInfo.InvariantCulture
    printfn $"{(value / 10000f).ToString(specifier, culture)}"
    // Displays:    163.26 %
    let culture = CultureInfo.CreateSpecificCulture "ar-EG"
    printfn $"{(value / 10000f).ToString(specifier, culture)}"
    // Displays:    163.256 %
    // </Snippet4>   

callDefaultToString ()
printfn "----------"
callToStringWithFormatProvider ()
printfn "----------"
callToStringWithFormatString ()
printfn "----------"
callToStringWithFormatStringAndProvider ()
