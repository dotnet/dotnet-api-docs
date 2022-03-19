// <Snippet1>
#nowarn "9"
open System
open System.Runtime.InteropServices
open FSharp.NativeInterop

[<EntryPoint>]
let main _ =
    let mutable arr = 
        [| 2; 4; 6; 8; 10; 12; 14; 16; 18; 20 |]
    
    use parr = fixed arr
    
    let ptr = NativePtr.toNativeInt parr

    // Get the size of an array element.
    let size = sizeof<int>
    for i = 0 to arr.Length - 1 do
        let newPtr = IntPtr.Add(ptr, i * size)
        printf $"{Marshal.ReadInt32 newPtr}   "
    0

// The example displays the following output:
//       2   4   6   8   10   12   14   16   18   20
// </Snippet1>