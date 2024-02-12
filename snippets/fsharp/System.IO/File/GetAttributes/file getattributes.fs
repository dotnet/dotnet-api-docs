module filegetattributes
// <Snippet1>
open System.IO
open System.Text

let removeAttribute attributes attributesToRemove = attributes &&& ~~~attributesToRemove

let path = @"c:\temp\MyTest.txt"

// Create the file if it does not exist.
if File.Exists path |> not then
    File.Create path |> ignore

let attributes = File.GetAttributes path

if attributes &&& FileAttributes.Hidden = FileAttributes.Hidden then
    // Show the file.
    let attributes =
        removeAttribute attributes FileAttributes.Hidden

    File.SetAttributes(path, attributes)
    printfn $"The {path} file is no longer hidden."
else
    // Hide the file.
    File.SetAttributes(path, File.GetAttributes path ||| FileAttributes.Hidden)
    printfn $"The {path} file is now hidden."
// </Snippet1>
