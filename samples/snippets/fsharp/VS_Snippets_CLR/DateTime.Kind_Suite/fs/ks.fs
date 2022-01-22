//<snippet1>
// This code example demonstrates the DateTime Kind, Now, and
// UtcNow properties, and the SpecifyKind(), ToLocalTime(),
// and ToUniversalTime() methods.

open System

// Display the value and Kind property of a DateTime structure, the
// DateTime structure converted to local time, and the DateTime
// structure converted to universal time.

let datePatt = @"M/d/yyyy hh:mm:ss tt"

let display title (inputDt: DateTime) =
    // Display the original DateTime.

    let dispDt = inputDt
    let dtString = dispDt.ToString datePatt
    printfn $"%s{title} {dtString}, Kind = {dispDt.Kind}"

    // Convert inputDt to local time and display the result.
    // If inputDt.Kind is DateTimeKind.Utc, the conversion is performed.
    // If inputDt.Kind is DateTimeKind.Local, the conversion is not performed.
    // If inputDt.Kind is DateTimeKind.Unspecified, the conversion is
    // performed as if inputDt was universal time.

    let dispDt = inputDt.ToLocalTime()
    let dtString = dispDt.ToString datePatt
    printfn $"  ToLocalTime:     {dtString}, Kind = {dispDt.Kind}"

    // Convert inputDt to universal time and display the result.
    // If inputDt.Kind is DateTimeKind.Utc, the conversion is not performed.
    // If inputDt.Kind is DateTimeKind.Local, the conversion is performed.
    // If inputDt.Kind is DateTimeKind.Unspecified, the conversion is
    // performed as if inputDt was local time.

    let dispDt = inputDt.ToUniversalTime()
    let dtString = dispDt.ToString datePatt
    printfn $"  ToUniversalTime: {dtString}, Kind = {dispDt.Kind}\n" 

    // Display the value and Kind property for DateTime.Now and DateTime.UtcNow.

let displayNow title (inputDt: DateTime) =
    let dtString = inputDt.ToString datePatt
    printfn $"%s{title} {dtString}, Kind = {inputDt.Kind}"

[<EntryPoint>]
let main _ =

    // Get the date and time for the current moment, adjusted
    // to the local time zone.

    let saveNow = DateTime.Now

    // Get the date and time for the current moment expressed
    // as coordinated universal time (UTC).

    let saveUtcNow = DateTime.UtcNow

    // Display the value and Kind property of the current moment
    // expressed as UTC and local time.

    displayNow "UtcNow: .........." saveUtcNow
    displayNow "Now: ............." saveNow
    printfn ""

    // Change the Kind property of the current moment to
    // DateTimeKind.Utc and display the result.

    let myDt = DateTime.SpecifyKind(saveNow, DateTimeKind.Utc)
    display "Utc: ............." myDt

    // Change the Kind property of the current moment to
    // DateTimeKind.Local and display the result.

    let myDt = DateTime.SpecifyKind(saveNow, DateTimeKind.Local)
    display "Local: ..........." myDt

    // Change the Kind property of the current moment to
    // DateTimeKind.Unspecified and display the result.

    let myDt = DateTime.SpecifyKind(saveNow, DateTimeKind.Unspecified)
    display "Unspecified: ....." myDt

    0


// This code example produces the following results:
//
// UtcNow: .......... 5/6/2005 09:34:42 PM, Kind = Utc
// Now: ............. 5/6/2005 02:34:42 PM, Kind = Local
//
// Utc: ............. 5/6/2005 02:34:42 PM, Kind = Utc
//   ToLocalTime:     5/6/2005 07:34:42 AM, Kind = Local
//   ToUniversalTime: 5/6/2005 02:34:42 PM, Kind = Utc
//
// Local: ........... 5/6/2005 02:34:42 PM, Kind = Local
//   ToLocalTime:     5/6/2005 02:34:42 PM, Kind = Local
//   ToUniversalTime: 5/6/2005 09:34:42 PM, Kind = Utc
//
// Unspecified: ..... 5/6/2005 02:34:42 PM, Kind = Unspecified
//   ToLocalTime:     5/6/2005 07:34:42 AM, Kind = Local
//   ToUniversalTime: 5/6/2005 09:34:42 PM, Kind = Utc
//</snippet1>