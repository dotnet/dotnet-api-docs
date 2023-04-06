module type_getmethod2

// <Snippet1>
open System.Reflection

type Program() =
    // Method to get:
    member _.MethodA() = ()

// Get MethodA()
let mInfo = typeof<Program>.GetMethod("MethodA", BindingFlags.Public ||| BindingFlags.Instance)
printfn $"Found method: {mInfo}"
// </Snippet1>