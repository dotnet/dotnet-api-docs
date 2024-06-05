module Example2

// <Snippet2>
open System
open System.Globalization

let cultureNames = [| "en-US"; "fr-FR"; "de-DE"; "es-ES" |]

let dateToDisplay = DateTime(2009, 9, 1, 18, 32, 0)
let value = 9164.32

printfn "Culture     Date                                Value\n"
for cultureName in cultureNames do
    let culture = CultureInfo cultureName
    String.Format(culture, "{0,-11} {1,-35:D} {2:N}", culture.Name, dateToDisplay, value)
    |> printfn "%s"
// The example displays the following output:
//    Culture     Date                                Value
//    
//    en-US       Tuesday, September 01, 2009         9,164.32
//    fr-FR       mardi 1 septembre 2009              9 164,32
//    de-DE       Dienstag, 1. September 2009         9.164,32
//    es-ES       martes, 01 de septiembre de 2009    9.164,32
// </Snippet2>