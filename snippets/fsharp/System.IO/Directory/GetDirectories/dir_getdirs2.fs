module dir_getdirs2

// <Snippet1>
open System.IO

try
    // Only get subdirectories that begin with the letter "p."
    let dirs = Directory.GetDirectories(@"c:\", "p*")
    printfn $"The number of directories starting with p is {dirs.Length}."
    for dir in dirs do
        printfn $"{dir}"
with e ->
    printfn $"The process failed: {e}"
// </Snippet1>