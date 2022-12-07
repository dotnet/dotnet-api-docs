//<SNIPPET1>
// This sample shows how to set the current directory and how to determine
// the root directory.
open System.IO

// Create string for a directory. This value should be an existing directory
// or the sample will throw a DirectoryNotFoundException.
let dir = @"C:\test"
try
    //Set the current directory.
    Directory.SetCurrentDirectory dir
with :? DirectoryNotFoundException as e ->
    printfn $"The specified directory does not exist. {e}"
    
// Print to console the results.
printfn $"Root directory: {Directory.GetDirectoryRoot dir}"
printfn $"Current directory: {Directory.GetCurrentDirectory()}"
// The output of this sample depends on what value you assign to the variable dir.
// If the directory c:\test exists, the output for this sample is:
// Root directory: C:\
// Current directory: C:\test
//</SNIPPET1>