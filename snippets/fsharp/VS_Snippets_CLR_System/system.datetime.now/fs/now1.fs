module now1

// <Snippet2>
open System
open System.Globalization

let localDate = DateTime.Now
let cultureNames = 
    [ "en-US"; "en-GB"; "fr-FR"; "de-DE"; "ru-RU" ]

for cultureName in cultureNames do
    let culture = CultureInfo cultureName
    printfn $"{cultureName}: {localDate.ToString culture}"

// The example displays the following output:
//       en-US: 6/19/2015 10:03:06 AM
//       en-GB: 19/06/2015 10:03:06
//       fr-FR: 19/06/2015 10:03:06
//       de-DE: 19.06.2015 10:03:06
//       ru-RU: 19.06.2015 10:03:06
// </Snippet2>