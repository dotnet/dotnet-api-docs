module ToString4

// <Snippet3>
open System
open System.Globalization

let cultures = 
    [ CultureInfo.InvariantCulture
      CultureInfo "en-us"
      CultureInfo "fr-fr"
      CultureInfo "de-DE"
      CultureInfo "es-ES"
      CultureInfo "ja-JP" ]

let thisDate = DateTime(2009, 5, 1, 9, 0, 0)

for culture in cultures do
    let cultureName =
        if String.IsNullOrEmpty culture.Name then
            culture.NativeName
        else
            culture.Name

    printfn $"In {cultureName}, {thisDate.ToString culture}"


// The example produces the following output:
//    In Invariant Language (Invariant Country), 05/01/2009 09:00:00
//    In en-US, 5/1/2009 9:00:00 AM
//    In fr-FR, 01/05/2009 09:00:00
//    In de-DE, 01.05.2009 09:00:00
//    In es-ES, 01/05/2009 9:00:00
//    In ja-JP, 2009/05/01 9:00:00
// </Snippet3>