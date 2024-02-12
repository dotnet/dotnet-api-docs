module program

// <Snippet1>
open System
open System.IO

try
    // Set a variable to the My Documents path.
    let docPath = Environment.GetFolderPath Environment.SpecialFolder.MyDocuments

    let dirs = Directory.EnumerateDirectories docPath |> Seq.toList

    for dir in dirs do
        printfn $"{dir.Substring(dir.LastIndexOf Path.DirectorySeparatorChar + 1)}"
    printfn $"{dirs.Length} directories found."

with
| :? UnauthorizedAccessException as ex ->
    printfn $"{ex.Message}"
| :? PathTooLongException as ex ->
    printfn $"{ex.Message}"
// </Snippet1>