// <Snippet1>
open System
open System.Reflection

// This class is used to demonstrate the IsMarshalByRefImpl method.
type MyContextBoundClass() =
    inherit ContextBoundObject()
    let myString = "This class is used to demonstrate members of the Type class."

type MyTypeDelegatorClass(myType) =
    inherit TypeDelegator(myType)
    [<DefaultValue>]    
    val mutable public myElementType : string

    // Override IsMarshalByRefImpl.
    override this.IsMarshalByRefImpl() =
        // Determine whether the type is marshalled by reference.
        if myType.IsMarshalByRef then
            this.myElementType <- " marshalled by reference"
            true
        else false

try
    printfn "Determine whether MyContextBoundClass is marshalled by reference."
    // Determine whether MyContextBoundClass type is marshalled by reference.
    let myType = MyTypeDelegatorClass typeof<MyContextBoundClass>
    if myType.IsMarshalByRef then
        printfn $"{typeof<MyContextBoundClass>} is marshalled by reference."
    else
        printfn $"{typeof<MyContextBoundClass>} is not marshalled by reference."

    // Determine whether int type is marshalled by reference.
    let myType = MyTypeDelegatorClass typeof<int>
    printfn "\nDetermine whether int is marshalled by reference."
    if myType.IsMarshalByRef then
        printfn $"{typeof<int>} is marshalled by reference."
    else
        printfn $"{typeof<int>} is not marshalled by reference."
with e ->
    printfn $"Exception: {e.Message}"

// </Snippet1>