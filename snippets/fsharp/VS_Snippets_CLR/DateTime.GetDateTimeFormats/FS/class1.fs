open System

let showDefaultFormats () =
    // <Snippet1>
    let july28 = DateTime(2009, 7, 28, 5, 23, 15, 16)

    let july28Formats = july28.GetDateTimeFormats()

    // Print out july28 in all DateTime formats using the default culture.
    for format in july28Formats do
        printfn $"{format}"
    // </Snippet1>

let showDefaultFrenchFormats () =
    // <Snippet2>
    let july28 = DateTime(2009, 7, 28, 5, 23, 15, 16)
    
    let culture =
        System.Globalization.CultureInfo("fr-FR", true)
    
    // Get the short date formats using the "fr-FR" culture.
    let frenchJuly28Formats =
        july28.GetDateTimeFormats culture

    // Display july28 in various formats using "fr-FR" culture.
    for format in frenchJuly28Formats do
        printfn $"{format}"
    // </Snippet2>

let showDefaultDFormat () =
    // <Snippet3>
    let july28 = DateTime(2009, 7, 28, 5, 23, 15)
    
    // Get the long date formats using the current culture.
    let longJuly28Formats =
        july28.GetDateTimeFormats 'D'

    // Display july28 in all long date formats.
    for format in longJuly28Formats do
        printfn $"{format}"

    // The example displays the following output:
    //       Tuesday, July 28, 2009
    //       July 28, 2009
    //       Tuesday, 28 July, 2009
    //       28 July, 2009
    // </Snippet3>

let showFrenchDFormat () =
    // <Snippet4>
    let july28 = DateTime(2009, 7, 28, 5, 23, 15)
    
    let culture =
        System.Globalization.CultureInfo("fr-FR", true)
    
    // Get the short date formats using the "fr-FR" culture.
    let frenchJuly28Formats =
        july28.GetDateTimeFormats('d', culture)

    // Display july28 in short date formats using "fr-FR" culture.
    for format in frenchJuly28Formats do
        printfn $"{format}"

    // The example displays the following output:
    //       28/07/2009
    //       28/07/09
    //       28.07.09
    //       28-07-09
    //       2009-07-28
    // </Snippet4>


showDefaultFormats ()
showDefaultFrenchFormats ()
printfn "\nDefault 'D' Format:\n"
showDefaultDFormat ()
printfn "\nFrench 'D' Format:\n"
showFrenchDFormat ()