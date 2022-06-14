//<Snippet5>
//<Snippet4>
//<Snippet3>
//<Snippet2>
//<Snippet1>
open System
open System.IO
open System.Security

let printFileSystemEntries path =
    try
        // Obtain the file system entries in the directory path.
        let directoryEntries = Directory.GetFileSystemEntries path

        for str in directoryEntries do
            printfn $"{str}"
    with 
    | :? ArgumentNullException ->
        printfn "Path is a null reference."
    | :? SecurityException ->
        printfn $"The caller does not have the required permission."
    | :? ArgumentException ->
        printfn $"Path is an empty string, contains only white spaces, or contains invalid characters."
    | :? DirectoryNotFoundException ->
        printfn $"The path encapsulated in the Directory object does not exist."

let printFileSystemEntriesPattern path pattern =
    try
        // Obtain the file system entries in the directory
        // path that match the pattern.
        let directoryEntries = Directory.GetFileSystemEntries(path, pattern)

        for str in directoryEntries do
            printfn $"{str}"
    with
    | :? ArgumentNullException -> printfn "Path is a null reference."
    | :? SecurityException -> printfn "The caller does not have the required permission."
    | :? ArgumentException -> printfn "Path is an empty string, contains only white spaces, or contains invalid characters."
    | :? DirectoryNotFoundException -> printfn "The path encapsulated in the Directory object does not exist."

// Print out all logical drives on the system.
let getLogicalDrives () =
    try
        let drives = Directory.GetLogicalDrives()

        for str in drives do
            printfn $"{str}"
    with
    | :? IOException -> printfn "An I/O error occurs."
    | :? SecurityException -> printfn "The caller does not have the required permission."

let getParent path =
    try
        let directoryInfo = Directory.GetParent path
        printfn $"{directoryInfo.FullName}"

    with
    | :? ArgumentNullException -> printfn "Path is a null reference."
    | :? ArgumentException -> printfn "Path is an empty string, contains only white spaces, or contains invalid characters."

let move sourcePath destinationPath =
    try
        Directory.Move(sourcePath, destinationPath)
        printfn "The directory move is complete."

    with
    | :? ArgumentNullException -> printfn "Path is a null reference."
    | :? SecurityException -> printfn "The caller does not have the required permission."
    | :? ArgumentException -> printfn "Path is an empty string, contains only white spaces, or contains invalid characters."
    | :? IOException -> printfn "An attempt was made to move a directory to a different volume, or destDirName already exists."

let path = Directory.GetCurrentDirectory()
let filter = "*.exe"

printFileSystemEntries path
printFileSystemEntriesPattern path filter
getLogicalDrives ()
getParent path
move "C:\\proof" "C:\\Temp"

//</Snippet1>
//</Snippet2>
//</Snippet3>
//</Snippet4>
//</Snippet5>