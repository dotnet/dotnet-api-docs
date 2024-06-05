// <Snippet1>
open System.Reflection

type MyClass() =
    let myField = "A sample private field." 

try
    let myObject = MyClass()
    // Get the type of the 'MyClass'.
    let myType = typeof<MyClass>
    // Get the field information and the attributes associated with MyClass.
    let myFieldInfo = myType.GetField("myField", BindingFlags.NonPublic ||| BindingFlags.Instance)
    printfn "\nChecking for the AnsiClass attribute for a field.\n"
    // Get and display the name, field, and the AnsiClass attribute.
    printfn $"Name of Class: {myType.FullName} \nValue of Field: {myFieldInfo.GetValue myObject} \nIsAnsiClass = {myType.IsAnsiClass}"
with e ->
    printfn $"Exception: {e.Message}"
// </Snippet1>