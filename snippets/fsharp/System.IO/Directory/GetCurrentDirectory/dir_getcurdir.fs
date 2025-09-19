// <Snippet1>
open System
open System.IO

try
    // Get the current directory.
    let path = Directory.GetCurrentDirectory()
    let target = @"c:\temp"
    printfn $"The current directory is {path}"
    if not (Directory.Exists target) then
        Directory.CreateDirectory target |> ignore

    // Change the current directory.
    Environment.CurrentDirectory <- target
    if path.Equals(Directory.GetCurrentDirectory()) then
        printfn "You are in the temp directory."
    else
        printfn "You are not in the temp directory."
with e ->
    printfn $"The process failed: {e}"
// </Snippet1>