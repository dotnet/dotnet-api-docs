module AllText
//<snippet00>
open System
open System.IO

let path = @"c:\temp\MyTest.txt"

// This text is added only once to the file.
if File.Exists path |> not then
    // Create a file to write to.
    let createText =
        "Hello and Welcome" + Environment.NewLine

    File.WriteAllText(path, createText)

// This text is always added, making the file longer over time
// if it is not deleted.
let appendText =
    "This is extra text" + Environment.NewLine

File.AppendAllText(path, appendText)

// Open the file to read from.
let readText = File.ReadAllText path
printfn $"{readText}"
//</snippet00>
