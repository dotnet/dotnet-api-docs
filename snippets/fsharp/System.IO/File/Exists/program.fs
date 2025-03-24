open System.IO

// <Snippet1>
let curFile = @"c:\temp\test.txt"

printfn
    $"""{if File.Exists curFile then
             "File exists."
         else
             "File does not exist."}"""
// </Snippet1>
