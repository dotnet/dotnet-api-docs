//<Snippet1>
open System.IO

printfn "Enter the file path:"
let filePath = stdin.ReadLine()

if File.Exists filePath then
    let fileCreationDateTime =
        File.GetCreationTime filePath

    let fileCreationFileTime = fileCreationDateTime.ToFileTime()

    printfn $"{fileCreationDateTime} in file time is {fileCreationFileTime}."

else
    printfn $"{filePath} is an invalid file"

//</Snippet1>