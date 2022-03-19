//<snippet1>
open System
open System.Reflection

type App = class end

//<snippet2>
try
    // Attempt to call a static DoSomething method defined in the App class.
    // However, because the App class does not define this method,
    // a MissingMethodException is thrown.
    typeof<App>.InvokeMember("DoSomething", BindingFlags.Static ||| BindingFlags.InvokeMethod, null, null, null)
    |> ignore
with :? MissingMethodException as e ->
    // Show the user that the DoSomething method cannot be called.
    printfn $"Unable to call the DoSomething method: {e.Message}"
//</snippet2>

//<snippet3>
try
    // Attempt to access a static AField field defined in the App class.
    // However, because the App class does not define this field,
    // a MissingFieldException is thrown.
    typeof<App>.InvokeMember("AField", BindingFlags.Static ||| BindingFlags.SetField, null, null, [| box 5 |])
    |> ignore
with :? MissingFieldException as e ->
    // Show the user that the AField field cannot be accessed.
    printfn $"Unable to access the AField field: {e.Message}"
//</snippet3>

//<snippet4>
try
    // Attempt to access a static AnotherField field defined in the App class.
    // However, because the App class does not define this field,
    // a MissingFieldException is thrown.
    typeof<App>.InvokeMember("AnotherField", BindingFlags.Static ||| BindingFlags.GetField, null, null, null)
    |> ignore
with :? MissingMemberException as e ->
    // Notice that this code is catching MissingMemberException which is the
    // base class of MissingMethodException and MissingFieldException.
    // Show the user that the AnotherField field cannot be accessed.
    printfn $"Unable to access the AnotherField field: {e.Message}"
//</snippet4>
// This code example produces the following output:
//     Unable to call the DoSomething method: Method 'App.DoSomething' not found.
//     Unable to access the AField field: Field 'App.AField' not found.
//     Unable to access the AnotherField field: Field 'App.AnotherField' not found.
//</snippet1>