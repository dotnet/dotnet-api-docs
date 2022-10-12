//<snippet1>
// This example demonstrates members of the 
// System.StringComparer class.

open System
open System.Globalization
open System.Threading

let display (lst: ResizeArray<string>) title =
    printfn $"%s{title}"
    for s in lst do
        let c = s[0]
        let codePoint = Convert.ToInt32 c
        printfn $"0x{codePoint:x}"
    printfn ""

// Create a list of string.
let list = ResizeArray()

// Get the tr-TR (Turkish-Turkey) culture.
let turkish = CultureInfo "tr-TR"

// Get the culture that is associated with the current thread.
let thisCulture = Thread.CurrentThread.CurrentCulture

// Get the standard StringComparers.
let invCmp =   StringComparer.InvariantCulture
let invICCmp = StringComparer.InvariantCultureIgnoreCase
let currCmp = StringComparer.CurrentCulture
let currICCmp = StringComparer.CurrentCultureIgnoreCase
let ordCmp = StringComparer.Ordinal
let ordICCmp = StringComparer.OrdinalIgnoreCase

// Create a StringComparer that uses the Turkish culture and ignores case.
let turkICComp = StringComparer.Create(turkish, true)

// Define three strings consisting of different versions of the letter I.
// LATIN CAPITAL LETTER I (U+0049)
let capitalLetterI = "I"  

// LATIN SMALL LETTER I (U+0069)
let smallLetterI   = "i"

// LATIN SMALL LETTER DOTLESS I (U+0131)
let smallLetterDotlessI = "\u0131"

// Add the three strings to the list.
list.Add capitalLetterI
list.Add smallLetterI
list.Add smallLetterDotlessI

// Display the original list order.
display list "The original order of the list entries..."

// Sort the list using the invariant culture.
list.Sort invCmp
display list "Invariant culture..."
list.Sort invICCmp
display list "Invariant culture, ignore case..."

// Sort the list using the current culture.
printfn $"The current culture is \"{thisCulture.Name}\"."
list.Sort currCmp
display list "Current culture..."
list.Sort currICCmp
display list "Current culture, ignore case..."

// Sort the list using the ordinal value of the character code points.
list.Sort ordCmp
display list "Ordinal..."
list.Sort ordICCmp
display list "Ordinal, ignore case..."

// Sort the list using the Turkish culture, which treats LATIN SMALL LETTER 
// DOTLESS I differently than LATIN SMALL LETTER I.
list.Sort turkICComp
display list "Turkish culture, ignore case..."


(*
This code example produces the following results:

The original order of the list entries...
0x49
0x69
0x131

Invariant culture...
0x69
0x49
0x131

Invariant culture, ignore case...
0x49
0x69
0x131

The current culture is "en-US".
Current culture...
0x69
0x49
0x131

Current culture, ignore case...
0x49
0x69
0x131

Ordinal...
0x49
0x69
0x131

Ordinal, ignore case...
0x69
0x49
0x131

Turkish culture, ignore case...
0x131
0x49
0x69

*)
//</snippet1>