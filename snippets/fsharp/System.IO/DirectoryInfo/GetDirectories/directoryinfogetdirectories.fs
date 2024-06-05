module directoryinfogetdirectories

// <snippet1>
open System.IO

// Make a reference to a directory.
let di = DirectoryInfo "c:\\"

// Get a reference to each directory in that directory.
let diArr = di.GetDirectories()

// Display the names of the directories.
for dri in diArr do
    printfn $"{dri.Name}"
// </snippet1>