//<snippet1>
#nowarn "9"
open System.Runtime.InteropServices
open FSharp.NativeInterop

[<EntryPoint>]
let main _ = 
    let stringA = "I seem to be turned around!"
    let mutable copylen = stringA.Length

    // Allocate HGlobal memory for source and destination strings
    let sptr = Marshal.StringToHGlobalAnsi stringA
    let dptr = Marshal.AllocHGlobal(copylen + 1)

    let mutable src: byte nativeptr = sptr.ToPointer() |> NativePtr.ofVoidPtr
    let mutable dst: byte nativeptr = dptr.ToPointer() |> NativePtr.ofVoidPtr

    if copylen > 0 then
        // set the source pointer to the end of the string
        // to do a reverse copy.
        src <- 
            NativePtr.toNativeInt src + nativeint (copylen - 1) 
            |> NativePtr.ofNativeInt

        while copylen > 0 do
            copylen <- copylen - 1
            NativePtr.read src |> NativePtr.write dst
            dst <- NativePtr.toNativeInt dst + 1n |> NativePtr.ofNativeInt
            src <- NativePtr.toNativeInt src - 1n |> NativePtr.ofNativeInt
        NativePtr.write dst 0uy

    let stringB = Marshal.PtrToStringAnsi dptr

    printfn $"Original:\n{stringA}\n"
    printfn $"Reversed:\n{stringB}"

    // Free HGlobal memory
    Marshal.FreeHGlobal dptr
    Marshal.FreeHGlobal sptr
    0

// The progam has the following output:
//
// Original:
// I seem to be turned around!
//
// Reversed:
// !dnuora denrut eb ot mees I
//</snippet1>