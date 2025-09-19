module source3
//<Snippet1>
open System.Collections.Generic

// Create a new dictionary of strings, with string keys and
// an initial capacity of 4.
let openWith = Dictionary<string, string> 4

// Add 4 elements to the dictionary.
openWith.Add("txt", "notepad.exe")
openWith.Add("bmp", "paint.exe")
openWith.Add("dib", "paint.exe")
openWith.Add("rtf", "wordpad.exe")

// List the contents of the dictionary.
printfn ""

for kvp in openWith do
    printfn $"Key = {kvp.Key}, Value = {kvp.Value}"
// This code example produces the following output:
//     Key = txt, Value = notepad.exe
//     Key = bmp, Value = paint.exe
//     Key = dib, Value = paint.exe
//     Key = rtf, Value = wordpad.exe
//</Snippet1>
