// <Snippet1>
open System
open System.IO

try
    let path = @"c:\MyDir"
    if not (Directory.Exists path) then
        Directory.CreateDirectory path |> ignore

    else
        // Take an action that will affect the write time.
        Directory.SetLastWriteTime(path, DateTime(1985, 4, 3))

    // Get the last write time of a well-known directory.
    let dt = Directory.GetLastWriteTime path
    printfn $"The last write time for this directory was {dt}"
    
    //Update the last write time.
    Directory.SetLastWriteTime(path, DateTime.Now)
    let dt = Directory.GetLastWriteTime path
    printfn $"The last write time for this directory was {dt}"
with e ->
    printfn $"The process failed: {e}"
// </Snippet1>