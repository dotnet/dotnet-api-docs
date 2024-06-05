module mangle1

// <Snippet7>
open System
open System.Runtime.InteropServices

[<DllImport "TestDll.dll">]
extern int Double(int number)

printfn $"{Double 10}"
// The example displays the following output:
//    Unhandled Exception: System.EntryPointNotFoundException: Unable to find
//    an entry point named 'Double' in DLL '.\TestDll.dll'.
//       at Example.Double(Int32 number)
//       at Example.Main()
// </Snippet7>