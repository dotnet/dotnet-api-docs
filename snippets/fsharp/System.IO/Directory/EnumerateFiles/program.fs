// <Snippet1>
open System
open System.IO

try
    // Set a variable to the My Documents path.
    let docPath =
        Environment.GetFolderPath Environment.SpecialFolder.MyDocuments

    let files =
        query {
            for file in Directory.EnumerateFiles(docPath, "*.txt", SearchOption.AllDirectories) do
            for line in File.ReadLines file do
            where (line.Contains "Microsoft")
            select {| File = file; Line = line |}
        }

    for f in files do
        printfn $"{f.File}\t{f.Line}"
    printfn $"{Seq.length files} files found."

with
| :? UnauthorizedAccessException as uAEx -> printfn $"{uAEx.Message}"
| :? PathTooLongException as pathEx -> printfn $"{pathEx.Message}"
// </Snippet1>
