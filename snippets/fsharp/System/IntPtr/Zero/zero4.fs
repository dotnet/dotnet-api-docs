// <Snippet2>
open Microsoft.Win32.SafeHandles
open System
open System.Runtime.InteropServices

let GENERIC_READ = 0x80000000u
let OPEN_EXISTING = 3u
let FILE_ATTRIBUTE_NORMAL = 128u
let FILE_FLAG_OVERLAPPED = 0x40000000u

[<DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)>]
extern SafeFileHandle CreateFile(
            string lpFileName, uint dwDesiredAccess, uint dwShareMode,
            nativeint pSecurityAttributes, uint dwCreationDisposition,
            uint dwFlagsAndAttributes, nativeint hTemplateFile)

let hnd = 
    CreateFile("CallOfTheWild.txt", GENERIC_READ, 0u,
               IntPtr.Zero, OPEN_EXISTING,
               FILE_ATTRIBUTE_NORMAL ||| FILE_FLAG_OVERLAPPED,
               IntPtr.Zero)

if hnd.IsInvalid then
    let ex = Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error())
    printfn $"Attempt to open file failed:\n  {ex.Message}"
else
    printfn "File successfully opened."
    hnd.Close()

// If the file cannot be found, the example displays the following output:
//    Attempt to open file failed:
//      The system cannot find the file specified. (Exception from HRESULT: 0x80070002)
// </Snippet2>