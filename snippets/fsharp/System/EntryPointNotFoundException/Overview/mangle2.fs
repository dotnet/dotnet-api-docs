module mangle2

// <Snippet8>
open System
open System.Runtime.InteropServices

[<DllImport("TestDll.dll", EntryPoint = "?Double@@YAHH@Z")>]
extern int Double(int number)

printfn $"{Double 10}"
// The example displays the following output:
//    20
// </Snippet8>