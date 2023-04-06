//<Snippet1>
open System.Runtime.InteropServices

type Example = class end

[<Struct>]
type Test1 = 
    val B1 : byte
    val S : int16
    val B2 : byte

[<Struct; StructLayout(LayoutKind.Explicit, Pack=1)>] 
type Test2 =
    [<FieldOffset 0>] val B1 : byte
    [<FieldOffset 1>] val S : int16
    [<FieldOffset 3>] val B2 : byte

let displayLayoutAttribute (sla: StructLayoutAttribute) =
    printfn $"\nCharSet: {sla}\n   Pack: {sla.Pack}\n   Size: {sla.Size}\n  Value: {sla.Value}"
displayLayoutAttribute typeof<Example>.StructLayoutAttribute
displayLayoutAttribute typeof<Test1>.StructLayoutAttribute
displayLayoutAttribute typeof<Test2>.StructLayoutAttribute
//</Snippet1>