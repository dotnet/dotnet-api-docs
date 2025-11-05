module source2

open System.Collections.Generic

// Create a new dictionary of strings, with string keys.
let myDictionary = Dictionary<string, string>()

// Add some elements to the dictionary. There are no
// duplicate keys, but some of the values are duplicates.
myDictionary.Add("txt", "notepad.exe")
myDictionary.Add("bmp", "paint.exe")
myDictionary.Add("dib", "paint.exe")
myDictionary.Add("rtf", "wordpad.exe")

//<Snippet11>
for kvp in myDictionary do
    printfn $"Key = {kvp.Key}, Value = {kvp.Value}"
//</Snippet11>
