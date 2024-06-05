// <Snippet1>
open System
open System.IO


let filePath = @".\ROFile.txt"
if File.Exists filePath |> not then
    File.Create filePath |> ignore
// Keep existing attributes, and set ReadOnly attribute.
File.SetAttributes(filePath, (FileInfo filePath).Attributes ||| FileAttributes.ReadOnly)

do
    use sw = new StreamWriter(filePath)
    try
        sw.Write "Test"
    with :? UnauthorizedAccessException ->
        let attr = (FileInfo filePath).Attributes
        printf "UnAuthorizedAccessException: Unable to access file. "
        if int (attr &&& FileAttributes.ReadOnly) > 0 then
            printf "The file is read-only."
// The example displays the following output:
//    UnAuthorizedAccessException: Unable to access file. The file is read-only.
// </Snippet1>