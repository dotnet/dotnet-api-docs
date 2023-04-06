module getcustattrprminh

//<Snippet3>
open System
open System.Reflection

// Define a custom parameter attribute that takes a single message argument.
[<AttributeUsage(AttributeTargets.Parameter); AllowNullLiteral>]
type ArgumentUsageAttribute(usageMsg) =
    inherit Attribute()

    // This is the Message property for the attribute.
    member val Message: string = usageMsg

type BaseClass() =
    // Assign an ArgumentUsage attribute to the strArray parameter.
    // Assign a ParamArray attribute to strList.
    abstract member TestMethod: string [] * string[] -> unit
    default _.TestMethod(
        [<ArgumentUsage "Must pass an array here.">]
        strArray,
        [<ParamArray>]
        strList) = ()

type DerivedClass() =
    inherit BaseClass()
    // Assign an ArgumentUsage attribute to the strList parameter.
    // Assign a ParamArray attribute to strList.
    override _.TestMethod(
        strArray,
        [<ArgumentUsage "Can pass a parameter list or array here."; ParamArray>]
        strList) = ()

let displayParameterAttributes (mInfo: MethodInfo) (pInfoArray: ParameterInfo []) includeInherited =
    printfn $"""
Parameter attribute information for method "{mInfo.Name}"
includes inheritance from base class: {if includeInherited then "Yes" else "No"}."""

    // Display the attribute information for the parameters.
    for paramInfo in pInfoArray do
        // See if the ParamArray attribute is defined.
        let isDef = Attribute.IsDefined(paramInfo, typeof<ParamArrayAttribute>)

        if isDef then
            printfn $"\n    The ParamArray attribute is defined for \n    parameter {paramInfo.Name} of method {mInfo.Name}."

        // See if ParamUsageAttribute is defined.
        // If so, display a message.
        let usageAttr =
            Attribute.GetCustomAttribute(paramInfo, typeof<ArgumentUsageAttribute>, includeInherited)
            :?> ArgumentUsageAttribute

        if usageAttr <> null then
            printfn $"\n    The ArgumentUsage attribute is defined for \n    parameter {paramInfo.Name} of method {mInfo.Name}." 
            printfn $"\n        The usage message for {paramInfo.Name} is:\n        \"{usageAttr.Message}\"."

printfn "This example of Attribute.GetCustomAttribute(ParameterInfo, Type, Boolean)\ngenerates the following output."

// Get the class type, and then get the MethodInfo object
// for TestMethod to access its metadata.
let clsType = typeof<DerivedClass>
let mInfo = clsType.GetMethod "TestMethod"

// Iterate through the ParameterInfo array for the method parameters.
let pInfoArray = mInfo.GetParameters()
if pInfoArray <> null then
    displayParameterAttributes mInfo pInfoArray false
    displayParameterAttributes mInfo pInfoArray true
else
    printfn $"The parameters information could not be retrieved for method {mInfo.Name}."


// This example of Attribute.GetCustomAttribute( ParameterInfo, Type, Boolean )
// generates the following output.
// 
// Parameter attribute information for method "TestMethod"
// includes inheritance from base class: No.
// 
//     The ParamArray attribute is defined for
//     parameter strList of method TestMethod.
// 
//     The ArgumentUsage attribute is defined for
//     parameter strList of method TestMethod.
// 
//         The usage message for strList is:
//         "Can pass a parameter list or array here.".
// 
// Parameter attribute information for method "TestMethod"
// includes inheritance from base class: Yes.
// 
//     The ArgumentUsage attribute is defined for
//     parameter strArray of method TestMethod.
// 
//         The usage message for strArray is:
//         "Must pass an array here.".
// 
//     The ParamArray attribute is defined for
//     parameter strList of method TestMethod.
// 
//     The ArgumentUsage attribute is defined for
//     parameter strList of method TestMethod.
// 
//         The usage message for strList is:
//         "Can pass a parameter list or array here.".

//</Snippet3>