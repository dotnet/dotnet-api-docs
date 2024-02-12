// <Snippet1>
open System.Reflection

type MyTypeDelegator(myType) =
    inherit TypeDelegator(myType)

    [<DefaultValue>]    
    val mutable public myElementType : string

    // Override IsArrayImpl().
    override this.IsArrayImpl() =
        // Determine whether the type is an array.
        if myType.IsArray then
            this.myElementType <- "array"
            true
        // Return false if the type is not an array.
        else false

try
    let myInt = 0 
    // Create an instance of an array element.
    let myArray = Array.zeroCreate<int> 5
    let myType = MyTypeDelegator(myArray.GetType())
    printfn "\nDetermine whether the variable is an array.\n"
    // Determine whether myType is an array type.
    if myType.IsArray then
        printfn $"The type of myArray is {myType.myElementType}."
    else
        printfn "myArray is not an array."
    let myType = MyTypeDelegator(myInt.GetType())

    // Determine whether myType is an array type.
    if myType.IsArray then
        printfn $"The type of myInt is {myType.myElementType}."
    else
        printfn "myInt is not an array."
with e ->
    printfn $"Exception: {e.Message}"
// </Snippet1>