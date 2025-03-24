//<SNIPPET1>
// This sample shows the differences between dates from methods that use
//coordinated universal time (UTC) format and those that do not.
open System
open System.IO

// Set the directory.
let n = @"C:\test\newdir"
//Create two variables to use to set the time.
let dtime1 = DateTime(2002, 1, 3)
let dtime2 = DateTime(1999, 1, 1)

//Create the directory.
try
    Directory.CreateDirectory n |> ignore
with :? IOException as e ->
    printfn $"{e}"

//Set the creation and last access times to a variable DateTime value.
Directory.SetCreationTime(n, dtime1)
Directory.SetLastAccessTimeUtc(n, dtime1)

// Print to console the results.
printfn $"Creation Date: {Directory.GetCreationTime n}"
printfn $"UTC creation Date: {Directory.GetCreationTimeUtc n}"
printfn $"Last write time: {Directory.GetLastWriteTime n}"
printfn $"UTC last write time: {Directory.GetLastWriteTimeUtc n}"
printfn $"Last access time: {Directory.GetLastAccessTime n}"
printfn $"UTC last access time: {Directory.GetLastAccessTimeUtc n}"

//Set the last write time to a different value.
Directory.SetLastWriteTimeUtc(n, dtime2)
printfn $"Changed last write time: {Directory.GetLastWriteTimeUtc n}"
// Obviously, since this sample deals with dates and times, the output will vary
// depending on when you run the executable. Here is one example of the output:
//Creation Date: 1/3/2002 12:00:00 AM
//UTC creation Date: 1/3/2002 8:00:00 AM
//Last write time: 12/31/1998 4:00:00 PM
//UTC last write time: 1/1/1999 12:00:00 AM
//Last access time: 1/2/2002 4:00:00 PM
//UTC last access time: 1/3/2002 12:00:00 AM
//Changed last write time: 1/1/1999 12:00:00 AM

//</SNIPPET1>