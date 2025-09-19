//<SNIPPET1>
open System
open System.IO

// Move a file into another file, delete the original, and create a backup of the replaced file.
let replaceFile fileToMoveAndDelete fileToReplace backupOfFileToReplace =
    File.Replace(fileToMoveAndDelete, fileToReplace, backupOfFileToReplace, false)

let originalFile = "test.xml"
let fileToReplace = "test2.xml"
let backUpOfFileToReplace = "test2.xml.bac"

printfn
    $"Move the contents of {originalFile} into {fileToReplace}, delete {originalFile}, and create a backup of {fileToReplace}."

// Replace the file.
replaceFile originalFile fileToReplace backUpOfFileToReplace

printfn "Done"
//</SNIPPET1>
