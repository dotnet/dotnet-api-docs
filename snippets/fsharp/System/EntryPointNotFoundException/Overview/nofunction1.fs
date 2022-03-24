module nofunction1

// <Snippet1>
open System
open System.Runtime.InteropServices

[<DllImport "user32.dll">]
extern int GetMyNumber()

try
    let number = GetMyNumber()
    ()
with :? EntryPointNotFoundException as e ->
    printfn $"{e.GetType().Name}:\n   {e.Message}"

// The example displays the following output:
//    EntryPointNotFoundException:
//       Unable to find an entry point named 'GetMyNumber' in DLL 'User32.dll'.
// </Snippet1>