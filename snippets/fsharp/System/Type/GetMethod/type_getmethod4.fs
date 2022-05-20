module type_getmethod4

// <Snippet1>
type Program() =
    // Methods to get:
    member _.MethodA(i: int, j: int) = ()

    member _.MethodA(i: int[]) = ()
    
    member _.MethodA(i: int nativeptr) = ()

    member _.MethodA(r: int byref) = ()

    // Method that takes an outref parameter:
    member _.MethodA(i: int, o: int outref) = o <- 100

do
    // member MethodA: i: int * j: int -> unit
    let mInfo = typeof<Program>.GetMethod("MethodA", [| typeof<int>; typeof<int> |])
    printfn $"Found method: {mInfo}"

    // member MethodA: i: int[] -> unit
    let mInfo = typeof<Program>.GetMethod("MethodA", [| typeof<int[]> |])
    printfn $"Found method: {mInfo}"

    // member MethodA: i: nativeptr<int> -> unit
    let mInfo = typeof<Program>.GetMethod("MethodA", [| typeof<int>.MakePointerType() |])
    printfn $"Found method: {mInfo}"

    // member MethodA: r: byref<int> -> unit
    let mInfo = typeof<Program>.GetMethod("MethodA", [| typeof<int>.MakeByRefType() |])
    printfn $"Found method: {mInfo}"

    // member MethodA: i: int * o: outref<int> -> unit
    let mInfo = typeof<Program>.GetMethod("MethodA", [| typeof<int>; typeof<int>.MakeByRefType() |])
    printfn $"Found method: {mInfo}"
// </Snippet1>