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

// The Item property is another name for the indexer, so you
// can omit its name when accessing elements.
printfn $"""For key = "rtf", value = {openWith.["rtf"]}."""

// The indexer can be used to change the value associated
// with a key.
openWith["rtf"] <- "winword.exe"
printfn $"""For key = "rtf", value = {openWith.["rtf"]}."""

// If a key does not exist, setting the indexer for that key
// adds a new key/value pair.
openWith["doc"] <- "winword.exe"

// The indexer returns null if the key is of the wrong data
// type.
printfn "The indexer returns null if the key is of the wrong type:"
printfn $"""For key = 2, value = {openWith.[2]}."""

// The indexer throws an exception when setting a value
// if the key is of the wrong data type.
try
    openWith[2] <- "This does not get added."
with :? ArgumentException ->
    printfn "A key of the wrong type was specified when assigning to the indexer."

// Unlike the default Item property on the Dictionary class
// itself, IDictionary.Item does not throw an exception
// if the requested key is not in the dictionary.
printfn $"""For key = "tif", value = {openWith.["tif"]}."""
