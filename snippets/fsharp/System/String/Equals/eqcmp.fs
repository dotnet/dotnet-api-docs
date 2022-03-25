module eqcmp

// <Snippet1>
open System
open System.Globalization

// Define a string array with the following three "I" characters:
//      U+0069, U+0131, and U+0049.  
let threeIs = [| "i"; "ı"; "I" |]
// Define Type object representing StringComparison type.
let scType = typeof<StringComparison>  

// Show the current culture (for culture-sensitive string comparisons).
printfn $"The current culture is {CultureInfo.CurrentCulture.Name}.\n"

// Perform comparisons using each StringComparison member. 
for scName in Enum.GetNames scType do
    let sc = Enum.Parse(scType, scName) :?> StringComparison
    printfn $"Comparisons using {sc}:"
    // Compare each character in character array.
    for ctr = 0 to 1 do
        let instanceChar = threeIs[ctr]
        for innerCtr = ctr + 1 to threeIs.GetUpperBound 0 do
            let otherChar = threeIs[innerCtr]
            printfn $"{instanceChar} (U+{Convert.ToInt16(Char.Parse instanceChar):X4}) = {otherChar} (U+{Convert.ToInt16(Char.Parse otherChar):X4}): {instanceChar.Equals(otherChar, sc)}"
        printfn ""
// The example displays the following output:
//       The current culture is en-US.
//       
//       Comparisons using CurrentCulture:
//       i (U+0069) = i (U+0131): False
//       i (U+0069) = I (U+0049): False
//       
//       i (U+0131) = I (U+0049): False
//       
//       Comparisons using CurrentCultureIgnoreCase:
//       i (U+0069) = i (U+0131): False
//       i (U+0069) = I (U+0049): True
//       
//       i (U+0131) = I (U+0049): False
//       
//       Comparisons using InvariantCulture:
//       i (U+0069) = i (U+0131): False
//       i (U+0069) = I (U+0049): False
//       
//       i (U+0131) = I (U+0049): False
//       
//       Comparisons using InvariantCultureIgnoreCase:
//       i (U+0069) = i (U+0131): False
//       i (U+0069) = I (U+0049): True
//       
//       i (U+0131) = I (U+0049): False
//       
//       Comparisons using Ordinal:
//       i (U+0069) = i (U+0131): False
//       i (U+0069) = I (U+0049): False
//       
//       i (U+0131) = I (U+0049): False
//       
//       Comparisons using OrdinalIgnoreCase:
//       i (U+0069) = i (U+0131): False
//       i (U+0069) = I (U+0049): True
//       
//       i (U+0131) = I (U+0049): False
// </Snippet1>