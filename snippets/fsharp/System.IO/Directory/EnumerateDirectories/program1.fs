module program1

// <Snippet1>
open System
open System.IO

try
    let dirPath = @"\\archives\2009\reports"

    let dirs = 
        Directory.EnumerateDirectories(dirPath, "dv_*")
        |> Seq.cache

    // Show results.
    for dir in dirs do
        // Remove path information from string.
        printfn $"{dir.Substring(dir.LastIndexOf '\\' + 1)}"
    printfn $"{Seq.length dirs} directories found."

    // Optionally create a list collection.
    let workDirs = Seq.toList dirs
    ()
    
with 
| :? UnauthorizedAccessException as uaEx ->
    printfn $"{uaEx.Message}"
| :? PathTooLongException as pathEx ->
    printfn $"{pathEx.Message}"
// </Snippet1>