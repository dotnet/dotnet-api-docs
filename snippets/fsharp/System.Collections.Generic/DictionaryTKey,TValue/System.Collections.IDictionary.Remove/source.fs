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

// Use the Remove method to remove a key/value pair. No
// exception is thrown if the wrong data type is supplied.
printfn "\nRemove(\"dib\")"
openWith.Remove "dib"

if openWith.Contains "dib" |> not then
    printfn "Key \"dib\" is not found."
