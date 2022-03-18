// <Snippet1>
open System
open System.Threading
open System.Globalization

// Create a list of culture names.
let names = [ "en-US"; "en-GB"; "fr-FR"; "de-DE" ]

// Initialize a DateTime object.
let dateValue = DateTime(2013, 5, 28, 10, 30, 15)

// Iterate the array of culture names.
for name in names do
    // Change the culture of the current thread.
    Thread.CurrentThread.CurrentCulture <- CultureInfo.CreateSpecificCulture name
    // Display the name of the current culture and the date.
    printfn $"Current culture: {CultureInfo.CurrentCulture.Name}"
    printfn $"Date: {dateValue:G}"

    // Display the long time pattern and the long time.
    printfn $"Long time pattern: '{DateTimeFormatInfo.CurrentInfo.LongTimePattern}'"
    printfn $"Long time with format string:     {dateValue:T}"
    printfn $"Long time with ToLongTimeString:  {dateValue.ToLongTimeString()}\n"


// The example displays the following output:
//       Current culture: en-US
//       Date: 5/28/2013 10:30:15 AM
//       Long time pattern: 'h:mm:ss tt'
//       Long time with format string:     10:30:15 AM
//       Long time with ToLongTimeString:  10:30:15 AM
//
//       Current culture: en-GB
//       Date: 28/05/2013 10:30:15
//       Long time pattern: 'HH:mm:ss'
//       Long time with format string:     10:30:15
//       Long time with ToLongTimeString:  10:30:15
//
//       Current culture: fr-FR
//       Date: 28/05/2013 10:30:15
//       Long time pattern: 'HH:mm:ss'
//       Long time with format string:     10:30:15
//       Long time with ToLongTimeString:  10:30:15
//
//       Current culture: de-DE
//       Date: 28.05.2013 10:30:15
//       Long time pattern: 'HH:mm:ss'
//       Long time with format string:     10:30:15
//       Long time with ToLongTimeString:  10:30:15
// </Snippet1>