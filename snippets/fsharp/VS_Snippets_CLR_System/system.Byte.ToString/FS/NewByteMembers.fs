open System
open System.Globalization

let callToString () =
    // <Snippet2>
    let bytes = [| 0; 1; 14; 168; 255 |]
    for byteValue in bytes do
        printfn $"{byteValue}"

    // The example displays the following output to the console if the current
    // culture is en-US:
    //       0
    //       1
    //       14
    //       168
    //       255
    // </Snippet2>

let specifyFormatProvider () =
    // <Snippet3>
    let bytes = [| 0; 1; 14; 168; 255 |]
    let providers = 
        [ CultureInfo "en-us"
          CultureInfo "fr-fr"
          CultureInfo "de-de"
          CultureInfo "es-es" ]

    for byteValue in bytes do
        for provider in providers do
            printf $"{byteValue.ToString provider,3} ({provider.Name})      " 

        printfn ""

    // The example displays the following output to the console:
    //      0 (en-US)        0 (fr-FR)        0 (de-DE)        0 (es-ES)
    //      1 (en-US)        1 (fr-FR)        1 (de-DE)        1 (es-ES)
    //     14 (en-US)       14 (fr-FR)       14 (de-DE)       14 (es-ES)
    //    168 (en-US)      168 (fr-FR)      168 (de-DE)      168 (es-ES)
    //    255 (en-US)      255 (fr-FR)      255 (de-DE)      255 (es-ES)
    // </Snippet3>

let specifyFormatString () =
    // <Snippet4>
    let formats = 
        [ "C3"; "D4"; "e1"; "E2"; "F1"; "G"; "N1"
          "P0"; "X4"; "0000.0000" ]
    let number = 240uy
    for format in formats do
        printfn $"'{format}' format specifier: {number.ToString format}"

    // The example displays the following output to the console if the
    // current culture is en-us:
    //       'C3' format specifier: $240.000
    //       'D4' format specifier: 0240
    //       'e1' format specifier: 2.4e+002
    //       'E2' format specifier: 2.40E+002
    //       'F1' format specifier: 240.0
    //       'G' format specifier: 240
    //       'N1' format specifier: 240.0
    //       'P0' format specifier: 24,000 %
    //       'X4' format specifier: 00F0
    //       '0000.0000' format specifier: 0240.0000
    // </Snippet4>

let formatWithProviders () =
    // <Snippet5>
    let byteValue = 250uy
    let providers = 
        [ CultureInfo "en-us"
          CultureInfo "fr-fr"
          CultureInfo "es-es"
          CultureInfo "de-de" ]

    for provider in providers do
        printfn $"""{byteValue.ToString("N2", provider)} ({provider.Name})"""

    // The example displays the following output to the console:
    //       250.00 (en-US)
    //       250,00 (fr-FR)
    //       250,00 (es-ES)
    //       250,00 (de-DE)
    // </Snippet5>

callToString ()
printfn ""
specifyFormatProvider ()
printfn ""
specifyFormatString ()
printfn ""
formatWithProviders ()