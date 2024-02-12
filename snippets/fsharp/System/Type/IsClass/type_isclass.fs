// <Snippet1>
type MyDemoClass = class end

try
    let myType = typeof<MyDemoClass>
    // Get and display the 'IsClass' property of the 'MyDemoClass' instance.
    printfn $"\nIs the specified type a class? {myType.IsClass}."
with e ->
    printfn $"\nAn exception occurred: {e.Message}."
// </Snippet1>