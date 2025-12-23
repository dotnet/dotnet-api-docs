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

// To get the keys alone, use the Keys property.
let icoll2: ICollection = openWith.Keys

// The elements of the collection are strongly typed
// with the type that was specified for dictionary keys,
// even though the ICollection interface is not strongly
// typed.
printfn ""

for s in icoll2 do
    printfn $"Key = {s}"

// When you use foreach to enumerate dictionary elements
// with the IDictionary interface, the elements are retrieved
// as DictionaryEntry objects instead of KeyValuePair objects.
printfn ""

for de in openWith do
    let de = de :?> DictionaryEntry
    printfn $"For key = {de.Key}, value = {de.Value}"
