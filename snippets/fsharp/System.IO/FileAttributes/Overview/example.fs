// <snippet1>
open System.IO

let attributes = File.GetAttributes "c:/Temp/testfile.txt"
if attributes &&& FileAttributes.ReadOnly = FileAttributes.ReadOnly then
    printfn "read-only file"
else
    printfn "not read-only file"
// </snippet1>