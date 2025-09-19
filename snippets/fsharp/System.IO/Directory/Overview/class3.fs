module class3

// <snippet11>
open System.IO

let archiveDirectory = @"C:\archive"

let files = 
    query {
        for retrivedFile in Directory.EnumerateFiles(archiveDirectory, "*.txt", SearchOption.AllDirectories) do
        for line in File.ReadLines retrivedFile do
        where (line.Contains "file") 
        select 
            {| File = retrivedFile 
               Line = line |}
    }

for f in files do
    printfn $"{f.File} contains {f.Line}"
printfn "{Seq.length files} lines found."
// </snippet11>