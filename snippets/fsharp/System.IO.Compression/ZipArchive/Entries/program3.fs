module program3
// <snippet3>
open System.IO.Compression

let zipPath = @"c:\users\exampleuser\start.zip"
let extractPath = @"c:\users\exampleuser\extract"
let newFile = @"c:\users\exampleuser\NewFile.txt"

do
    use archive = ZipFile.Open(zipPath, ZipArchiveMode.Update)
    archive.CreateEntryFromFile(newFile, "NewEntry.txt") |> ignore
    archive.ExtractToDirectory extractPath
// </snippet3>
