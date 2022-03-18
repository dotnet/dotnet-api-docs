//<Snippet4>
open System
open System.IO

if Environment.OSVersion.Platform = PlatformID.Win32NT then
    // Change the directory to %WINDIR%
    Environment.CurrentDirectory <- Environment.GetEnvironmentVariable "windir"
    
    let info = DirectoryInfo "."

    printfn $"Directory Info:   {info.FullName}"
else
    printfn "This example runs on Windows only."
// The example displays output like the following on a .NET implementation running on Windows:
//        Directory Info:   C:\windows
// The example displays the following output on a .NET implementation on Unix-based systems:
//        This example runs on Windows only.
//</Snippet4>