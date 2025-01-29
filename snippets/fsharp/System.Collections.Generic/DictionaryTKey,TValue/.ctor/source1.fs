module source1
//<Snippet1>
open System
open System.Collections.Generic

// Create a new sorted dictionary of strings, with string
// keys and a case-insensitive comparer.
let openWith =
    SortedDictionary<string, string> StringComparer.CurrentCultureIgnoreCase

// Add some elements to the dictionary.
openWith.Add("txt", "notepad.exe")
openWith.Add("Bmp", "paint.exe")
openWith.Add("DIB", "paint.exe")
openWith.Add("rtf", "wordpad.exe")

// Create a Dictionary of strings with string keys and a
// case-insensitive equality comparer, and initialize it
// with the contents of the sorted dictionary.
let copy =
    Dictionary<string, string>(openWith, StringComparer.CurrentCultureIgnoreCase)

// List the contents of the copy.
printfn ""

for kvp in copy do
    printfn $"Key = {kvp.Key}, Value = {kvp.Value}"
// This code example produces the following output:
//     Key = Bmp, Value = paint.exe
//     Key = DIB, Value = paint.exe
//     Key = rtf, Value = wordpad.exe
//     Key = txt, Value = notepad.exe
//</Snippet1>
