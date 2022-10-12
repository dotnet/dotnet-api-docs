// <Snippet1>
open System
open System.Reflection

// This sample class has a field, constructor, method, and property.
type MyType() =
    let mutable myField = 0

    member _.MyType(x: int byref) =
        x <- x * 5
    
    override _.ToString() =
        string myField
    
    member _.MyProp
        with get () = myField
        and set value =
            if value < 1 then
                raise (ArgumentOutOfRangeException("value", value, "value must be > 0"))
            myField <- value

let t = typeof<MyType>
// Create an instance of a type.
let args = Array.zeroCreate<obj> 8
printfn $"The value of x before the constructor is called is {args[0]}."
let obj = t.InvokeMember(null,
    BindingFlags.DeclaredOnly |||
    BindingFlags.Public ||| BindingFlags.NonPublic |||
    BindingFlags.Instance ||| BindingFlags.CreateInstance, null, null, args)
printfn $"Type: {obj.GetType()}"
printfn $"The value of x after the constructor returns is {args[0]}."

// Read and write to a field.
t.InvokeMember("myField",
    BindingFlags.DeclaredOnly |||
    BindingFlags.Public ||| BindingFlags.NonPublic |||
    BindingFlags.Instance ||| BindingFlags.SetField, null, obj, Array.zeroCreate<obj> 5) |> ignore
let v = t.InvokeMember("myField",
    BindingFlags.DeclaredOnly |||
    BindingFlags.Public ||| BindingFlags.NonPublic |||
    BindingFlags.Instance ||| BindingFlags.GetField, null, obj, null) :?> int
printfn $"myField: {v}"

// Call a method.
let s = t.InvokeMember("ToString",
    BindingFlags.DeclaredOnly |||
    BindingFlags.Public ||| BindingFlags.NonPublic |||
    BindingFlags.Instance ||| BindingFlags.InvokeMethod, null, obj, null) :?> string
printfn $"ToString: {s}"

// Read and write a property. First, attempt to assign an
// invalid value then assign a valid value finally, get
// the value.
try
    // Assign the value zero to MyProp. The Property Set
    // throws an exception, because zero is an invalid value.
    // InvokeMember catches the exception, and throws
    // TargetInvocationException. To discover the real cause
    // you must catch TargetInvocationException and examine
    // the inner exception.
    t.InvokeMember("MyProp",
        BindingFlags.DeclaredOnly |||
        BindingFlags.Public ||| BindingFlags.NonPublic |||
        BindingFlags.Instance ||| BindingFlags.SetProperty, null, obj, Array.zeroCreate<obj> 0) |> ignore
with :? TargetInvocationException as e ->
    // If the property assignment failed for some unexpected
    // reason, rethrow the TargetInvocationException.
    if e.InnerException.GetType() <> typeof<ArgumentOutOfRangeException> then
        reraise ()
    printfn "An invalid value was assigned to MyProp."
t.InvokeMember("MyProp",
    BindingFlags.DeclaredOnly |||
    BindingFlags.Public ||| BindingFlags.NonPublic |||
    BindingFlags.Instance ||| BindingFlags.SetProperty, null, obj, Array.zeroCreate<obj> 2) |> ignore
let v2 = t.InvokeMember("MyProp",
    BindingFlags.DeclaredOnly |||
    BindingFlags.Public ||| BindingFlags.NonPublic |||
    BindingFlags.Instance ||| BindingFlags.GetProperty, null, obj, null)
printfn $"MyProp: {v2}"
// </Snippet1>