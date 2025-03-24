open System
open System.Globalization

let callDefaultToString () =

    // <Snippet1>
    let value = -16325091L
    // Display value using default ToString method.
    printfn $"{value.ToString()}"            // Displays -16325091
    // Display value using some standard format specifiers.
    printfn $"""{value.ToString "G"}"""         // Displays -16325091
    printfn $"""{value.ToString "C"}"""         // Displays ($16,325,091.00)
    printfn $"""{value.ToString "D"}"""         // Displays -16325091
    printfn $"""{value.ToString "F"}"""         // Displays -16325091.00
    printfn $"""{value.ToString "N"}"""         // Displays -16,325,091.00
    printfn $"""{value.ToString "N0"}"""        // Displays -16,325,091
    printfn $"""{value.ToString "X"}"""         // Displays FFFFFFFFFF06E61D
    // </Snippet1>

let callToStringWithSpecificCultures () =
    // <Snippet2>
    let value = -16325901L
    // Display value using the invariant culture.
    printfn $"{value.ToString CultureInfo.InvariantCulture}"
    // Display value using the en-GB culture.
    printfn $"""{value.ToString(CultureInfo.CreateSpecificCulture "en-GB" )}"""
    // Display value using the de-DE culture.
    printfn $"""{value.ToString(CultureInfo.CreateSpecificCulture "de-DE" )}"""
    // This example displays the following output to the console:
    //       -16325901
    //       -16325901
    //       -16325901
    // </Snippet2>


let callToStringWithSpecificSpecifiers () =
    // <Snippet3>
    let value = -16325L

    // Use standard numeric format specifier.
    let specifier = "G"
    printfn $"{specifier}: {value.ToString specifier}"
    // Displays:    G: -16325

    let specifier = "C"
    printfn $"{specifier}: {value.ToString specifier}"
    // Displays:    C: ($16,325.00)

    let specifier = "D8"
    printfn $"{specifier}: {value.ToString specifier}"
    // Displays:    D8: -00016325

    let specifier = "E4"
    printfn $"{specifier}: {value.ToString specifier}"
    // Displays:    E4: -1.6325E+004

    let specifier = "e3"
    printfn $"{specifier}: {value.ToString specifier}"
    // Displays:    e3: -1.633e+004

    let specifier = "F"
    printfn $"{specifier}: {value.ToString specifier}"
    // Displays:    F: -16325.00

    let specifier = "N"
    printfn $"{specifier}: {value.ToString specifier }"
    // Displays:    N: -16,325.00

    let specifier = "P"
    printfn $"{specifier}: {(float value / 100000.0).ToString specifier}"
    // Displays:    P: -16.33 %

    let specifier = "X"
    printfn $"{specifier}: {value.ToString(specifier)}"
    // Displays:    X: FFFFFFFFFFFFC03B

    // Use custom numeric format specifiers.
    let specifier = "0,0.000"
    printfn $"{specifier}: {value.ToString(specifier)}"
    // Displays:    0,0.000: -16,325.000

    let specifier = "#,#.00#(#,#.00#)"
    printfn $"{specifier}: {(value * -1L).ToString specifier}"
    // Displays:    #,#.00#(#,#.00#): 16,325.00
    
    // </Snippet3>

let callToStringWithSpecifiersAndCultures () =
    // <Snippet4>
    // Define cultures whose formatting conventions are to be used.
    let cultures = 
        [| CultureInfo.CreateSpecificCulture "en-US"
           CultureInfo.CreateSpecificCulture "fr-FR"
           CultureInfo.CreateSpecificCulture "es-ES" |]

    let positiveNumber = 1679L
    let negativeNumber = -3045L
    let specifiers = [| "G"; "C"; "D8"; "E2"; "F"; "N"; "N0"; "P"; "X8" |]

    for specifier in specifiers do
        for culture in cultures do
            // Display values with "G" format specifier.
            printfn $"{specifier} format using {culture.Name} culture: {positiveNumber.ToString(specifier, culture), 16} {negativeNumber.ToString(specifier, culture), 16}"           
        printfn ""

    // The example displays the following output to the console:
    //    G format using en-US culture:             1679            -3045
    //    G format using fr-FR culture:             1679            -3045
    //    G format using es-ES culture:             1679            -3045
    //
    //    C format using en-US culture:        $1,679.00      ($3,045.00)
    //    C format using fr-FR culture:       1 679,00 €      -3 045,00 €
    //    C format using es-ES culture:       1.679,00 €      -3.045,00 €
    //
    //    D8 format using en-US culture:         00001679        -00003045
    //    D8 format using fr-FR culture:         00001679        -00003045
    //    D8 format using es-ES culture:         00001679        -00003045
    //
    //    E2 format using en-US culture:        1.68E+003       -3.05E+003
    //    E2 format using fr-FR culture:        1,68E+003       -3,05E+003
    //    E2 format using es-ES culture:        1,68E+003       -3,05E+003
    //
    //    F format using en-US culture:          1679.00         -3045.00
    //    F format using fr-FR culture:          1679,00         -3045,00
    //    F format using es-ES culture:          1679,00         -3045,00
    //
    //    N format using en-US culture:         1,679.00        -3,045.00
    //    N format using fr-FR culture:         1 679,00        -3 045,00
    //    N format using es-ES culture:         1.679,00        -3.045,00
    //
    //    N0 format using en-US culture:         1,679           -3,045
    //    N0 format using fr-FR culture:         1 679           -3 045
    //    N0 format using es-ES culture:         1.679           -3.045
    //
    //    P format using en-US culture:      167,900.00%     -304,500.00%
    //    P format using fr-FR culture:     167 900,00 %    -304 500,00 %
    //    P format using es-ES culture:     167.900,00 %    -304.500,00 %
    //
    //    X8 format using en-US culture:         0000068F FFFFFFFFFFFFF41B
    //    X8 format using fr-FR culture:         0000068F FFFFFFFFFFFFF41B
    //    X8 format using es-ES culture:         0000068F FFFFFFFFFFFFF41B
    // </Snippet4>

callDefaultToString ()
printfn ""
callToStringWithSpecificCultures ()
printfn ""
callToStringWithSpecificSpecifiers ()
printfn ""
callToStringWithSpecifiersAndCultures ()