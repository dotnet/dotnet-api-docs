module tryparseexactexample2

// <Snippet2>
open System
open System.Globalization

do
    // Parse hour:minute value with custom format specifier.
    let intervalString = "17:14"
    let format = "h\\:mm"
    let culture = CultureInfo.CurrentCulture
    match TimeSpan.TryParseExact(intervalString, format, culture, TimeSpanStyles.AssumeNegative) with
    | true, interval ->
        printfn $"'{intervalString}' ({format}) --> {interval}"
    | _ ->   
        printfn $"Unable to parse '{intervalString}' using format {format}" 
    
    // Parse hour:minute:second value with "g" specifier.
    let intervalString = "17:14:48"
    let format = "g"
    let culture = CultureInfo.InvariantCulture
    match TimeSpan.TryParseExact(intervalString, format, culture, TimeSpanStyles.AssumeNegative) with
    | true, interval ->
        printfn $"'{intervalString}' ({format}) --> {interval}"
    | _ ->
        printfn $"Unable to parse '{intervalString}' using format {format}" 
    
    // Parse hours:minute.second value with custom format specifier.     
    let intervalString = "17:14:48.153"
    let format = @"h\:mm\:ss\.fff"
    let culture = null
    match TimeSpan.TryParseExact(intervalString, format, culture, TimeSpanStyles.AssumeNegative) with
    | true, interval ->
        printfn $"'{intervalString}' ({format}) --> {interval}"
    | _ ->
        printfn $"Unable to parse '{intervalString}' using format {format}"    

    // Parse days:hours:minute.second value with "G" specifier 
    // and current (en-US) culture.     
    let intervalString = "3:17:14:48.153"
    let format = "G"
    let culture = CultureInfo.CurrentCulture
    match TimeSpan.TryParseExact(intervalString, format, culture, TimeSpanStyles.AssumeNegative) with
    | true, interval ->
        printfn $"'{intervalString}' ({format}) --> {interval}"
    | _ ->   
        printfn $"Unable to parse '{intervalString}' using format {format}"    
        
    // Parse days:hours:minute.second value with a custom format specifier.     
    let intervalString = "3:17:14:48.153"
    let format = @"d\:hh\:mm\:ss\.fff"
    let culture = null
    match TimeSpan.TryParseExact(intervalString, format, culture, TimeSpanStyles.AssumeNegative) with
    | true, interval ->
        printfn $"'{intervalString}' ({format}) --> {interval}"
    | _ ->   
        printfn $"Unable to parse '{intervalString}' using format {format}" 
    
    // Parse days:hours:minute.second value with "G" specifier 
    // and fr-FR culture.     
    let intervalString = "3:17:14:48,153"
    let format = "G"
    let culture = new CultureInfo("fr-FR")
    match TimeSpan.TryParseExact(intervalString, format, culture, TimeSpanStyles.AssumeNegative) with
    | true, interval ->
        printfn $"'{intervalString}' ({format}) --> {interval}"
    | _ ->   
        printfn $"Unable to parse '{intervalString}' using format {format}" 

    // Parse a single number using the "c" standard format string. 
    let intervalString = "12"
    let format = "c"
    match TimeSpan.TryParseExact(intervalString, format, null, TimeSpanStyles.AssumeNegative) with
    | true, interval ->
        printfn $"'{intervalString}' ({format}) --> {interval}"
    | _ ->   
        printfn $"Unable to parse '{intervalString}' using format {format}" 
    
    // Parse a single number using the "%h" custom format string. 
    let format = "%h"
    match TimeSpan.TryParseExact(intervalString, format, null, TimeSpanStyles.AssumeNegative) with
    | true, interval ->
        printfn $"'{intervalString}' ({format}) --> {interval}"
    | _ ->   
        printfn $"Unable to parse '{intervalString}' using format {format}" 
    
    // Parse a single number using the "%s" custom format string. 
    let format = "%s"
    match TimeSpan.TryParseExact(intervalString, format, null, TimeSpanStyles.AssumeNegative) with
    | true, interval ->
        printfn $"'{intervalString}' ({format}) --> {interval}"
    | _ ->   
        printfn $"Unable to parse '{intervalString}' using format {format}" 
// The example displays the following output:
//    '17:14' (h\:mm) --> -17:14:00
//    '17:14:48' (g) --> 17:14:48
//    '17:14:48.153' (h\:mm\:ss\.fff) --> -17:14:48.1530000
//    '3:17:14:48.153' (G) --> 3.17:14:48.1530000
//    '3:17:14:48.153' (d\:hh\:mm\:ss\.fff) --> -3.17:14:48.1530000
//    '3:17:14:48,153' (G) --> 3.17:14:48.1530000
//    '12' (c) --> 12.00:00:00
//    '12' (%h) --> -12:00:00
//    '12' (%s) --> -00:00:12
// </Snippet2>