module ToString1

// <Snippet1>
open System
open System.Globalization

let currentCulture = CultureInfo.CurrentCulture
let exampleDate = DateTime(2021, 5, 1, 18, 32, 6)

// Change the current culture to en-US and display the date.
CultureInfo.CurrentCulture <- CultureInfo.GetCultureInfo "en-US"
printfn $"{exampleDate.ToString()}"

// Change the current culture to fr-FR and display the date.
CultureInfo.CurrentCulture <- CultureInfo.GetCultureInfo "fr-FR"
printfn $"{exampleDate.ToString()}"

// Change the current culture to ja-JP and display the date.
CultureInfo.CurrentCulture <- CultureInfo.GetCultureInfo "ja-JP"
printfn $"{exampleDate.ToString()}"

// Restore the original culture
CultureInfo.CurrentCulture <- currentCulture

// The example displays the following output to the console:
//       5/1/2021 6:32:06 PM
//       01/05/2021 18:32:06
//       2021/05/01 18:32:06
// </Snippet1>