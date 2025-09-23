module source2
//<Snippet1>
open System
open System.Collections.Generic

// Create a new Dictionary of strings, with string keys
// and a case-insensitive comparer for the current culture.
let openWith = Dictionary<string, string> StringComparer.CurrentCultureIgnoreCase

// Add some elements to the dictionary.
openWith.Add("txt", "notepad.exe")
openWith.Add("bmp", "paint.exe")
openWith.Add("DIB", "paint.exe")
openWith.Add("rtf", "wordpad.exe")

// Try to add a fifth element with a key that is the same
// except for case; this would be allowed with the default
// comparer.
try
    openWith.Add("BMP", "paint.exe")
with :? ArgumentException ->
    printfn "\nBMP is already in the dictionary."

// List the contents of the sorted dictionary.
printfn ""

for kvp in openWith do
    printfn $"Key = {kvp.Key}, Value = {kvp.Value}"
// This code example produces the following output:
//     BMP is already in the dictionary.
//
//     Key = txt, Value = notepad.exe
//     Key = bmp, Value = paint.exe
//     Key = DIB, Value = paint.exe
//     Key = rtf, Value = wordpad.exe
//</Snippet1>
