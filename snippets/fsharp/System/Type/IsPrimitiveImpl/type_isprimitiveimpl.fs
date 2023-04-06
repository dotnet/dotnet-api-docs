// <Snippet1>
open System.Reflection

type MyTypeDelegatorClass(myType) =
    inherit TypeDelegator(myType)
    [<DefaultValue>]
    val mutable public myElementType : string
    // Override the IsPrimitiveImpl.
    override this.IsPrimitiveImpl() =
        // Determine whether the type is a primitive type.
        if myType.IsPrimitive then
            this.myElementType <- "primitive"
            true
        else
            false

try
    printfn "Determine whether int is a primitive type."
    let myType = MyTypeDelegatorClass typeof<int>
    // Determine whether int is a primitive type.
    if myType.IsPrimitive then
        printfn $"{typeof<int>} is a primitive type."
    else
        printfn $"{typeof<int>} is not a primitive type."
    printfn "\nDetermine whether string is a primitive type."
    let myType = MyTypeDelegatorClass typeof<string>
    // Determine if string is a primitive type.
    if myType.IsPrimitive then
        printfn $"{typeof<string>} is a primitive type."
    else
        printfn $"{typeof<string>} is not a primitive type."
with e ->
    printfn $"Exception: {e.Message}"
// </Snippet1>