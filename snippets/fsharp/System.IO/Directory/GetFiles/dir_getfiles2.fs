// <Snippet1>
open System.IO

try
    // Only get files that begin with the letter "c".
    let dirs = Directory.GetFiles(@"c:\", "c*")
    printfn $"The number of files starting with c is {dirs.Length}."
    for dir in dirs do
        printfn $"{dir}"
with e ->
    printfn $"The process failed: {e}"
// </Snippet1>