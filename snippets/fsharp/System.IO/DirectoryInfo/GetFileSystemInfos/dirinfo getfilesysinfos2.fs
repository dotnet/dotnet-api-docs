module dirinfo_getfilesysinfos2

// <Snippet1>
open System
open System.IO

let mutable files = 0
let mutable directories = 0

let rec listDirectoriesAndFiles (fsInfo: FileSystemInfo[]) searchString =
    // Check the parameters.
    if fsInfo = null then
        nullArg "fsInfo"

    if String.IsNullOrEmpty searchString then
        invalidArg "searchString" "Search string cannot be empty."
    
    // Iterate through each item.
    for i in fsInfo do
        // Check to see if this is a DirectoryInfo object.
        match i with
        | :? DirectoryInfo as dInfo ->
            // Add one to the directory count.
            directories <- directories + 1

            // Iterate through all sub-directories.
            listDirectoriesAndFiles (dInfo.GetFileSystemInfos searchString) searchString
        // Check to see if this is a FileInfo object.
        | :? FileInfo ->
            // Add one to the file count.
            files <- files + 1
        | _ -> ()

try
    printfn "Enter the path to a directory:"

    let directory = stdin.ReadLine()

    printfn "Enter a search string (for example *p*):"

    let searchString = stdin.ReadLine()

    // Create a new DirectoryInfo object.
    let dir = DirectoryInfo directory

    if not dir.Exists then
        raise (DirectoryNotFoundException "The directory does not exist.")

    // Call the GetFileSystemInfos method.
    let infos = dir.GetFileSystemInfos searchString

    printfn "Working..."

    // Pass the result to the ListDirectoriesAndFiles
    // method defined below.
    listDirectoriesAndFiles infos searchString

    // Display the results to the console.
    printfn $"Directories: {directories}"
    printfn $"Files: {files}"
with e ->
    printfn $"{e.Message}"
// </Snippet1>