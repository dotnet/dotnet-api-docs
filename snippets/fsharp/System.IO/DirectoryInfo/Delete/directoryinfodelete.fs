module directoryinfodelete

// <snippet1>
open System.IO

// Make a reference to a directory.
let di = DirectoryInfo "TempDir"

// Create the directory only if it does not already exist.
if not di.Exists then
    di.Create()

// Create a subdirectory in the directory just created.
let dis = di.CreateSubdirectory "SubDir"

// Process that directory as required.
// ...

// Delete the subdirectory. The true indicates that if subdirectories
// or files are in this directory, they are to be deleted as well.
dis.Delete true

// Delete the directory.
di.Delete true
// </snippet1>