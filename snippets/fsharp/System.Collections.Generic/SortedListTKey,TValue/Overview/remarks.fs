module remarks
open System
open System.Collections.Generic

// Create a new sorted list of strings, with string
// keys.
let mySortedList = SortedList<int, string>()

// Add some elements to the list. There are no
// duplicate keys, but some of the values are duplicates.
mySortedList.Add(0, "notepad.exe")
mySortedList.Add(1, "paint.exe")
mySortedList.Add(2, "paint.exe")
mySortedList.Add(3, "wordpad.exe")

//<Snippet11>
let v = mySortedList.Values[3]
//</Snippet11>

printfn $"Value at index 3: {v}"

//<Snippet12>
for kvp in mySortedList do
    printfn $"Key = {kvp.Key}, Value = {kvp.Value}"
//</Snippet12>
