// <Snippet1>
#nowarn "9"
open System.Runtime.InteropServices
open FSharp.NativeInterop

[<EntryPoint>]
let main _ =
    let arr =
        [| 2; 4; 6; 8; 10; 12; 14; 16; 18; 20 |]
        
    use parr = fixed arr

    let ptr = NativePtr.toNativeInt parr

    for i = 0 to arr.Length - 1 do
        let newPtr = ptr + nativeint i * nativeint sizeof<int>
        printf $"{Marshal.ReadInt32 newPtr}   "
    0

    // The example displays the following output:
    //       2   4   6   8   10   12   14   16   18   20
    // </Snippet1>