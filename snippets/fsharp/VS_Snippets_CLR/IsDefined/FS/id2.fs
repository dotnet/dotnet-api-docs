module id2

//<Snippet2>
open System
open System.Diagnostics

// Add the Debuggable attribute to the module.
[<``module``: Debuggable(true, false)>]
do ()
    
type DemoClass = class end

// Get the class type to access its metadata.
let clsType = typeof<DemoClass>

// See if the Debuggable attribute is defined for this module.
let isDef = Attribute.IsDefined(clsType.Module, typeof<DebuggableAttribute>)

// Display the result.
printfn $"""The Debuggable attribute {if isDef then "is" else "is not"} defined for Module {clsType.Module.Name}."""

// If the attribute is defined, display the JIT settings.
if isDef then
    // Retrieve the attribute itself.
    let dbgAttr =
        Attribute.GetCustomAttribute(clsType.Module, typeof<DebuggableAttribute>)
        :?> DebuggableAttribute

    if dbgAttr <> null then
        printfn $"JITTrackingEnabled is {dbgAttr.IsJITTrackingEnabled}."
        printfn $"JITOptimizerDisabled is {dbgAttr.IsJITOptimizerDisabled}."            
    else
        printfn "The Debuggable attribute could not be retrieved."

// Output:
//  The Debuggable attribute is defined for Module IsDef2CS.exe.
//  JITTrackingEnabled is True.
//  JITOptimizerDisabled is False.

//</Snippet2>