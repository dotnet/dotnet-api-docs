// <Snippet1>
open System
open System.IO
open System.Runtime.InteropServices
open FSharp.NativeInterop

[<Struct>]
type FileTime =
    val dwLowDateTime: uint
    val dwHighDateTime: uint

    static member ToLong(fileTime: FileTime) =
        // Convert 4 high-order bytes to a byte array
        let mutable highBytes = BitConverter.GetBytes fileTime.dwHighDateTime
        
        // Resize the array to 8 bytes (for a Long)
        Array.Resize(&highBytes, 8)

        // Assign high-order bytes to first 4 bytes of Long
        let returnedLong = BitConverter.ToInt64(highBytes, 0)
        
        // Shift high-order bytes into position
        let returnedLong = returnedLong <<< 32
        
        // Or with low-order bytes
        returnedLong ||| int64 fileTime.dwLowDateTime

let [<Literal>] OPEN_EXISTING = 3
let [<Literal>] INVALID_HANDLE_VALUE = -1

[<DllImport("Kernel32.dll", CharSet = CharSet.Unicode)>]
extern int CreateFile(string lpFileName,
                      int dwDesiredAccess,
                      int dwShareMode,
                      int lpSecurityAttributes,
                      int dwCreationDisposition,
                      int dwFlagsAndAttributes,
                      int hTemplateFile)

[<DllImport "Kernel32.dll">]
extern bool GetFileTime(int hFile,
                        nativeint lpCreationTime,
                        nativeint lpLastAccessTime,
                        nativeint lpLastWriteTime)

[<DllImport "Kernel32.dll">]
extern bool CloseHandle(int hFile)


// Open file %windir%\write.exe
let winDir = 
    let winDir = Environment.SystemDirectory
    let winDir =
        if winDir.EndsWith(string Path.DirectorySeparatorChar) then
            winDir
        else
            winDir + string Path.DirectorySeparatorChar
    winDir + "write.exe"

// Get file time using Windows API
// Open file
let hFile = CreateFile(winDir, 0, 0, 0, OPEN_EXISTING, 0, 0)

if hFile = INVALID_HANDLE_VALUE then
    printfn $"Unable to access {winDir}."
else
    let mutable creationTime = Unchecked.defaultof<FileTime>
    let mutable accessTime = Unchecked.defaultof<FileTime>
    let mutable writeTime = Unchecked.defaultof<FileTime>

    if GetFileTime(hFile, NativePtr.toNativeInt &&creationTime, NativePtr.toNativeInt &&accessTime, NativePtr.toNativeInt &&writeTime) then
        let fileCreationTime = FileTime.ToLong creationTime
        let fileAccessTime = FileTime.ToLong accessTime
        let fileWriteTime = FileTime.ToLong writeTime

        printfn $"File {winDir} Retrieved Using the Windows API:"
        printfn $"   Created:     {DateTimeOffset.FromFileTime fileCreationTime |> string:d}"
        printfn $"   Last Access: {DateTimeOffset.FromFileTime fileAccessTime |> string:d}"
        printfn $"   Last Write:  {DateTimeOffset.FromFileTime fileWriteTime |> string:d}\n"

// Get date and time, convert to file time, then convert back
let fileInfo = FileInfo winDir

// Get dates and times of file creation, last access, and last write
let infoCreationTime = fileInfo.CreationTime
let infoAccessTime = fileInfo.LastAccessTime
let infoWriteTime = fileInfo.LastWriteTime

// Convert values to file times
let ftCreationTime = infoCreationTime.ToFileTime()
let ftAccessTime = infoAccessTime.ToFileTime()
let ftWriteTime = infoWriteTime.ToFileTime()

// Convert file times back to DateTimeOffset values
printfn $"File {winDir} Retrieved Using a FileInfo Object:"
printfn $"   Created:     {DateTimeOffset.FromFileTime ftCreationTime |> string:d}"
printfn $"   Last Access: {DateTimeOffset.FromFileTime ftAccessTime |> string:d}"
printfn $"   Last Write:  {DateTimeOffset.FromFileTime ftWriteTime |> string:d}"


// The example produces the following output:
//    File C:\WINDOWS\system32\write.exe Retrieved Using the Windows API:
//       Created:     10/13/2005 5:26:59 PM -07:00
//       Last Access: 3/20/2007 2:07:00 AM -07:00
//       Last Write:  8/4/2004 5:00:00 AM -07:00
//
//    File C:\WINDOWS\system32\write.exe Retrieved Using a FileInfo Object:
//       Created:     10/13/2005 5:26:59 PM -07:00
//       Last Access: 3/20/2007 2:07:00 AM -07:00
//       Last Write:  8/4/2004 5:00:00 AM -07:00
// </Snippet1>