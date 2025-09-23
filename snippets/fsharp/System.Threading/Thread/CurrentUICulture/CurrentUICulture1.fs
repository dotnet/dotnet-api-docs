// <Snippet1>
open System.Globalization
open System.Threading

// Change the current culture if the language is not French.
let current = Thread.CurrentThread.CurrentUICulture

if current.TwoLetterISOLanguageName <> "fr" then
    let newCulture = CultureInfo.CreateSpecificCulture "en-US"
    Thread.CurrentThread.CurrentUICulture <- newCulture
    // Make current UI culture consistent with current culture.
    Thread.CurrentThread.CurrentCulture <- newCulture

printfn
    $"The current UI culture is {Thread.CurrentThread.CurrentUICulture.NativeName} [{Thread.CurrentThread.CurrentUICulture.Name}]"

printfn
    $"The current culture is {Thread.CurrentThread.CurrentUICulture.NativeName} [{Thread.CurrentThread.CurrentUICulture.Name}]"

// The example displays the following output:
//     The current UI culture is English (United States) [en-US]
//     The current culture is English (United States) [en-US]
// </Snippet1>
