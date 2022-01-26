// The following code example clones a CultureInfo array and demonstrates the behavior of a shallow copy.

// <Snippet1>
open System
open System.Globalization

let printIndexAndValues (myArray: 'a []) =
    for i = myArray.GetLowerBound 0 to myArray.GetUpperBound 0 do
        printfn $"\t[{i}]:\t{myArray[i]}"

// Create and initialize a new CultureInfo array.
let ci0 = CultureInfo("ar-SA", false)
let ci1 = CultureInfo("en-US", false)
let ci2 = CultureInfo("fr-FR", false)
let ci3 = CultureInfo("ja-JP", false)
let arrCI = [| ci0; ci1; ci2; ci3 |]

// Create a clone of the CultureInfo array.
let arrCIClone = arrCI.Clone() :?> CultureInfo []

// Replace an element in the clone array.
let ci4 = CultureInfo("th-TH", false)
arrCIClone[0] <- ci4

// Display the contents of the original array.
printfn "The original array contains the following values:"
printIndexAndValues arrCI

// Display the contents of the clone array.
printfn "The clone array contains the following values:"
printIndexAndValues arrCIClone

// Display the DateTimeFormatInfo.DateSeparator for the fourth element in both arrays.
printfn "Before changes to the clone:"
printfn $"   Original: The DateTimeFormatInfo.DateSeparator for {arrCI[3].Name} is {arrCI[3].DateTimeFormat.DateSeparator}."
printfn $"      Clone: The DateTimeFormatInfo.DateSeparator for {arrCIClone[3].Name} is {arrCIClone[3].DateTimeFormat.DateSeparator}."

// Replace the DateTimeFormatInfo.DateSeparator for the fourth element in the clone array.
arrCIClone[3].DateTimeFormat.DateSeparator <- "-"

// Display the DateTimeFormatInfo.DateSeparator for the fourth element in both arrays.
printfn "After changes to the clone:"
printfn $"   Original: The DateTimeFormatInfo.DateSeparator for {arrCI[3].Name} is {arrCI[3].DateTimeFormat.DateSeparator}."
printfn $"      Clone: The DateTimeFormatInfo.DateSeparator for {arrCIClone[3].Name} is {arrCIClone[3].DateTimeFormat.DateSeparator}."


// This code produces the following output.
//     The original array contains the following values:
//             [0]:    ar-SA
//             [1]:    en-US
//             [2]:    fr-FR
//             [3]:    ja-JP
//     The clone array contains the following values:
//             [0]:    th-TH
//             [1]:    en-US
//             [2]:    fr-FR
//             [3]:    ja-JP
//     Before changes to the clone:
//        Original: The DateTimeFormatInfo.DateSeparator for ja-JP is /.
//           Clone: The DateTimeFormatInfo.DateSeparator for ja-JP is /.
//     After changes to the clone:
//        Original: The DateTimeFormatInfo.DateSeparator for ja-JP is -.
//           Clone: The DateTimeFormatInfo.DateSeparator for ja-JP is -.

// </Snippet1>
