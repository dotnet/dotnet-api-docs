module fsizesort

// <Snippet1>
open System.IO

let mutable files = 0
let mutable directories = 0

let rec listDirectoriesAndFiles (fsInfo: FileSystemInfo[]) =
    // Check the FSInfo parameter.
    if fsInfo = null then
        nullArg "fsInfo"

    // Iterate through each item.
    for i in fsInfo do
        // Check to see if this is a DirectoryInfo object.
        match i with 
        | :? DirectoryInfo as dInfo ->
            // Add one to the directory count.
            directories <- directories + 1

            // Iterate through all sub-directories.
            listDirectoriesAndFiles (dInfo.GetFileSystemInfos())
        // Check to see if this is a FileInfo object.
        | :? FileInfo ->
            // Add one to the file count.
            files <- files + 1
        | _ -> ()

try
    printfn "Enter the path to a directory:"

    let directory = stdin.ReadLine()

    // Create a new DirectoryInfo object.
    let dir = DirectoryInfo directory

    if not dir.Exists then
        raise (DirectoryNotFoundException "The directory does not exist.")

    // Call the GetFileSystemInfos method.
    let infos = dir.GetFileSystemInfos()

    printfn "Working..."

    // Pass the result to the ListDirectoriesAndFiles
    // method defined below.
    listDirectoriesAndFiles infos

    // Display the results to the console.
    printfn $"Directories: {directories}"
    printfn $"Files: {files}"
with e ->
    printfn $"{e.Message}"
// </Snippet1>