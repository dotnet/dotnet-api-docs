module now2

// <Snippet3>
open System
open System.Globalization

let localDate = DateTime.Now
let utcDate = DateTime.UtcNow
let cultureNames = 
    [ "en-US"; "en-GB"; "fr-FR"; "de-DE"; "ru-RU" ] 

for cultureName in cultureNames do
    let culture = CultureInfo cultureName
    printfn $"{culture.NativeName}:"
    printfn $"   Local date and time: {localDate.ToString culture}, {localDate.Kind:G}"
    printfn $"   UTC date and time: {utcDate.ToString culture}, {utcDate.Kind:G}\n"

// The example displays the following output:
//       English (United States):
//          Local date and time: 6/19/2015 10:35:50 AM, Local
//          UTC date and time: 6/19/2015 5:35:50 PM, Utc
//
//       English (United Kingdom):
//          Local date and time: 19/06/2015 10:35:50, Local
//          UTC date and time: 19/06/2015 17:35:50, Utc
//
//       français (France):
//          Local date and time: 19/06/2015 10:35:50, Local
//          UTC date and time: 19/06/2015 17:35:50, Utc
//
//       Deutsch (Deutschland):
//          Local date and time: 19.06.2015 10:35:50, Local
//          UTC date and time: 19.06.2015 17:35:50, Utc
//
//       русский (Россия):
//          Local date and time: 19.06.2015 10:35:50, Local
//          UTC date and time: 19.06.2015 17:35:50, Utc
// </Snippet3>