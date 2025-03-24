module tostring3

// <Snippet4>
open System
open System.Globalization

// Create a list of all supported standard date and time format specifiers.
let formats = 
    [ "d"; "D"; "f"; "F"; "g"; "G"; "m"; "o" 
      "r"; "s"; "t"; "T"; "u"; "U"; "Y" ]

// Create a list of four cultures.
let cultures = 
    [ CultureInfo.GetCultureInfo "de-DE"
      CultureInfo.GetCultureInfo "en-US"
      CultureInfo.GetCultureInfo "es-ES"
      CultureInfo.GetCultureInfo "fr-FR" ]

// Define date to be displayed.
let dateToDisplay = DateTime(2008, 10, 31, 17, 4, 32)

// Iterate each standard format specifier.
for formatSpecifier in formats do
    for culture in cultures do
        printfn $"{formatSpecifier} Format Specifier {culture.Name, 10} Culture {dateToDisplay.ToString(formatSpecifier, culture), 40}"
    printfn ""

// The example displays the following output:
//    d Format Specifier      de-DE Culture                               31.10.2008
//    d Format Specifier      en-US Culture                               10/31/2008
//    d Format Specifier      es-ES Culture                               31/10/2008
//    d Format Specifier      fr-FR Culture                               31/10/2008
//    
//    D Format Specifier      de-DE Culture                Freitag, 31. Oktober 2008
//    D Format Specifier      en-US Culture                 Friday, October 31, 2008
//    D Format Specifier      es-ES Culture           viernes, 31 de octubre de 2008
//    D Format Specifier      fr-FR Culture                 vendredi 31 octobre 2008
//    
//    f Format Specifier      de-DE Culture          Freitag, 31. Oktober 2008 17:04
//    f Format Specifier      en-US Culture         Friday, October 31, 2008 5:04 PM
//    f Format Specifier      es-ES Culture     viernes, 31 de octubre de 2008 17:04
//    f Format Specifier      fr-FR Culture           vendredi 31 octobre 2008 17:04
//    
//    F Format Specifier      de-DE Culture       Freitag, 31. Oktober 2008 17:04:32
//    F Format Specifier      en-US Culture      Friday, October 31, 2008 5:04:32 PM
//    F Format Specifier      es-ES Culture  viernes, 31 de octubre de 2008 17:04:32
//    F Format Specifier      fr-FR Culture        vendredi 31 octobre 2008 17:04:32
//    
//    g Format Specifier      de-DE Culture                         31.10.2008 17:04
//    g Format Specifier      en-US Culture                       10/31/2008 5:04 PM
//    g Format Specifier      es-ES Culture                         31/10/2008 17:04
//    g Format Specifier      fr-FR Culture                         31/10/2008 17:04
//    
//    G Format Specifier      de-DE Culture                      31.10.2008 17:04:32
//    G Format Specifier      en-US Culture                    10/31/2008 5:04:32 PM
//    G Format Specifier      es-ES Culture                      31/10/2008 17:04:32
//    G Format Specifier      fr-FR Culture                      31/10/2008 17:04:32
//    
//    m Format Specifier      de-DE Culture                              31. Oktober
//    m Format Specifier      en-US Culture                               October 31
//    m Format Specifier      es-ES Culture                            31 de octubre
//    m Format Specifier      fr-FR Culture                               31 octobre
//    
//    o Format Specifier      de-DE Culture              2008-10-31T17:04:32.0000000
//    o Format Specifier      en-US Culture              2008-10-31T17:04:32.0000000
//    o Format Specifier      es-ES Culture              2008-10-31T17:04:32.0000000
//    o Format Specifier      fr-FR Culture              2008-10-31T17:04:32.0000000
//    
//    r Format Specifier      de-DE Culture            Fri, 31 Oct 2008 17:04:32 GMT
//    r Format Specifier      en-US Culture            Fri, 31 Oct 2008 17:04:32 GMT
//    r Format Specifier      es-ES Culture            Fri, 31 Oct 2008 17:04:32 GMT
//    r Format Specifier      fr-FR Culture            Fri, 31 Oct 2008 17:04:32 GMT
//    
//    s Format Specifier      de-DE Culture                      2008-10-31T17:04:32
//    s Format Specifier      en-US Culture                      2008-10-31T17:04:32
//    s Format Specifier      es-ES Culture                      2008-10-31T17:04:32
//    s Format Specifier      fr-FR Culture                      2008-10-31T17:04:32
//    
//    t Format Specifier      de-DE Culture                                    17:04
//    t Format Specifier      en-US Culture                                  5:04 PM
//    t Format Specifier      es-ES Culture                                    17:04
//    t Format Specifier      fr-FR Culture                                    17:04
//    
//    T Format Specifier      de-DE Culture                                 17:04:32
//    T Format Specifier      en-US Culture                               5:04:32 PM
//    T Format Specifier      es-ES Culture                                 17:04:32
//    T Format Specifier      fr-FR Culture                                 17:04:32
//    
//    u Format Specifier      de-DE Culture                     2008-10-31 17:04:32Z
//    u Format Specifier      en-US Culture                     2008-10-31 17:04:32Z
//    u Format Specifier      es-ES Culture                     2008-10-31 17:04:32Z
//    u Format Specifier      fr-FR Culture                     2008-10-31 17:04:32Z
//    
//    U Format Specifier      de-DE Culture       Freitag, 31. Oktober 2008 09:04:32
//    U Format Specifier      en-US Culture      Friday, October 31, 2008 9:04:32 AM
//    U Format Specifier      es-ES Culture   viernes, 31 de octubre de 2008 9:04:32
//    U Format Specifier      fr-FR Culture        vendredi 31 octobre 2008 09:04:32
//    
//    Y Format Specifier      de-DE Culture                             Oktober 2008
//    Y Format Specifier      en-US Culture                             October 2008
//    Y Format Specifier      es-ES Culture                          octubre de 2008
//    Y Format Specifier      fr-FR Culture                             octobre 2008
// </Snippet4>