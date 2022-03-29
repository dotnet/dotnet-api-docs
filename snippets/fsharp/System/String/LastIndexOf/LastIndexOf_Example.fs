module LastIndexOf_Example.fs
// <Snippet1>
open System
open System.IO

let extractFilename (filepath: string) =
    // If path ends with a "\", it's a path only so return String.Empty.
    if filepath.Trim().EndsWith @"\" then
        String.Empty
    else
        // Determine where last backslash is.
        let position = filepath.LastIndexOf '\\'
        // If there is no backslash, assume that this is a filename.
        if position = -1 then
            // Determine whether file exists in the current directory.
            if File.Exists(Environment.CurrentDirectory + string Path.DirectorySeparatorChar + filepath) then
                filepath
            else
                String.Empty
        else
            // Determine whether file exists using filepath.
            if File.Exists filepath then
            // Return filename without file path.
                filepath.Substring(position + 1)
            else
                String.Empty

do
    let filename = extractFilename @"C:\temp\"
    printfn $"""{if String.IsNullOrEmpty filename then "<none>" else filename}"""

    let filename = extractFilename @"C:\temp\delegate.txt"
    printfn $"""{if String.IsNullOrEmpty filename then "<none>" else filename}"""

    let filename = extractFilename "delegate.txt"
    printfn $"""{if String.IsNullOrEmpty filename then "<none>" else filename}"""

    let filename = extractFilename @"C:\temp\notafile.txt"
    printfn $"""{if String.IsNullOrEmpty filename then "<none>" else filename}"""
// </Snippet1>
