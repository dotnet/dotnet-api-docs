module Program

// <Snippet1>
open System.IO

// Specify the directories you want to manipulate.
let di1 = DirectoryInfo @"c:\MyDir"
let di2 = DirectoryInfo @"c:\MyDir\temp"

try
    // Create the directories.
    di1.Create()
    di2.Create()

    // This operation will not be allowed because there are subdirectories.
    printfn $"I am about to attempt to delete {di1.Name}."
    di1.Delete()
    printfn "The Delete operation was successful, which was unexpected."
with _ ->
    printfn "The Delete operation failed as expected."
// </Snippet1>