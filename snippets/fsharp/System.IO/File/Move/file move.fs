module filemove
// <Snippet1>
open System.IO

let path = @"c:\temp\MyTest.txt"
let path2 = @"c:\temp2\MyTest.txt"

if File.Exists path |> not then
    // This statement ensures that the file is created,
    // but the handle is not kept.
    use _ = File.Create path
    ()

// Ensure that the target does not exist.
if File.Exists path2 then
    File.Delete path2

// Move the file.
File.Move(path, path2)
printfn $"{path} was moved to {path2}."

// See if the original exists now.
if File.Exists path then
    printfn "The original file still exists, which is unexpected."
else
    printfn "The original file no longer exists, which is expected."
// </Snippet1>
