module class5

// <snippet13>
open System.IO

let sourceDirectory = @"C:\current"
let archiveDirectory = @"C:\archive"

try
    let txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt", SearchOption.AllDirectories)

    for currentFile in txtFiles do
        let fileName = currentFile.Substring(sourceDirectory.Length + 1)
        Directory.Move(currentFile, Path.Combine(archiveDirectory, fileName))
with e ->
    printfn $"{e.Message}"
// </snippet13>