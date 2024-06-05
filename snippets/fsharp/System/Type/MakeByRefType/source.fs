//<Snippet1>
type Example() =
    // A sample method with a ByRef parameter.
    member _.Test(e: Example byref) = ()

do
    // Create a Type object that represents a one-dimensional
    // array of Example objects.
    let t = typeof<Example>.MakeArrayType()
    printfn $"\r\nArray of Example: {t}"

    // Create a Type object that represents a two-dimensional
    // array of Example objects.
    let t = typeof<Example>.MakeArrayType 2
    printfn $"\r\nTwo-dimensional array of Example: {t}"

    // Demonstrate an exception when an invalid array rank is
    // specified.
    try
        let t = typeof<Example>.MakeArrayType -1
        ()
    with ex ->
        printfn $"\r\n{ex}"

    // Create a Type object that represents a ByRef parameter
    // of type Example.
    let t = typeof<Example>.MakeByRefType()
    printfn $"\r\nByRef Example: {t}"

    // Get a Type object representing the Example class, a
    // MethodInfo representing the "Test" method, a ParameterInfo
    // representing the parameter of type Example, and finally
    // a Type object representing the type of this ByRef parameter.
    // Compare this Type object with the Type object created using
    // MakeByRefType.
    let t2 = typeof<Example>
    let mi = t2.GetMethod "Test"
    let pi = mi.GetParameters()[0]
    let pt = pi.ParameterType
    printfn $"Are the ByRef types equal? {t = pt}"

    // Create a Type object that represents a pointer to an
    // Example object.
    let t = typeof<Example>.MakePointerType()
    printfn $"\r\nPointer to Example: {t}"

(* This example produces output similar to the following:

Array of Example: Example[]

Two-dimensional array of Example: Example[,]

System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at System.RuntimeType.MakeArrayType(Int32 rank) in c:\vbl\ndp\clr\src\BCL\System\RtType.cs:line 2999
   at Example.Main()

ByRef Example: Example&
Are the ByRef types equal? True

Pointer to Example: Example*
 *)
//</Snippet1>