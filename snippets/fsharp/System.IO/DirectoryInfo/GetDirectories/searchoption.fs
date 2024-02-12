//<snippet00>
open System.IO

// Specify the directory you want to manipulate.
let path = @"c:\"
let searchPattern = "c*"

let di = DirectoryInfo path
let directories = di.GetDirectories(searchPattern, SearchOption.TopDirectoryOnly)

let files = di.GetFiles(searchPattern, SearchOption.TopDirectoryOnly)

printfn $"Directories that begin with the letter \"c\" in {path}"
for dir in directories do
    printfn $"{dir.FullName,-25} {dir.LastWriteTime,25}"

printfn $"\nFiles that begin with the letter \"c\" in {path}"
for file in files do
    printfn $"{file.Name,-25} {file.LastWriteTime,25}"
//</snippet00>