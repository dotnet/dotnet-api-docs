module string.comp4

open System
open System.Globalization

//<snippet1>
let symbol r =
    if r < 0 then "<"
    elif r > 0 then ">"
    else "="

let str1 = "change"
let str2 = "dollar"

let relation1 = 
    String.Compare(str1, str2, false, CultureInfo "en-US")
    |> symbol
printfn $"For en-US: {str1} {relation1} {str2}"

let relation2 = 
    String.Compare(str1, str2, false, CultureInfo "cs-CZ")
    |> symbol
printfn $"For cs-CZ: {str1} {relation2} {str2}"

(*
This example produces the following results.
For en-US: change < dollar
For cs-CZ: change > dollar
*)
//</snippet1>