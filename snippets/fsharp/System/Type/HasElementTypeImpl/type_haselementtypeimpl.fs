// <Snippet1>
open System.Reflection

type MyTypeDelegator(myType) =
    inherit TypeDelegator(myType)
    
    [<DefaultValue>]
    val mutable public myElementType: string
    
    // Override Type.HasElementTypeImpl().
    override this.HasElementTypeImpl() =
        // Determine whether the type is an array.
        if myType.IsArray then
            this.myElementType <- "array"
            true
        // Determine whether the type is a reference.
        elif myType.IsByRef then
            this.myElementType <- "reference"
            true
        // Determine whether the type is a pointer.
        elif myType.IsPointer then
            this.myElementType <- "pointer"
            true
        // Return false if the type is not a reference, array, or pointer type.
        else false

try
    let myInt = 0 
    let myArray = Array.zeroCreate<int> 5
    let myType = MyTypeDelegator(myArray.GetType())
    // Determine whether myType is an array, pointer, reference type.
    printfn "\nDetermine whether a variable is an array, pointer, or reference type.\n"
    if myType.HasElementType then
        printfn $"The type of myArray is {myType.myElementType}."
    else
        printfn "myArray is not an array, pointer, or reference type."
    let myType = MyTypeDelegator(myInt.GetType())
    // Determine whether myType is an array, pointer, reference type.
    if myType.HasElementType then
        printfn $"The type of myInt is {myType.myElementType}."
    else
        printfn "myInt is not an array, pointer, or reference type."
with e ->
    printfn $"Exception: {e.Message}"
// </Snippet1>