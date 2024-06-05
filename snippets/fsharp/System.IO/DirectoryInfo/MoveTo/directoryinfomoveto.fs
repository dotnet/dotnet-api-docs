//<snippet1>
open System.IO

// Make a reference to a directory.
let di = DirectoryInfo "TempDir"

// Create the directory only if it does not already exist.
if not di.Exists then
    di.Create()

// Create a subdirectory in the directory just created.
let dis = di.CreateSubdirectory "SubDir"

// Move the main directory. Note that the contents move with the directory.
if not (Directory.Exists "NewTempDir") then
    di.MoveTo "NewTempDir"

try
    // Attempt to delete the subdirectory. Note that because it has been
    // moved, an exception is thrown.
    dis.Delete true
with _ ->
    // Handle this exception in some way, such as with the following code:
    // Console.WriteLine("That directory does not exist.")
    ()

// Point the DirectoryInfo reference to the new directory.
//di = new DirectoryInfo("NewTempDir")

// Delete the directory.
//di.Delete(true)
// </snippet1>