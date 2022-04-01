module ewci

//<snippet1>
// This code example demonstrates the 
// System.String.EndsWith(String, ..., CultureInfo) method.
open System.Globalization

[<EntryPoint>]
let main _ =
    // Define a target string to search for.
    // U+00c5 = LATIN CAPITAL LETTER A WITH RING ABOVE
    let capitalARing = "\u00c5"

    // Define a string to search. 
    // The result of combining the characters LATIN SMALL LETTER A and COMBINING 
    // RING ABOVE (U+0061, U+030a) is linguistically equivalent to the character 
    // LATIN SMALL LETTER A WITH RING ABOVE (U+00e5).
    let xyzARing = "xyz" + "\u0061\u030a"

    // Display the string to search for and the string to search.
    printfn $"Search for the target string \"{capitalARing}\" in the string \"{xyzARing}\".\n"

    // Search using English-United States culture.
    let ci = CultureInfo "en-US"
    printfn $"Using the {ci.DisplayName} - \"{ci.Name}\" culture:"

    printfn "Case sensitive:"
    let result = xyzARing.EndsWith(capitalARing, false, ci)
    printfn $"  The string to search ends with the target string: {result}"

    printfn "Case insensitive:"
    let result = xyzARing.EndsWith(capitalARing, true, ci)
    printfn $"  The string to search ends with the target string: {result}\n"

    // Search using Swedish-Sweden culture.
    let ci = CultureInfo "sv-SE"
    printfn $"Using the {ci.DisplayName} - \"{ci.Name}\" culture:"

    printfn "Case sensitive:"
    let result = xyzARing.EndsWith(capitalARing, false, ci)
    printfn $"  The string to search ends with the target string: {result}"

    printfn "Case insensitive:"
    let result = xyzARing.EndsWith(capitalARing, true, ci)
    printfn $"  The string to search ends with the target string: {result}"
    0
(*
This code example produces the following results (for en-us culture):

Search for the target string "Å" in the string "xyza°".

Using the English (United States) - "en-US" culture:
Case sensitive:
  The string to search ends with the target string: False
Case insensitive:
  The string to search ends with the target string: True

Using the Swedish (Sweden) - "sv-SE" culture:
Case sensitive:
  The string to search ends with the target string: False
Case insensitive:
  The string to search ends with the target string: False
*)
//</snippet1>