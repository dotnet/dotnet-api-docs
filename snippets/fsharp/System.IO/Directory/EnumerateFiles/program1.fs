module program1

// <Snippet1>
open System
open System.IO

try
    // All files containing the word 'Europe'.
    let files =
        Directory.EnumerateFiles @"\\archives1\library\"
        |> Seq.filter (fun file -> file.ToLower().Contains "europe")

    for file in files do
        printfn $"{file}"
    printfn $"{Seq.length files} files found."

with 
| :? UnauthorizedAccessException as uaEx ->
    printfn $"{uaEx.Message}"
| :? PathTooLongException as pathEx ->
    printfn $"{pathEx.Message}"
// </Snippet1>