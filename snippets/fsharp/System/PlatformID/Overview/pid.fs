//<snippet1>
// This example demonstrates the PlatformID enumeration.
open System

let msg1 = "This is a Windows operating system."
let msg2 = "This is a Unix operating system."
let msg3 = "ERROR: This platform identifier is invalid."

// Assume this example is run on a Windows operating system.
let os = Environment.OSVersion
let pid = os.Platform
match pid with
| PlatformID.Win32NT
| PlatformID.Win32S
| PlatformID.Win32Windows
| PlatformID.WinCE ->
    printfn $"{msg1}"
| PlatformID.Unix ->
    printfn $"{msg2}"
| _ ->
    printfn $"{msg3}"
// This example produces the following results:
//     This is a Windows operating system.
//</snippet1>