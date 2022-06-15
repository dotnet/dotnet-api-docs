//<Snippet1>
//<Snippet2>
module RecursiveFileProcessor

open System.IO

// Insert logic for processing found files here.
let processFile path =
    printfn $"Processed file '%s{path}'."

// Process all files in the directory passed in, recurse on any directories
// that are found, and process the files they contain.
let rec processDirectory targetDirectory =
    // Process the list of files found in the directory.
    let fileEntries = Directory.GetFiles targetDirectory
    for fileName in fileEntries do
        processFile fileName

    // Recurse into subdirectories of this directory.
    let subdirectoryEntries = Directory.GetDirectories targetDirectory
    for subdirectory in subdirectoryEntries do
        processDirectory subdirectory

[<EntryPoint>]
let main args =
    for path in args do
        if File.Exists path then
            // This path is a file
            processFile path
        elif Directory.Exists path then
            // This path is a directory
            processDirectory path
        else
            printfn $"{path} is not a valid file or directory."
    0

//</Snippet2>
//</Snippet1>