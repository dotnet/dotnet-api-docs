module tryparseexactexample1

// <Snippet1>
open System
open System.Globalization

do
    // Parse hour:minute value with "g" specifier current culture.
    let intervalString = "17:14"
    let format = "g"
    let culture = CultureInfo.CurrentCulture
    match TimeSpan.TryParseExact(intervalString, format, culture) with
    | true, interval ->
        printfn $"'{intervalString}' --> {interval}"
    | _ ->
        printfn $"Unable to parse {intervalString}"
    
    // Parse hour:minute:second value with "G" specifier.
    let intervalString = "17:14:48"
    let format = "G"
    let culture = CultureInfo.InvariantCulture
    match TimeSpan.TryParseExact(intervalString, format, culture) with
    | true, interval ->
        printfn $"'{intervalString}' --> {interval}"
    | _ ->
        printfn $"Unable to parse {intervalString}"
    
    // Parse hours:minute.second value with "G" specifier 
    // and current (en-US) culture.     
    let intervalString = "17:14:48.153"
    let format = "G"
    let culture = CultureInfo.CurrentCulture
    match TimeSpan.TryParseExact(intervalString, format, culture) with
    | true, interval ->
        printfn $"'{intervalString}' --> {interval}"
    | _ ->
        printfn $"Unable to parse {intervalString}"

    // Parse days:hours:minute.second value with "G" specifier 
    // and current (en-US) culture.     
    let intervalString = "3:17:14:48.153"
    let format = "G"
    let culture = CultureInfo.CurrentCulture
    match TimeSpan.TryParseExact(intervalString, format, culture) with
    | true, interval ->
        printfn $"'{intervalString}' --> {interval}"
    | _ ->
        printfn $"Unable to parse {intervalString}"
        
    // Parse days:hours:minute.second value with "G" specifier 
    // and fr-FR culture.     
    let intervalString = "3:17:14:48.153"
    let format = "G"
    let culture = new CultureInfo("fr-FR")
    match TimeSpan.TryParseExact(intervalString, format, culture) with
    | true, interval ->
        printfn $"'{intervalString}' --> {interval}"
    | _ ->
        printfn $"Unable to parse {intervalString}"
    
    // Parse days:hours:minute.second value with "G" specifier 
    // and fr-FR culture.     
    let intervalString = "3:17:14:48,153"
    let format = "G"
    match TimeSpan.TryParseExact(intervalString, format, culture) with
    | true, interval ->
        printfn $"'{intervalString}' --> {interval}"
    | _ ->
        printfn $"Unable to parse {intervalString}"

    // Parse a single number using the "c" standard format string. 
    let intervalString = "12"
    let format = "c"
    match TimeSpan.TryParseExact(intervalString, format, null) with
    | true, interval ->
        printfn $"'{intervalString}' --> {interval}"
    | _ ->
        printfn $"Unable to parse {intervalString}"
    
    // Parse a single number using the "%h" custom format string. 
    let format = "%h"
    match TimeSpan.TryParseExact(intervalString, format, null) with
    | true, interval ->
        printfn $"'{intervalString}' --> {interval}"
    | _ ->
        printfn $"Unable to parse {intervalString}"
    
    // Parse a single number using the "%s" custom format string. 
    let format = "%s"
    match TimeSpan.TryParseExact(intervalString, format, null) with
    | true, interval ->
        printfn $"'{intervalString}' --> {interval}"
    | _ ->
        printfn $"Unable to parse {intervalString}"
// The example displays the following output:
//       '17:14' --> 17:14:00
//       Unable to parse 17:14:48
//       Unable to parse 17:14:48.153
//       '3:17:14:48.153' --> 3.17:14:48.1530000
//       Unable to parse 3:17:14:48.153
//       '3:17:14:48,153' --> 3.17:14:48.1530000
//       '12' --> 12.00:00:00
//       '12' --> 12:00:00
//       '12' --> 00:00:12
// </Snippet1>