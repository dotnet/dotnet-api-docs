// <Snippet1>
#nowarn "9"
open FSharp.NativeInterop

type Example() =
    // This method is for demonstration purposes.
    member _.Test(x: int byref, y: int outref, z: int nativeptr) =
        x <- 0
        y <- 0
        NativePtr.write z 0

// All of the following display 'True'.

do
    // Define an array, get its type, and display HasElementType.
    let nums = [| 1; 1; 2; 3; 5; 8; 13 |]
    let t = nums.GetType()
    printfn $"HasElementType is '{t.HasElementType}' for array types."

    // Test an array type without defining an array.
    let t = typeof<Example[]>
    printfn $"HasElementType is '{t.HasElementType}' for array types."

    // When you use Reflection Emit to emit dynamic methods and
    // assemblies, you can create array types using MakeArrayType.
    // The following creates the type 'array of Example'.
    let t = typeof<Example>.MakeArrayType()
    printfn $"HasElementType is '{t.HasElementType}' for array types."

    // When you reflect over methods, HasElementType is true for
    // byref, outref, and pointer parameter types. The following
    // gets the Test method, defined above, and examines its
    // parameters.
    let mi = typeof<Example>.GetMethod "Test"
    let parms = mi.GetParameters()
    let t = parms[0].ParameterType
    printfn $"HasElementType is '{t.HasElementType}' for ref parameter types."
    let t = parms[1].ParameterType
    printfn $"HasElementType is '{t.HasElementType}' for out parameter types."
    let t = parms[2].ParameterType
    printfn $"HasElementType is '{t.HasElementType}' for pointer parameter types."

    // When you use Reflection Emit to emit dynamic methods and
    // assemblies, you can create pointer and ByRef types to use
    // when you define method parameters.
    let t = typeof<Example>.MakePointerType()
    printfn $"HasElementType is '{t.HasElementType}' for pointer types."
    let t = typeof<Example>.MakeByRefType()
    printfn $"HasElementType is '{t.HasElementType}' for ByRef types."
// </Snippet1>