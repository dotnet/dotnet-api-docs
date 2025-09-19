module type_getmethod1

// <Snippet1>
type Program() =
    // Method to get:
    member _.MethodA() = ()

// Get MethodA()
let mInfo = typeof<Program>.GetMethod "MethodA"
printfn $"Found method: {mInfo}"
// </Snippet1>