module program2

// <Snippet1>
open System
open System.IO

try
    // All .txt files containing the word 'Europe'.
    let files = 
        Directory.EnumerateFiles(@"\\archives1\library\", "*.txt")
        |> Seq.filter(fun file -> file.ToLower().Contains "europe")

    for file in files do
        printfn $"{file}"
    printfn $"{Seq.length files} files found."

with
| :? UnauthorizedAccessException as uaEx ->
    printfn $"{uaEx.Message}"
| :? PathTooLongException as pathEx ->
    printfn $"{pathEx.Message}"
// </Snippet1>