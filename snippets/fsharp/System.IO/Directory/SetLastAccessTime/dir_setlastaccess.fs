// <Snippet1>
open System
open System.IO

try
    let path = @"c:\MyDir"
    if not (Directory.Exists path) then
        Directory.CreateDirectory path |> ignore

    Directory.SetLastAccessTime(path, DateTime(1985,5,4))

    // Get the last access time of a well-known directory.
    let dt = Directory.GetLastAccessTime path
    printfn $"The last access time for this directory was {dt}"

    // Update the last access time.
    Directory.SetLastAccessTime(path, DateTime.Now)
    let dt = Directory.GetLastAccessTime path
    printfn $"The last access time for this directory was {dt}"

with e ->
    printfn $"The process failed: {e}"
// </Snippet1>