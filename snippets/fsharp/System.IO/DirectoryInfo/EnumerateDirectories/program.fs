module program

// <Snippet1>
open System
open System.IO

// Set a variable to the Documents path.
let docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

let dirPrograms = DirectoryInfo docPath
let startOf2009 = DateTime(2009, 01, 01)

let dirs =
    query {
        for dir in dirPrograms.EnumerateDirectories() do
        where (dir.CreationTimeUtc > startOf2009)
        select {| ProgDir = dir |}
    }

for di in dirs do
    printfn $"{di.ProgDir.Name}"
// </Snippet1>