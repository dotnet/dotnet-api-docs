module Example

// <Snippet1>
open System
open System.Globalization

let string1 = "brother"
let string2 = "Brother"

// Cultural (linguistic) comparison.
let result = String.Compare(string1, string2, CultureInfo "en-US", CompareOptions.None)
let relation =
    if result > 0 then "comes after"
    elif result = 0 then "is the same as"
    else "comes before"

printfn $"'{string1}' {relation} '{string2}'."

// Cultural (linguistic) case-insensitive comparison.
let result2 = String.Compare(string1, string2, CultureInfo "en-US", CompareOptions.IgnoreCase)
let relation2 =
    if result2 > 0 then "comes after"
    elif result2 = 0 then "is the same as"
    else "comes before"

printfn $"'{string1}' {relation2} '{string2}'."

// Culture-insensitive ordinal comparison.
let result3 = String.CompareOrdinal(string1, string2)
let relation3 =
    if result2 > 0 then "comes after"
    elif result2 = 0 then "is the same as"
    else "comes before"

printfn $"'{string1}' {relation} '{string2}'."

// The example produces the following output:
//    'brother' comes before 'Brother'.   
//    'brother' is the same as 'Brother'.
//    'brother' comes after 'Brother'.
// </Snippet1>