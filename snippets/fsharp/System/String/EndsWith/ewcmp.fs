module ewcmp

//<snippet1>
// This example demonstrates the 
// System.String.EndsWith(String, StringComparison) method.

open System
open System.Threading

let test (x: string) y (comparison: StringComparison) =
    let result = 
        if x.EndsWith(y, comparison) then
            "ends"
        else 
            "does not end"
    printfn $"\"{x}\" {result} with \"{y}\"."

let scValues = 
  [|
    StringComparison.CurrentCulture
    StringComparison.CurrentCultureIgnoreCase
    StringComparison.InvariantCulture
    StringComparison.InvariantCultureIgnoreCase
    StringComparison.Ordinal
    StringComparison.OrdinalIgnoreCase
  |]

printfn "Determine whether a string ends with another string, using\n  different values of StringComparison."

// Display the current culture because the culture-specific comparisons
// can produce different results with different cultures.
printfn $"The current culture is {Thread.CurrentThread.CurrentCulture.Name}.\n"

// Determine whether three versions of the letter I are equal to each other. 
for sc in scValues do
    printfn $"StringComparison.{sc}:"
    test "abcXYZ" "XYZ" sc
    test "abcXYZ" "xyz" sc
    printfn ""

(*
This code example produces the following results:

Determine whether a string ends with another string, using
  different values of StringComparison.
The current culture is en-US.

StringComparison.CurrentCulture:
"abcXYZ" ends with "XYZ".
"abcXYZ" does not end with "xyz".

StringComparison.CurrentCultureIgnoreCase:
"abcXYZ" ends with "XYZ".
"abcXYZ" ends with "xyz".

StringComparison.InvariantCulture:
"abcXYZ" ends with "XYZ".
"abcXYZ" does not end with "xyz".

StringComparison.InvariantCultureIgnoreCase:
"abcXYZ" ends with "XYZ".
"abcXYZ" ends with "xyz".

StringComparison.Ordinal:
"abcXYZ" ends with "XYZ".
"abcXYZ" does not end with "xyz".

StringComparison.OrdinalIgnoreCase:
"abcXYZ" ends with "XYZ".
"abcXYZ" ends with "xyz".

*)
//</snippet1>