module type_defaultbinder

// <Snippet1>
open System
open System.Reflection

type MyClass() =
    member _.HelloWorld() =
        printfn "Hello World"

try
    let defaultBinder = Type.DefaultBinder
    let myClass = MyClass()
    // Invoke the HelloWorld method of MyClass.
    myClass.GetType().InvokeMember("HelloWorld", BindingFlags.InvokeMethod, defaultBinder, myClass, [||])
    |> ignore
with e ->
    printfn $"Exception: {e.Message}"
// </Snippet1>