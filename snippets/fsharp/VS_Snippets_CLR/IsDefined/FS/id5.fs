module id5

//<Snippet5>
open System;

type TestClass() =
    // Assign a ParamArray attribute to the parameter.
    member _.Method1([<ParamArray>] args: string[]) = ()

// Get the class type to access its metadata.
let clsType = typeof<TestClass>

// Get the MethodInfo object for Method1.
let mInfo = clsType.GetMethod "Method1"

// Get the ParameterInfo array for the method parameters.
let pInfo = mInfo.GetParameters()

if pInfo <> null then
    // See if the ParamArray attribute is defined.
    let isDef = Attribute.IsDefined(pInfo[0], typeof<ParamArrayAttribute>)

    // Display the result.
    printfn $"""The ParamArray attribute {if isDef then "is" else "is not"} defined for parameter {pInfo[0].Name} of method {mInfo.Name}."""
else
    printfn $"The parameters information could not be retrieved for method {mInfo.Name}."

// Output:
//  The ParamArray attribute is defined for parameter args of method Method1.

//</Snippet5>