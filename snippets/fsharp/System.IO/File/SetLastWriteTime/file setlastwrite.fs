module filesetlastwrite
// <Snippet1>
open System
open System.IO

try
    let path = @"c:\Temp\MyTest.txt"

    if File.Exists path |> not then
        File.Create path |> ignore
    else
        // Take an action that will affect the write time.
        File.SetLastWriteTime(path, DateTime(1985, 4, 3))

    // Get the creation time of a well-known directory.
    let dt = File.GetLastWriteTime path
    printfn $"The last write time for this file was {dt}."

    // Update the last write time.
    File.SetLastWriteTime(path, DateTime.Now)
    let dt = File.GetLastWriteTime path
    printfn $"The last write time for this file was {dt}."
with
| e -> printfn $"The process failed: {e}"
// </Snippet1>
