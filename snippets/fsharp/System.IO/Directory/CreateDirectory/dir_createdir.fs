// <Snippet1>
open System.IO

// Specify the directory you want to manipulate.
let path = @"c:\MyDir"

try
    // Determine whether the directory exists.
    if Directory.Exists path then
        printfn "That path exists already."
    else
        // Try to create the directory.
        let di = Directory.CreateDirectory path
        printfn $"The directory was created successfully at {Directory.GetCreationTime path}."

        // Delete the directory.
        di.Delete()
        printfn "The directory was deleted successfully."
with e ->
    printfn $"The process failed: {e}"
// </Snippet1>