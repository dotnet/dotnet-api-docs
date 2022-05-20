module tryparse2

// <Snippet2>
open System
open System.Globalization

let values = 
    [| "6"; "6:12"; "6:12:14"; "6:12:14:45" 
       "6.12:14:45"; "6:12:14:45.3448" 
       "6:12:14:45,3448"; "6:34:14:45" |]
let cultures = 
    [| CultureInfo "en-US" 
       CultureInfo "ru-RU"
       CultureInfo.InvariantCulture |] 

let mutable header = String.Format("{0,-17}", "String")
for culture in cultures do
    header <- 
        if culture.Equals CultureInfo.InvariantCulture then
            String.Format("{0,20}", "Invariant")
        else
            String.Format("{0,20}", culture.Name)

printfn $"{header}\n"

for value in values do
    printf $"{value,-17}"
    for culture in cultures do
        match TimeSpan.TryParse(value, culture) with
        | true, interval -> 
            printfn $"{interval,20:c}"
        | _ ->
            printfn "%20s" "Unable to Parse"
// The example displays the following output:
//    String                          en-US               ru-RU           Invariant
//    
//    6                          6.00:00:00          6.00:00:00          6.00:00:00
//    6:12                         06:12:00            06:12:00            06:12:00
//    6:12:14                      06:12:14            06:12:14            06:12:14
//    6:12:14:45                 6.12:14:45          6.12:14:45          6.12:14:45
//    6.12:14:45                 6.12:14:45          6.12:14:45          6.12:14:45
//    6:12:14:45.3448    6.12:14:45.3448000     Unable to Parse  6.12:14:45.3448000
//    6:12:14:45,3448       Unable to Parse  6.12:14:45.3448000     Unable to Parse
//    6:34:14:45            Unable to Parse     Unable to Parse     Unable to Parse
// </Snippet2>