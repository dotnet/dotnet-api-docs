module program

open System
open System.IO

// <Snippet1>
// Create a DirectoryInfo of the directory of the files to enumerate.
let dirInfo = DirectoryInfo @"\archives1\library\"

let startOf2009 = DateTime(2009, 01, 01)

// LINQ query for all files created before 2009.
let files = 
    query {
        for f in dirInfo.EnumerateFiles() do
        where (f.CreationTime < startOf2009)
        select f
    }

// Show results.
for f in files do
    printfn $"{f.Name}"
// </Snippet1>