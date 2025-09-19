// <snippet1>
open System.IO

// Make a reference to a directory.
let di = DirectoryInfo "TempDir"

// Create the directory only if it does not already exist.
if not di.Exists then
    di.Create()

// Create a subdirectory in the directory just created.
let dis = di.CreateSubdirectory "SubDir"

// Get a reference to the parent directory of the subdirectory you just made.
let parentDir = dis.Parent
printfn $"The parent directory of '{dis.Name}' is '{parentDir.Name}'"

// Delete the parent directory.
di.Delete true
// </snippet1>