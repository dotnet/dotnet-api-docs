open System
open System.Collections
open System.Collections.Generic

// Create a new dictionary of strings, with string keys,
// and access it using the IDictionary interface.
let openWith: IDictionary = Dictionary<string, string>()

// Add some elements to the dictionary. There are no
// duplicate keys, but some of the values are duplicates.
// IDictionary.Add throws an exception if incorrect types
// are supplied for key or value.
openWith.Add("txt", "notepad.exe")
openWith.Add("bmp", "paint.exe")
openWith.Add("dib", "paint.exe")
openWith.Add("rtf", "wordpad.exe")

// Contains can be used to test keys before inserting
// them.
if openWith.Contains "ht" |> not then
    openWith.Add("ht", "hypertrm.exe")
    printfn $"""Value added for key = "ht": {openWith["ht"]}"""

// IDictionary.Contains returns false if the wrong data
// type is supplied.
printfn $"openWith.Contains(29.7) returns {openWith.Contains 29.7}"
