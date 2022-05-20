module id4

//<Snippet4>
open System

type TestClass() =
    // Assign the Obsolete attribute to a method.
    [<Obsolete "This method is obsolete. Use Method2 instead.">]
    member _.Method1() = ()
    member _.Method2() = ()

// Get the class type to access its metadata.
let clsType = typeof<TestClass>

// Get the MethodInfo object for Method1.
let mInfo = clsType.GetMethod "Method1"

// See if the Obsolete attribute is defined for this method.
let isDef = Attribute.IsDefined(mInfo, typeof<ObsoleteAttribute>)

// Display the result.
printfn $"""The Obsolete Attribute {if isDef then "is" else "is not"} defined for {mInfo.Name} of class {clsType.Name}."""

// If it's defined, display the attribute's message.
if isDef then
    let obsAttr =
        Attribute.GetCustomAttribute(mInfo, typeof<ObsoleteAttribute>)
        :?> ObsoleteAttribute
    if obsAttr <> null then
        printfn $"The message is: \"{obsAttr.Message}\"."
    else
        printfn "The message could not be retrieved."

// Output:
//  The Obsolete Attribute is defined for Method1 of class TestClass.
// The message is: "This method is obsolete. Use Method2 instead.".

//</Snippet4>