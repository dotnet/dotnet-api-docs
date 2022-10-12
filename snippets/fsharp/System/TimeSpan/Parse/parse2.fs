module parse2

// <Snippet2>
open System
open System.Globalization
open System.Text.RegularExpressions

let values = 
    [| "6"; "6:12"; "6:12:14"; "6:12:14:45" 
       "6.12:14:45"; "6:12:14:45.3448"
       "6:12:14:45,3448"; "6:34:14:45" |]
let cultures = 
    [| CultureInfo "en-US" 
       CultureInfo "ru-RU"
       CultureInfo.InvariantCulture |]

let mutable header = $"""{"String",-17}"""
for culture in cultures do
    header <- header +
        if culture.Equals CultureInfo.InvariantCulture then 
            $"""{"Invariant",20}"""
        else
            $"{culture.Name,20}"
printfn $"{header}\m"

for value in values do
    printf $"{value,-17}"
    for culture in cultures do
        try
            let ts = TimeSpan.Parse(value, culture)
            printf $"{ts,20:c}"
        with
        | :? FormatException ->
            printf $"""{"Bad Format",20}"""
        | :? OverflowException ->
            printf $"""{"Overflow",20}"""
    printfn ""                      
// The example displays the following output:
//    String                          en-US               ru-RU           Invariant
//    
//    6                          6.00:00:00          6.00:00:00          6.00:00:00
//    6:12                         06:12:00            06:12:00            06:12:00
//    6:12:14                      06:12:14            06:12:14            06:12:14
//    6:12:14:45                 6.12:14:45          6.12:14:45          6.12:14:45
//    6.12:14:45                 6.12:14:45          6.12:14:45          6.12:14:45
//    6:12:14:45.3448    6.12:14:45.3448000          Bad Format  6.12:14:45.3448000
//    6:12:14:45,3448            Bad Format  6.12:14:45.3448000          Bad Format
//    6:34:14:45                   Overflow            Overflow            Overflow
// </Snippet2>