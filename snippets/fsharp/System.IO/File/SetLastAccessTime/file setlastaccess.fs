module setlastaccess
// <Snippet1>
open System
open System.IO

try
    let path = @"c:\Temp\MyTest.txt"

    if File.Exists path |> not then
        File.Create path |> ignore

    // Update the last access time.
    File.SetLastAccessTime(path, DateTime(1985, 5, 4))

    // Get the creation time of a well-known directory.
    let dt = File.GetLastAccessTime path
    printfn $"The last access time for this file was {dt}."

    // Update the last access time.
    File.SetLastAccessTime(path, DateTime.Now)
    let dt = File.GetLastAccessTime path
    printfn $"The last access time for this file was {dt}."
with
| e -> printfn $"The process failed: {e}"
// </Snippet1>
