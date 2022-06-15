module class2

// <snippet2>
open System.IO

let topPath = @"C:\NewDirectory"
let subPath = @"C:\NewDirectory\NewSubDirectory"

try
    Directory.CreateDirectory(subPath) |> ignore

    do
        use writer = File.CreateText(subPath + @"\example.txt")
        writer.WriteLine "content added"

    Directory.Delete(topPath, true)

    let directoryExists = Directory.Exists topPath

    printfn $"top-level directory exists: {directoryExists}"
    
with e ->
    printfn $"The process failed: {e.Message}"
// </snippet2>