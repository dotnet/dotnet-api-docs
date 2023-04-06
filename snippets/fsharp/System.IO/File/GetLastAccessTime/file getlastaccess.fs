module filegetlastaccess
// <Snippet1>
open System
open System.IO

let path = @"c:\Temp\MyTest.txt"

if File.Exists path |> not then
    File.Create path |> ignore

File.SetLastAccessTime(path, DateTime(1985, 5, 4))

// Get the creation time of a well-known directory.
let dt = File.GetLastAccessTime path
printfn $"The last access time for this file was {dt}."

// Update the last access time.
File.SetLastAccessTime(path, DateTime.Now)
let dt2 = File.GetLastAccessTime path
printfn $"The last access time for this file was {dt2}."
// </Snippet1>
