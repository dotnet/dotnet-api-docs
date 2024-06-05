// <Snippet2>
#nowarn "9"
open System.Runtime.InteropServices
open FSharp.NativeInterop

[<EntryPoint>]
let main _ =
    let arr =
        [| 2; 4; 6; 8; 10; 12; 14; 16; 18; 20 |]

    use parr = fixed &arr[arr.GetUpperBound 0]
    
    let ptr = NativePtr.toNativeInt parr

    for i = 0 to arr.GetUpperBound 0 do
        let newPtr = ptr - nativeint i * nativeint sizeof<int>
        printf $"{Marshal.ReadInt32 newPtr}   "
    0

    // The example displays the following output:
    //       20   18   16   14   12   10   8   6   4   2
    // </Snippet2>