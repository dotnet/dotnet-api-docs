module type_getmethod3

// <Snippet1>
open System.Reflection

type Program() =
    // Methods to get:
    member _.MethodA(i: int, j: int) = ()

    member _.MethodA(i: int[]) = ()
    
    member _.MethodA(i: int nativeptr) = ()

    member _.MethodA(r: int byref) = ()

    // Method that takes an outref parameter:
    member _.MethodA(i: int, o: int outref) = o <- 100

do
    // Get MethodA(int i, int j)
    let mInfo = 
        typeof<Program>.GetMethod("MethodA", BindingFlags.Public ||| BindingFlags.Instance, null, CallingConventions.Any, [| typeof<int>; typeof<int> |], null)
    printfn $"Found method: {mInfo}"

    // Get MethodA(int[] i)
    let mInfo = 
        typeof<Program>.GetMethod("MethodA", BindingFlags.Public ||| BindingFlags.Instance, null, CallingConventions.Any, [| typeof<int[]> |], null)
    printfn $"Found method: {mInfo}"

    // Get MethodA(int* i)
    let mInfo = 
        typeof<Program>.GetMethod("MethodA", BindingFlags.Public ||| BindingFlags.Instance, null, CallingConventions.Any, [| typeof<int>.MakePointerType() |], null)
    printfn $"Found method: {mInfo}"

    // Get MethodA(ref int r)
    let mInfo = 
        typeof<Program>.GetMethod("MethodA", BindingFlags.Public ||| BindingFlags.Instance, null, CallingConventions.Any, [| typeof<int>.MakeByRefType() |], null)
    printfn $"Found method: {mInfo}"

    // Get MethodA(int i, out int o)
    let mInfo = 
        typeof<Program>.GetMethod("MethodA", BindingFlags.Public ||| BindingFlags.Instance, null, CallingConventions.Any, [| typeof<int>; typeof<int>.MakeByRefType() |], null)
    printfn $"Found method: {mInfo}"
// </Snippet1>