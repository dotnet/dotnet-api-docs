// <Snippet1>
open System
open System.Globalization

// Initialize a DateTime object.
printfn "Initialize the DateTime object to May 16, 2001 3:02:15 AM.\n"
let dateAndTime = DateTime(2001, 5, 16, 3, 2, 15)

// Display the name of the current culture.
printfn $"Current culture: \"{CultureInfo.CurrentCulture.Name}\"\n"
let dtfi = CultureInfo.CurrentCulture.DateTimeFormat

// Display the long date pattern and string.
printfn $"Long date pattern: \"{dtfi.LongDatePattern}\""
printfn $"Long date string:  \"{dateAndTime.ToLongDateString()}\"\n"

// Display the long time pattern and string.
printfn $"Long time pattern: \"{dtfi.LongTimePattern}\""
printfn $"Long time string:  \"{dateAndTime.ToLongTimeString()}\"\n"

// Display the short date pattern and string.
printfn $"Short date pattern: \"{dtfi.ShortDatePattern}\""
printfn $"Short date string:  \"{dateAndTime.ToShortDateString()}\"\n"

// Display the short time pattern and string.
printfn $"Short time pattern: \"{dtfi.ShortTimePattern}\""
printfn $"Short time string:  \"{dateAndTime.ToShortTimeString()}\"\n"

// The example displays output similar to the following:
//        Current culture: "en-US"
//
//        Long date pattern: "dddd, MMMM d, yyyy"
//        Long date string:  "Wednesday, May 16, 2001"
//
//        Long time pattern: "h:mm:ss tt"
//        Long time string:  "3:02:15 AM"
//
//        Short date pattern: "M/d/yyyy"
//        Short date string:  "5/16/2001"
//
//        Short time pattern: "h:mm tt"
//        Short time string:  "3:02 AM"
//</snippet1>