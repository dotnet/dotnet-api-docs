module cmpcmp

//<snippet1>
// This example demonstrates the 
// System.String.Compare(String, String, StringComparison) method.

open System
open System.Threading

let test x y (comparison: StringComparison) (testI: string[]) (testNames: string[]) =
    let cmpValue = String.Compare(testI[x], testI[y], comparison)
    let result =
        if cmpValue < 0 then
            "less than"
        elif cmpValue > 0 then
            "greater than"
        else
            "equal to"
    printfn $"{testNames[x]} is {result} {testNames[y]}"

let intro = "Compare three versions of the letter I using different values of StringComparison."

// Define an array of strings where each element contains a version of the 
// letter I. (An array of strings is used so you can easily modify this 
// code example to test additional or different combinations of strings.)  

let threeIs = 
  [|// LATIN SMALL LETTER I (U+0069)
    "\u0069"
    // LATIN SMALL LETTER DOTLESS I (U+0131)
    "\u0131"
    // LATIN CAPITAL LETTER I (U+0049)
    "\u0049" |]

let unicodeNames =
    [| "LATIN SMALL LETTER I (U+0069)"
       "LATIN SMALL LETTER DOTLESS I (U+0131)"
       "LATIN CAPITAL LETTER I (U+0049)" |]

let scValues =
    [| StringComparison.CurrentCulture
       StringComparison.CurrentCultureIgnoreCase
       StringComparison.InvariantCulture
       StringComparison.InvariantCultureIgnoreCase
       StringComparison.Ordinal
       StringComparison.OrdinalIgnoreCase |]

Console.Clear()
printfn $"{intro}"

// Display the current culture because the culture-specific comparisons
// can produce different results with different cultures.
printfn $"The current culture is {Thread.CurrentThread.CurrentCulture.Name}.\n"

// Determine the relative sort order of three versions of the letter I. 
for sc in scValues do
    printfn $"StringComparison.{sc}:"

    // LATIN SMALL LETTER I (U+0069) : LATIN SMALL LETTER DOTLESS I (U+0131)
    test 0 1 sc threeIs unicodeNames

    // LATIN SMALL LETTER I (U+0069) : LATIN CAPITAL LETTER I (U+0049)
    test 0 2 sc threeIs unicodeNames

    // LATIN SMALL LETTER DOTLESS I (U+0131) : LATIN CAPITAL LETTER I (U+0049)
    test 1 2 sc threeIs unicodeNames

    printfn ""

(*
This code example produces the following results:

Compare three versions of the letter I using different values of StringComparison.
The current culture is en-US.

StringComparison.CurrentCulture:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is less than LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)

StringComparison.CurrentCultureIgnoreCase:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is equal to LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)

StringComparison.InvariantCulture:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is less than LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)

StringComparison.InvariantCultureIgnoreCase:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is equal to LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)

StringComparison.Ordinal:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is greater than LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)

StringComparison.OrdinalIgnoreCase:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is equal to LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)
*)
//</snippet1>