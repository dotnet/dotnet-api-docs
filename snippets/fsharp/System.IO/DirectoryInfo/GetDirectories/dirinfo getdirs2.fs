module dirinfo_getdirs2

// <Snippet1>
open System.IO

try
    let di = DirectoryInfo @"c:\"

    // Get only subdirectories that contain the letter "p."
    let dirs = di.GetDirectories "*p*"
    printfn $"The number of directories containing the letter p is {dirs.Length}."

    for diNext in dirs do
        printfn $"The number of files in {diNext} is {diNext.GetFiles().Length}"
with e ->
    printfn $"The process failed: {e}"
// </Snippet1>