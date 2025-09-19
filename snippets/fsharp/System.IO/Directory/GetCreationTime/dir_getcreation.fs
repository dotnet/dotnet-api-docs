// <Snippet1>
open System
open System.IO

try
    // Get the creation time of a well-known directory.
    let dt = Directory.GetCreationTime Environment.CurrentDirectory

    // Give feedback to the user.
    if DateTime.Now.Subtract(dt).TotalDays > 364 then
        printfn "This directory is over a year old."
    elif DateTime.Now.Subtract(dt).TotalDays > 30 then
        printfn "This directory is over a month old."
    elif DateTime.Now.Subtract(dt).TotalDays <= 1 then
        printfn "This directory is less than a day old."
    else
        printfn $"This directory was created on {dt}"
with e ->
    printfn $"The process failed: {e}"
// </Snippet1>