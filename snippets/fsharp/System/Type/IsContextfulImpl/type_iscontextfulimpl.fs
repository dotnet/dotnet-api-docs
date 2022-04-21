// <Snippet1>
open System
open System.Reflection

type MyTypeDelegatorClass(myType) =
    inherit TypeDelegator(myType) 
    member val myElementType = null with get, set
    
    // Override IsContextfulImpl.
    override this.IsContextfulImpl() = 
        // Check whether the type is contextful.
        if myType.IsContextful then
            this.myElementType <- " is contextful "
            true
        else false

// This class demonstrates IsContextfulImpl.
type MyContextBoundClass() =
    inherit ContextBoundObject()
    let myString = "This class is used to demonstrate members of the Type class."

type MyTypeDemoClass() = class end

try
    printfn "Check whether MyContextBoundClass can be hosted in a context."
    // Check whether MyContextBoundClass is contextful.
    let myType = MyTypeDelegatorClass typeof<MyContextBoundClass>
    if myType.IsContextful then
        printfn $"{typeof<MyContextBoundClass>} can be hosted in a context."
    else
        printfn $"{typeof<MyContextBoundClass>} cannot be hosted in a context."
    // Check whether the int type is contextful.
    let myType = MyTypeDelegatorClass typeof<MyTypeDemoClass>
    printfn "\nCheck whether MyTypeDemoClass can be hosted in a context."
    if myType.IsContextful then
        printfn $"{typeof<MyTypeDemoClass>} can be hosted in a context."
    else
        printfn $"{typeof<MyTypeDemoClass>} cannot be hosted in a context."
with e ->
    printfn $"Exception: {e.Message}"

// </Snippet1>