module class1

// <snippet1>
open System.IO

let subPath = @"C:\NewDirectory\NewSubDirectory"

try
    Directory.CreateDirectory subPath |> ignore
    Directory.Delete subPath

    let directoryExists = Directory.Exists @"C:\NewDirectory"
    let subDirectoryExists = Directory.Exists subPath

    printfn $"top-level directory exists: {directoryExists}"
    printfn $"sub-directory exists: {subDirectoryExists}"
with e ->
    printfn $"The process failed: {e.Message}"
// </snippet1>