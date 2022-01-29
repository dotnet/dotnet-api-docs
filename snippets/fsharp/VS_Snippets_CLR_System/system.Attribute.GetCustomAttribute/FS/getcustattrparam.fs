module getcustattrparam

//<Snippet1>
open System
open System.Reflection

//<Snippet2>
// Define a custom parameter attribute that takes a single message argument.
[<AttributeUsage(AttributeTargets.Parameter); AllowNullLiteral>]
type ArgumentUsageAttribute(usageMsg) =
    inherit Attribute()
    
    // This is the Message property for the attribute.
    member val Message = usageMsg with get, set
//</Snippet2>

type BaseClass() =
    // Assign an ArgumentUsage attribute to the strArray parameter.
    // Assign a ParamArray attribute to strList.
    abstract member TestMethod: strArray: string[] * strList: string[] -> unit
    default _.TestMethod([<ArgumentUsage("Must pass an array here.")>] strArray, [<ParamArray>] strList) = ()

type DerivedClass() =
    inherit BaseClass()
    
    // Assign an ArgumentUsage attribute to the strList parameter.
    // Assign a ParamArray attribute to strList.
    override _.TestMethod(
        strArray,
        [<ArgumentUsage "Can pass a parameter list or array here."; ParamArray>] 
        strList) = ()

printfn "This example of Attribute.GetCustomAttribute( ParameterInfo, Type )\ngenerates the following output."

// Get the class type, and then get the MethodInfo object
// for TestMethod to access its metadata.
let clsType = typeof<DerivedClass>
let mInfo = clsType.GetMethod "TestMethod"

// Iterate through the ParameterInfo array for the method parameters.
let pInfoArray = mInfo.GetParameters()
if pInfoArray <> null then
    for paramInfo in pInfoArray do
        // See if the ParamArray attribute is defined.
        let isDef = Attribute.IsDefined(paramInfo, typeof<ParamArrayAttribute>)

        if isDef then
            printfn $"\nThe ParamArray attribute is defined for \nparameter {paramInfo.Name} of method {mInfo.Name}."

        // See if ParamUsageAttribute is defined.
        // If so, display a message.
        let usageAttr =
            Attribute.GetCustomAttribute(paramInfo, typeof<ArgumentUsageAttribute>)
            :?> ArgumentUsageAttribute

        if usageAttr <> null then
            printfn $"\nThe ArgumentUsage attribute is defined for \nparameter {paramInfo.Name} of method {mInfo.Name}."
            printfn $"\n    The usage message for {paramInfo.Name} is:\n    \"{usageAttr.Message}\"."   
else
    printfn $"The parameters information could not be retrieved for method {mInfo.Name}."


// This example of Attribute.GetCustomAttribute(ParameterInfo, Type)
// generates the following output:
// The ArgumentUsage attribute is defined for
// parameter strArray of method TestMethod.
//
//     The usage message for strArray is:
//     "Must pass an array here.".
//
// The ParamArray attribute is defined for
// parameter strList of method TestMethod.
//
// The ArgumentUsage attribute is defined for
// parameter strList of method TestMethod.
//
//     The usage message for strList is:
//     "Can pass a parameter list or array here.".

//</Snippet1>