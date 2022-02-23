module zero2

// <Snippet1>
open System
open System.Runtime.InteropServices

let GW_OWNER = 4

[<DllImport("user32", CharSet=CharSet.Auto, SetLastError=true, ExactSpelling=true)>]
extern IntPtr GetWindow(nativeint hwnd, int wFlag)

let hwnd = IntPtr 3
let hOwner = GetWindow(hwnd, GW_OWNER)
if hOwner = IntPtr.Zero then
    printfn "Window not found."

// The example displays the following output:
//        Window not found.
// </Snippet1>