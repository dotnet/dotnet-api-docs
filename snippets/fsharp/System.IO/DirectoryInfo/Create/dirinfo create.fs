module Program

// <Snippet1>
open System.IO

// Specify the directories you want to manipulate.
let di = DirectoryInfo @"c:\MyDir"

try
    // Determine whether the directory exists.
    if di.Exists then
        // Indicate that it already exists.
        printfn "That path exists already."
    else
        // Try to create the directory.
        di.Create()
        printfn "The directory was created successfully."

        // Delete the directory.
        di.Delete()
        printfn "The directory was deleted successfully."
with e ->
    printfn $"The process failed: {e}"
// </Snippet1>