module dir_getdirs3

// <Snippet2>
open System.IO

try
    let dirs = Directory.GetDirectories(@"c:\", "p*", SearchOption.TopDirectoryOnly)
    printfn $"The number of directories starting with p is {dirs.Length}."
    for dir in dirs do
        printfn $"{dir}"
with e ->
    printfn $"The process failed: {e}"
// </Snippet2>