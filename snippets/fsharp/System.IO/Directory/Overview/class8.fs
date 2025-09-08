module class8

// <Snippet16>
open System.IO

let sourceDirectory = @"C:\current"
let archiveDirectory = @"C:\archive"

let options = new EnumerationOptions(
    MatchCasing = MatchCasing.CaseInsensitive,
    MatchType = MatchType.Simple,
    RecurseSubdirectories = true
)

try
    let txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt", options)

    for currentFile in txtFiles do
        let fileName = currentFile.Substring(sourceDirectory.Length + 1)
        Directory.Move(currentFile, Path.Combine(archiveDirectory, fileName))
with ex ->
    printfn $"{ex.Message}"
// </Snippet16>
