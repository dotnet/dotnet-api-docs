module alltext_encoding
//<snippet00>
open System
open System.IO
open System.Text

let path = @"c:\temp\MyTest.txt"

// This text is added only once to the file.
if File.Exists path |> not then
    // Create a file to write to.
    let createText = [ "Hello"; "And"; "Welcome" ]
    File.WriteAllLines(path, createText, Encoding.UTF8)

// This text is always added, making the file longer over time
// if it is not deleted.
let appendText =
    "This is extra text" + Environment.NewLine

File.AppendAllText(path, appendText, Encoding.UTF8)

// Open the file to read from.
let readText = File.ReadAllLines(path, Encoding.UTF8)

for s in readText do
    printfn $"{s}"
//</snippet00>
