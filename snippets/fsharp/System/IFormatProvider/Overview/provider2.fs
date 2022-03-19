module provider2

// <Snippet3>
open System
open System.Globalization

let dateValue = DateTime(2009, 6, 1, 16, 37, 0)
let cultures = 
    [ CultureInfo "en-US"
      CultureInfo "fr-FR"
      CultureInfo "it-IT"
      CultureInfo "de-DE" ]

for culture in cultures do
    printfn $"{culture.Name}: {dateValue.ToString culture}"
// The example displays the following output:
//       en-US: 6/1/2009 4:37:00 PM
//       fr-FR: 01/06/2009 16:37:00
//       it-IT: 01/06/2009 16.37.00
//       de-DE: 01.06.2009 16:37:00
// </Snippet3>