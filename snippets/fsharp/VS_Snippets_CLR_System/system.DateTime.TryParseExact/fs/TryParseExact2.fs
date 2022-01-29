module TryParseExact2

// <Snippet2>
open System
open System.Globalization

let formats= 
    [| "M/d/yyyy h:mm:ss tt"; "M/d/yyyy h:mm tt"
       "MM/dd/yyyy hh:mm:ss"; "M/d/yyyy h:mm:ss"
       "M/d/yyyy hh:mm tt"; "M/d/yyyy hh tt"
       "M/d/yyyy h:mm"; "M/d/yyyy h:mm"
       "MM/dd/yyyy hh:mm"; "M/dd/yyyy hh:mm" |]

let dateStrings = 
    [ "5/1/2009 6:32 PM"; "05/01/2009 6:32:05 PM"
      "5/1/2009 6:32:00"; "05/01/2009 06:32"
      "05/01/2009 06:32:00 PM"; "05/01/2009 06:32:00" ]

for dateString in dateStrings do
    match DateTime.TryParseExact(dateString, formats, CultureInfo "en-US", DateTimeStyles.None) with
    | true, dateValue ->
        printfn $"Converted '{dateString}' to {dateValue}."
    | _ ->
        printfn $"Unable to convert '{dateString}' to a date."


// The example displays the following output:
//       Converted '5/1/2009 6:32 PM' to 5/1/2009 6:32:00 PM.
//       Converted '05/01/2009 6:32:05 PM' to 5/1/2009 6:32:05 PM.
//       Converted '5/1/2009 6:32:00' to 5/1/2009 6:32:00 AM.
//       Converted '05/01/2009 06:32' to 5/1/2009 6:32:00 AM.
//       Converted '05/01/2009 06:32:00 PM' to 5/1/2009 6:32:00 PM.
//       Converted '05/01/2009 06:32:00' to 5/1/2009 6:32:00 AM.
// </Snippet2>