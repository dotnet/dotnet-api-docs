module source

open System
open System.Collections.Generic

//<Snippet1>
//<Snippet2>
// Create a new dictionary of strings, with string keys.
let openWith = Dictionary<string, string>()

// Add some elements to the dictionary. There are no
// duplicate keys, but some of the values are duplicates.
openWith.Add("txt", "notepad.exe")
openWith.Add("bmp", "paint.exe")
openWith.Add("dib", "paint.exe")
openWith.Add("rtf", "wordpad.exe")

// The Add method throws an exception if the new key is
// already in the dictionary.
try
    openWith.Add("txt", "winword.exe")
with :? ArgumentException ->
    printfn "An element with Key = \"txt\" already exists."
//</Snippet2>

//<Snippet3>
// The Item property is another name for the indexer, so you
// can omit its name when accessing elements.
printfn $"""For key = "rtf", value = {openWith["rtf"]}"""

// The indexer can be used to change the value associated
// with a key.
openWith["rtf"] <- "winword.exe"
printfn $"""For key = "rtf", value = {openWith["rtf"]}"""

// If a key does not exist, setting the indexer for that key
// adds a new key/value pair.
openWith["doc"] <- "winword.exe"
//</Snippet3>

//<Snippet4>
// The indexer throws an exception if the requested key is
// not in the dictionary.
try
    printfn $"""For key = "tif", value = {openWith["tif"]}"""
with :? KeyNotFoundException ->
    printfn "Key = \"tif\" is not found."
//</Snippet4>

//<Snippet5>
// When a program often has to try keys that turn out not to
// be in the dictionary, TryGetValue can be a more efficient
// way to retrieve values.
match openWith.TryGetValue "tif" with
| true, value -> printfn $"For key = \"tif\", value = {value}."
| _ -> printfn "Key = \"tif\" is not found."
//</Snippet5>

//<Snippet6>
// ContainsKey can be used to test keys before inserting
// them.
if openWith.ContainsKey "ht" |> not then
    openWith.Add("ht", "hypertrm.exe")
    printfn $"""Value added for key = "ht": {openWith["ht"]}"""
//</Snippet6>

//<Snippet7>
// When you use foreach to enumerate dictionary elements,
// the elements are retrieved as KeyValuePair objects.
printfn ""

for kvp in openWith do
    printfn $"Key = {kvp.Key}, Value = {kvp.Value}"
//</Snippet7>

//<Snippet8>
// To get the values alone, use the Values property.
let valueColl = openWith.Values

// The elements of the ValueCollection are strongly typed
// with the type that was specified for dictionary values.
printfn ""

for s in valueColl do
    printfn $"Value = {s}"
//</Snippet8>

//<Snippet9>
// To get the keys alone, use the Keys property.
let keyColl = openWith.Keys

// The elements of the KeyCollection are strongly typed
// with the type that was specified for dictionary keys.
printfn ""

for s in keyColl do
    printfn $"Key = {s}"
//</Snippet9>

//<Snippet10>
// Use the Remove method to remove a key/value pair.
printfn "\nRemove(\"doc\")"
openWith.Remove "doc" |> ignore

if openWith.ContainsKey "doc" |> not then
    printfn "Key \"doc\" is not found."
//</Snippet10>
// This code example produces the following output:
//     An element with Key = "txt" already exists.
//     For key = "rtf", value = wordpad.exe.
//     For key = "rtf", value = winword.exe.
//     Key = "tif" is not found.
//     Key = "tif" is not found.
//     Value added for key = "ht": hypertrm.exe
//
//     Key = txt, Value = notepad.exe
//     Key = bmp, Value = paint.exe
//     Key = dib, Value = paint.exe
//     Key = rtf, Value = winword.exe
//     Key = doc, Value = winword.exe
//     Key = ht, Value = hypertrm.exe
//
//     Value = notepad.exe
//     Value = paint.exe
//     Value = paint.exe
//     Value = winword.exe
//     Value = winword.exe
//     Value = hypertrm.exe
//
//     Key = txt
//     Key = bmp
//     Key = dib
//     Key = rtf
//     Key = doc
//     Key = ht
//
//     Remove("doc")
//     Key "doc" is not found.
//</Snippet1>
