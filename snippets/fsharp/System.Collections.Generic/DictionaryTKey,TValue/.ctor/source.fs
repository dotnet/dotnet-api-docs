module source
//<Snippet1>
open System.Collections.Generic

// Create a new sorted dictionary of strings, with string
// keys.
let openWith = SortedDictionary<string, string>()

// Add some elements to the dictionary.
openWith.Add("txt", "notepad.exe")
openWith.Add("bmp", "paint.exe")
openWith.Add("dib", "paint.exe")
openWith.Add("rtf", "wordpad.exe")

// Create a Dictionary of strings with string keys, and
// initialize it with the contents of the sorted dictionary.
let copy = Dictionary<string, string> openWith

// List the contents of the copy.
printfn ""

for kvp in copy do
    printfn $"Key = {kvp.Key}, Value = {kvp.Value}"
// This code example produces the following output:
//     Key = bmp, Value = paint.exe
//     Key = dib, Value = paint.exe
//     Key = rtf, Value = wordpad.exe
//     Key = txt, Value = notepad.exe
//</Snippet1>
