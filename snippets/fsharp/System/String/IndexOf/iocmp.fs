module iocmp.fs
//<snippet1>
// This code example demonstrates the
// System.String.IndexOf(String, ..., StringComparison) methods.

open System
open System.Threading
open System.Globalization

let intro = "Find the first occurrence of a character using different values of StringComparison."

// Define a string to search for.
// U+00c5 = LATIN CAPITAL LETTER A WITH RING ABOVE
let CapitalAWithRing = "\u00c5"

// Define a string to search.
// The result of combining the characters LATIN SMALL LETTER A and COMBINING
// RING ABOVE (U+0061, U+030a) is linguistically equivalent to the character
// LATIN SMALL LETTER A WITH RING ABOVE (U+00e5).
let cat = "A Cheshire c" + "\u0061\u030a" + "t"

let scValues = 
    [| StringComparison.CurrentCulture
       StringComparison.CurrentCultureIgnoreCase
       StringComparison.InvariantCulture
       StringComparison.InvariantCultureIgnoreCase
       StringComparison.Ordinal
       StringComparison.OrdinalIgnoreCase |]

// Clear the screen and display an introduction.
Console.Clear()
printfn $"{intro}"

// Display the current culture because culture affects the result. For example,
// try this code example with the "sv-SE" (Swedish-Sweden) culture.

Thread.CurrentThread.CurrentCulture <- CultureInfo "en-US"
printfn $"The current culture is \"{Thread.CurrentThread.CurrentCulture.Name}\" - {Thread.CurrentThread.CurrentCulture.DisplayName}."

// Display the string to search for and the string to search.
printfn $"Search for the string \"{CapitalAWithRing}\" in the string \"{cat}\"\n"

// Note that in each of the following searches, we look for
// LATIN CAPITAL LETTER A WITH RING ABOVE in a string that contains
// LATIN SMALL LETTER A WITH RING ABOVE. A result value of -1 indicates
// the string was not found.
// Search using different values of StringComparison. Specify the start
// index and count.

printfn "Part 1: Start index and count are specified."
for sc in scValues do
    let loc = cat.IndexOf(CapitalAWithRing, 0, cat.Length, sc)
    printfn $"Comparison: {sc,-28} Location: {loc,3}"

// Search using different values of StringComparison. Specify the
// start index.
printfn "\nPart 2: Start index is specified."
for sc in scValues do
    let loc = cat.IndexOf(CapitalAWithRing, 0, sc)
    printfn $"Comparison: {sc,-28} Location: {loc,3}"

// Search using different values of StringComparison.
Console.WriteLine("\nPart 3: Neither start index nor count is specified.")
for sc in scValues do
    let loc = cat.IndexOf(CapitalAWithRing, sc)
    Console.WriteLine("Comparison: {0,-28} Location: {1,3}", sc, loc)

(*
Note: This code example was executed on a console whose user interface
culture is "en-US" (English-United States).

This code example produces the following results:

Find the first occurrence of a character using different values of StringComparison.
The current culture is "en-US" - English (United States).
Search for the string "Å" in the string "A Cheshire ca°t"

Part 1: Start index and count are specified.
Comparison: CurrentCulture               Location:  -1
Comparison: CurrentCultureIgnoreCase     Location:  12
Comparison: InvariantCulture             Location:  -1
Comparison: InvariantCultureIgnoreCase   Location:  12
Comparison: Ordinal                      Location:  -1
Comparison: OrdinalIgnoreCase            Location:  -1

Part 2: Start index is specified.
Comparison: CurrentCulture               Location:  -1
Comparison: CurrentCultureIgnoreCase     Location:  12
Comparison: InvariantCulture             Location:  -1
Comparison: InvariantCultureIgnoreCase   Location:  12
Comparison: Ordinal                      Location:  -1
Comparison: OrdinalIgnoreCase            Location:  -1

Part 3: Neither start index nor count is specified.
Comparison: CurrentCulture               Location:  -1
Comparison: CurrentCultureIgnoreCase     Location:  12
Comparison: InvariantCulture             Location:  -1
Comparison: InvariantCultureIgnoreCase   Location:  12
Comparison: Ordinal                      Location:  -1
Comparison: OrdinalIgnoreCase            Location:  -1

*)
//</snippet1>
