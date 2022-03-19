// <Snippet1>
#nowarn "9"
open System
open System.Runtime.InteropServices
open FSharp.NativeInterop

[<EntryPoint>]
let main _ =
    let arr =
        [| 2; 4; 6; 8; 10; 12; 14; 16; 18; 20 |]

    // Get the size of a single array element.
    let size = sizeof<int>

    use pend = fixed &arr[arr.GetUpperBound 0]
    let ptr = NativePtr.toNativeInt pend 
    for i = 0 to arr.Length - 1 do
        let newPtr = IntPtr.Subtract(ptr, i * size)
        printf $"{Marshal.ReadInt32 newPtr}   "
    0

// The example displays the following output:
//       20   18   16   14   12   10   8   6   4   2
// </Snippet1>