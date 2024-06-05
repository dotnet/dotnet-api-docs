module parse1

// <Snippet1>
open System
open System.Globalization
open System.Threading

let values = 
    [| "6"; "6:12"; "6:12:14"; "6:12:14:45" 
       "6.12:14:45"; "6:12:14:45.3448" 
       "6:12:14:45,3448"; "6:34:14:45" |]
let cultureNames = [| "hr-HR"; "en-US" |]

// Change the current culture.
for cultureName in cultureNames do
    Thread.CurrentThread.CurrentCulture <- CultureInfo cultureName
    printfn $"Current Culture: {Thread.CurrentThread.CurrentCulture.Name}" 
    for value in values do
        try 
            let ts = TimeSpan.Parse value
            printfn $"{value} --> {ts:c}"
        with 
        | :? FormatException ->
            printfn $"{value}: Bad Format"
        | :? OverflowException ->
            printfn $"{value}: Overflow"
    printfn ""                                
// The example displays the following output:
//    Current Culture: hr-HR
//    6 --> 6.00:00:00
//    6:12 --> 06:12:00
//    6:12:14 --> 06:12:14
//    6:12:14:45 --> 6.12:14:45
//    6.12:14:45 --> 6.12:14:45
//    6:12:14:45.3448: Bad Format
//    6:12:14:45,3448 --> 6.12:14:45.3448000
//    6:34:14:45: Overflow
//    
//    Current Culture: en-US
//    6 --> 6.00:00:00
//    6:12 --> 06:12:00
//    6:12:14 --> 06:12:14
//    6:12:14:45 --> 6.12:14:45
//    6.12:14:45 --> 6.12:14:45
//    6:12:14:45.3448 --> 6.12:14:45.3448000
//    6:12:14:45,3448: Bad Format
//    6:34:14:45: Overflow
// </Snippet1>