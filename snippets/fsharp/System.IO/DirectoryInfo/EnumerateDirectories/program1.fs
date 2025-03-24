module program1

//<Snippet1>
open System
open System.IO

// Set a variable to the My Documents path.
let docPath = Environment.GetFolderPath Environment.SpecialFolder.MyDocuments

let diTop = DirectoryInfo docPath

try
    for fi in diTop.EnumerateFiles() do
        try
            // Display each file over 10 MB.
            if fi.Length > 10000000 then
                printfn $"{fi.FullName}\t\t{fi.Length:N0}"
        with :? UnauthorizedAccessException as unAuthTop ->
            printfn $"{unAuthTop.Message}"

    for di in diTop.EnumerateDirectories "*" do
        try
            for fi in di.EnumerateFiles("*", SearchOption.AllDirectories) do
                try
                    // Display each file over 10 MB.
                    if fi.Length > 10000000 then
                        printfn $"{fi.FullName}\t\t{fi.Length:N0}"
                with :? UnauthorizedAccessException as unAuthFile ->
                    printfn $"unAuthFile: {unAuthFile.Message}"
        with :? UnauthorizedAccessException as unAuthSubDir ->
            printfn $"unAuthSubDir: {unAuthSubDir.Message}"
with
| :? DirectoryNotFoundException as dirNotFound ->
    Console.WriteLine($"{dirNotFound.Message}")
| :? UnauthorizedAccessException as unAuthDir ->
    printfn $"unAuthDir: {unAuthDir.Message}"
| :? PathTooLongException as longPath ->
    printfn $"{longPath.Message}"
// </Snippet1>