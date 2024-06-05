module parseexactexample1

// <Snippet1>
open System
open System.Globalization

do
    // Parse hour:minute value with "g" specifier current culture.
    let intervalString = "17:14"
    let format = "g"
    let culture = CultureInfo.CurrentCulture
    try
        let interval = TimeSpan.ParseExact(intervalString, format, culture)
        printfn $"'{intervalString}' --> {interval}"
    with 
    | :? FormatException ->
        printfn $"'{intervalString}': Bad Format for '{format}'"
    | :? OverflowException ->
        printfn $"'{intervalString}': Overflow"
    
    // Parse hour:minute:second value with "G" specifier.
    let intervalString = "17:14:48"
    let format = "G"
    let culture = CultureInfo.InvariantCulture
    try
        let interval = TimeSpan.ParseExact(intervalString, format, culture)
        printfn $"'{intervalString}' --> {interval}"
    with
    | :? FormatException ->
        printfn $"'{intervalString}': Bad Format for '{format}'"
    | :? OverflowException ->
        printfn $"'{intervalString}': Overflow"
    
    // Parse hours:minute.second value with "G" specifier 
    // and current (en-US) culture.     
    let intervalString = "17:14:48.153"
    let format = "G"
    let culture = CultureInfo.CurrentCulture
    try
        let interval = TimeSpan.ParseExact(intervalString, format, culture)
        printfn $"'{intervalString}' --> {interval}"
    with 
    | :? FormatException ->
        printfn $"'{intervalString}': Bad Format for '{format}'"
    | :? OverflowException ->
        printfn $"'{intervalString}': Overflow"

    // Parse days:hours:minute.second value with "G" specifier 
    // and current (en-US) culture.     
    let intervalString = "3:17:14:48.153"
    let format = "G"
    let culture = CultureInfo.CurrentCulture
    try
        let interval = TimeSpan.ParseExact(intervalString, format, culture)
        printfn $"'{intervalString}' --> {interval}"
    with 
    | :? FormatException ->
        printfn $"'{intervalString}': Bad Format for '{format}'"
    | :? OverflowException ->
        printfn $"'{intervalString}': Overflow"
        
    // Parse days:hours:minute.second value with "G" specifier 
    // and fr-FR culture.     
    let intervalString = "3:17:14:48.153"
    let format = "G"
    let culture = CultureInfo "fr-FR"
    try
        let interval = TimeSpan.ParseExact(intervalString, format, culture)
        printfn $"'{intervalString}' --> {interval}"
    with 
    | :? FormatException ->
        printfn $"'{intervalString}': Bad Format for '{format}'"
    | :? OverflowException ->
        printfn $"'{intervalString}': Overflow"
    
    // Parse days:hours:minute.second value with "G" specifier 
    // and fr-FR culture.     
    let intervalString = "3:17:14:48,153"
    let format = "G"
    try
        let interval = TimeSpan.ParseExact(intervalString, format, culture)
        printfn $"'{intervalString}' --> {interval}"
    with 
    | :? FormatException ->
        printfn $"'{intervalString}': Bad Format for '{format}'"
    | :? OverflowException ->
        printfn $"'{intervalString}': Overflow"

    // Parse a single number using the "c" standard format string. 
    let intervalString = "12"
    let format = "c"
    try
        let interval = TimeSpan.ParseExact(intervalString, format, null)
        printfn $"'{intervalString}' --> {interval}"
    with
    | :? FormatException ->
        printfn $"'{intervalString}': Bad Format for '{format}'"
    | :? OverflowException ->
        printfn $"'{intervalString}': Overflow"
    
    // Parse a single number using the "%h" custom format string. 
    let format = "%h"
    try
        let interval = TimeSpan.ParseExact(intervalString, format, null)
        printfn $"'{intervalString}' --> {interval}"
    with 
    | :? FormatException ->
        printfn $"'{intervalString}': Bad Format for '{format}'"
    | :? OverflowException ->
        printfn $"'{intervalString}': Overflow"
    
    // Parse a single number using the "%s" custom format string. 
    let format = "%s"
    try
        let interval = TimeSpan.ParseExact(intervalString, format, null)
        printfn $"'{intervalString}' --> {interval}"
    with 
    | :? FormatException ->
        printfn $"'{intervalString}': Bad Format for '{format}'"
    | :? OverflowException ->
        printfn $"'{intervalString}': Overflow"
// The example displays the following output:
//       '17:14' --> 17:14:00
//       '17:14:48': Bad Format for 'G'
//       '17:14:48.153': Bad Format for 'G'
//       '3:17:14:48.153' --> 3.17:14:48.1530000
//       '3:17:14:48.153': Bad Format for 'G'
//       '3:17:14:48,153' --> 3.17:14:48.1530000
//       '12' --> 12.00:00:00
//       '12' --> 12:00:00
//       '12' --> 00:00:12
// </Snippet1>