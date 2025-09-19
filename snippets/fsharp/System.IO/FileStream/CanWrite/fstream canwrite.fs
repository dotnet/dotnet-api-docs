module fstream_canwrite
// <Snippet1>
open System.IO

let path = @"c:\temp\MyTest.txt"

// Ensure that the file is readonly.
File.SetAttributes(path, File.GetAttributes path ||| FileAttributes.ReadOnly)

//Create the file.
do
    use fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read)

    if fs.CanWrite then
        printfn $"The stream for file {path} is writable."

    else
        printfn $"The stream for file {path} is not writable."
// </Snippet1>
