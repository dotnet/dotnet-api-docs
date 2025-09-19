module tostring5

// <Snippet5>
open System
open System.Globalization

let formats = [ "G"; "MM/yyyy"; @"MM\/dd\/yyyy HH:mm"; "yyyyMMdd" ]
let cultureNames = [ "en-US"; "fr-FR" ]
let date = DateTime(2015, 8, 18, 13, 31, 17)
for cultureName in cultureNames do
    let culture = CultureInfo cultureName
    CultureInfo.CurrentCulture <- culture

    printfn $"{culture.NativeName}"
    for format in formats do
        printfn $"   {format}: {date.ToString format}"
    printfn ""

// The example displays the following output:
//       English (United States)
//          G: 8/18/2015 1:31:17 PM
//          MM/yyyy: 08/2015
//          MM\/dd\/yyyy HH:mm: 08/18/2015 13:31
//          yyyyMMdd: 20150818
//
//       français (France)
//          G: 18/08/2015 13:31:17
//          MM/yyyy: 08/2015
//          MM\/dd\/yyyy HH:mm: 08/18/2015 13:31
//          yyyyMMdd: 20150818
// </Snippet5>