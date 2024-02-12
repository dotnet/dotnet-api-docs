module swci.fs
//<snippet1>
// This code example demonstrates the
// System.String.StartsWith(String, ..., CultureInfo) method.

open System
open System.Globalization
 
[<EntryPoint>]
let main _ =
    let msg1 = "Search for the target string \"{0}\" in the string \"{1}\".\n"
    let msg2 = "Using the {0} - \"{1}\" culture:"
    let msg3 = "  The string to search ends with the target string: {0}"

    // Define a target string to search for.
    // U+00c5 = LATIN CAPITAL LETTER A WITH RING ABOVE
    let capitalARing = "\u00c5"

    // Define a string to search.
    // The result of combining the characters LATIN SMALL LETTER A and COMBINING
    // RING ABOVE (U+0061, U+030a) is linguistically equivalent to the character
    // LATIN SMALL LETTER A WITH RING ABOVE (U+00e5).
    let aRingXYZ = "\u0061\u030a" + "xyz"

    // Clear the screen and display an introduction.
    Console.Clear()

    // Display the string to search for and the string to search.
    Console.WriteLine(msg1, capitalARing, aRingXYZ)

    // Search using English-United States culture.
    let ci = CultureInfo "en-US"
    Console.WriteLine(msg2, ci.DisplayName, ci.Name)

    printfn "Case sensitive:"
    let result = aRingXYZ.StartsWith(capitalARing, false, ci)
    Console.WriteLine(msg3, result)

    printfn "Case insensitive:"
    let result = aRingXYZ.StartsWith(capitalARing, true, ci)
    Console.WriteLine(msg3, result)
    printfn ""

    // Search using Swedish-Sweden culture.
    let ci = CultureInfo "sv-SE"
    Console.WriteLine(msg2, ci.DisplayName, ci.Name)

    printfn "Case sensitive:"
    let result = aRingXYZ.StartsWith(capitalARing, false, ci)
    Console.WriteLine(msg3, result)

    printfn "Case insensitive:"
    let result = aRingXYZ.StartsWith(capitalARing, true, ci)
    Console.WriteLine(msg3, result)
    0
(*
Note: This code example was executed on a console whose user interface
culture is "en-US" (English-United States).

Search for the target string "Å" in the string "a°xyz".

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
