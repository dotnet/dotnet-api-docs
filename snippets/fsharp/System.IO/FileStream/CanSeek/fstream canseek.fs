module fstream_canseek
// <Snippet1>
open System.IO

let path = @"c:\temp\MyTest.txt"

// Delete the file if it exists.
if File.Exists path then
    File.Delete path


//Create the file.
do
    use fs = File.Create path

    if fs.CanSeek then
        printfn $"The stream connected to {path} is seekable."
    else
        printfn $"The stream connected to {path} is not seekable."

// </Snippet1>
