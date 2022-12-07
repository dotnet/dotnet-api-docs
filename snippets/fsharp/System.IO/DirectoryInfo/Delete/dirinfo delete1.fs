module dirinfordelete

// <Snippet1>
open System.IO

// Specify the directories you want to manipulate.
let di1 = DirectoryInfo @"c:\MyDir"

try
    // Create the directories.
    di1.Create()
    di1.CreateSubdirectory "temp" |> ignore

    //This operation will not be allowed because there are subdirectories.
    printfn $"I am about to attempt to delete {di1.Name}"
    di1.Delete()
    printfn "The Delete operation was successful, which was unexpected."
with _ ->
    printfn "The Delete operation failed as expected."
// </Snippet1>