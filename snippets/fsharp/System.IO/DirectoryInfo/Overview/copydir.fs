module copydir

//<snippet1>
open System.IO

let rec copyAll (source: DirectoryInfo) (target: DirectoryInfo) =
    if source.FullName.ToLower() <> target.FullName.ToLower() then
        // Check if the target directory exists, if not, create it.
        if not (Directory.Exists target.FullName) then
            Directory.CreateDirectory target.FullName |> ignore

        // Copy each file into it's new directory.
        for fi in source.GetFiles() do
            printfn $@"Copying {target.FullName}\{fi.Name}"
            fi.CopyTo(Path.Combine(string target, fi.Name), true) |> ignore

        // Copy each subdirectory using recursion.
        for diSourceSubDir in source.GetDirectories() do
            target.CreateSubdirectory diSourceSubDir.Name
            |> copyAll diSourceSubDir

let sourceDirectory = @"c:\sourceDirectory"
let targetDirectory = @"c:\targetDirectory"

let diSource = DirectoryInfo sourceDirectory
let diTarget = DirectoryInfo targetDirectory

copyAll diSource diTarget

// Output will vary based on the contents of the source directory.
//</snippet1>