open System.IO

// <Snippet1>
let sourceDir = @"c:\current"
let backupDir = @"c:\archives\2008"

try
    let picList = Directory.GetFiles(sourceDir, "*.jpg")
    let txtList = Directory.GetFiles(sourceDir, "*.txt")

    // Copy picture files.
    for f in picList do
        // Remove path from the file name.
        let fName = f.Substring(sourceDir.Length + 1)

        // Use the Path.Combine method to safely append the file name to the path.
        // Will overwrite if the destination file already exists.
        File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true)

    // Copy text files.
    for f in txtList do
        // Remove path from the file name.
        let fName = f.Substring(sourceDir.Length + 1)

        try
            // Will not overwrite if the destination file already exists.
            File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName))

        // Catch exception if the file was already copied.
        with
        | :? IOException as copyError -> printfn $"{copyError.Message}"

    // Delete source files that were copied.
    for f in txtList do
        File.Delete f

    for f in picList do
        File.Delete f

// Catch exception if the file was already copied.
with
| :? DirectoryNotFoundException as dirNotFound -> printfn $"{dirNotFound.Message}"

// </Snippet1>
