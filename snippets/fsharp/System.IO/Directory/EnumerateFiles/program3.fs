module program3

// <Snippet1>
open System
open System.IO

try
    // Set a variable to the My Documents path.
    let docPath =
        Environment.GetFolderPath Environment.SpecialFolder.MyDocuments

    // Set the options for the enumeration.
    let options = new EnumerationOptions(
        IgnoreInaccessible = true,
        MatchCasing = MatchCasing.CaseInsensitive,
        MatchType = MatchType.Simple,
        RecurseSubdirectories = true
    )

    let files =
        query {
            for file in Directory.EnumerateFiles(docPath, "*.txt", options) do
            for line in File.ReadLines file do
            where (line.Contains "Microsoft")
            select {| File = file; Line = line |}
        }

    for f in files do
        printfn $"{f.File}\t{f.Line}"

    printfn $"{Seq.length files} files found."
with
| :? PathTooLongException as pathEx -> printfn $"{pathEx.Message}"
| ex -> printfn $"{ex.Message}"
// </Snippet1>
