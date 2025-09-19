module badcall1

// <Snippet2>
open System
open System.Runtime.InteropServices

[<DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true )>]
extern int MessageBox(IntPtr hwnd, String text, String caption, uint ``type``)

[<DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true )>]
extern int MessageBoxW(IntPtr hwnd, String text, String caption, uint ``type``)

try
    MessageBox(IntPtr 0, "Calling the MessageBox Function", "Example", 0u)
    |> ignore
with :? EntryPointNotFoundException as e ->
    printfn $"{e.GetType().Name}:\n   {e.Message}"

try
    MessageBoxW(IntPtr 0, "Calling the MessageBox Function", "Example", 0u)
    |> ignore
with :? EntryPointNotFoundException as e ->
    printfn $"{e.GetType().Name}:\n   {e.Message}"
// </Snippet2>