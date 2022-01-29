//<Snippet1>
module NDP_UE_FS

open System

// Define a custom parameter attribute that takes a single message argument.
[<AttributeUsage(AttributeTargets.Parameter)>]
type ArgumentUsageAttribute(usageMsg) =
    inherit Attribute()
    
    let instanceGUID = Guid.NewGuid()
    
    // This is the Message property for the attribute.
    member val Message = usageMsg with get, set

    // Override TypeId to provide a unique identifier for the instance.
    override _.TypeId with get() =
        box instanceGUID

    // Override ToString() to append the message to what the base generates.
    override _.ToString() =
        base.ToString() + ":" + usageMsg

type TestClass() =
    // Assign an ArgumentUsage attribute to each parameter.
    // Assign a ParamArray attribute to strList using the params keyword.
    member _.TestMethod(
        [<ArgumentUsage "Must pass an array here.">]
        strArray: string [],
        [<ArgumentUsage "Can pass a param list or array here."; ParamArray>]
        strList: string []) = ()

let showAttributeTypeIds () =
    // Get the class type, and then get the MethodInfo object
    // for TestMethod to access its metadata.
    let clsType = typeof<TestClass>
    let mInfo = clsType.GetMethod "TestMethod"

    // There will be two elements in pInfoArray, one for each parameter.
    let pInfoArray = mInfo.GetParameters()
    if pInfoArray <> null then
        // Create an instance of the param array attribute on strList.
        let listArrayAttr =
            Attribute.GetCustomAttribute(pInfoArray[1], typeof<ParamArrayAttribute>)
            :?> ParamArrayAttribute

        // Create an instance of the argument usage attribute on strArray.
        let arrayUsageAttr1 =
            Attribute.GetCustomAttribute(pInfoArray[0], typeof<ArgumentUsageAttribute>)
            :?> ArgumentUsageAttribute

        // Create another instance of the argument usage attribute
        // on strArray.
        let arrayUsageAttr2 =
            Attribute.GetCustomAttribute(pInfoArray[0], typeof<ArgumentUsageAttribute>)
            :?> ArgumentUsageAttribute

        // Create an instance of the argument usage attribute on strList.
        let listUsageAttr =
            Attribute.GetCustomAttribute(pInfoArray[1], typeof<ArgumentUsageAttribute>)
            :?> ArgumentUsageAttribute

        // Display the attributes and corresponding TypeId values.
        printfn $"\n\"{listArrayAttr}\" \nTypeId: {listArrayAttr.TypeId}"

        printfn $"\n\"{arrayUsageAttr1}\" \nTypeId: {arrayUsageAttr1.TypeId}"
        printfn $"\n\"{arrayUsageAttr2}\" \nTypeId: {arrayUsageAttr2.TypeId}"
        printfn $"\n\"{listUsageAttr}\" \nTypeId: {listUsageAttr.TypeId}"
    else
        printfn $"The parameters information could not be retrieved for method {mInfo.Name}."

printfn "This example of the Attribute.TypeId property\ngenerates the following output."
printfn "\nCreate instances from a derived Attribute class that implements TypeId, \nand then display the attributes and corresponding TypeId values:"

showAttributeTypeIds ()

// This example of the Attribute.TypeId property
// generates output similar to the following:
//
// Create instances from a derived Attribute class that implements TypeId,
// and then display the attributes and corresponding TypeId values:
//
// "System.ParamArrayAttribute"
// TypeId: System.ParamArrayAttribute
//
// "NDP_UE_FS+ArgumentUsageAttribute:Must pass an array here."
// TypeId: d03a23f4-2536-4478-920f-8b0426dec7f1
//
// "NDP_UE_FS+ArgumentUsageAttribute:Must pass an array here."
// TypeId: a1b412e8-3047-49fa-8d03-7660d37ef718
//
// "NDP_UE_FS+ArgumentUsageAttribute:Can pass a param list or array here."
// TypeId: 7ac2bf61-0327-48d6-a07e-eb9aaf3dd45e

//</Snippet1>
