open System

// Define a custom parameter attribute that takes a single message argument.
[<AttributeUsage(AttributeTargets.Parameter)>]
type ArgumentUsageAttribute(usageMsg) =
    inherit Attribute()

    // Override ToString() to append the message to what the base generates.
    override _.ToString() =
        $"%s{base.ToString()}: %s{usageMsg}"

// Define a custom parameter attribute that generates a GUID for each instance.
[<AttributeUsage(AttributeTargets.Parameter)>]
type ArgumentIDAttribute() =
    inherit Attribute()

    let instanceGUID = Guid.NewGuid()

    // Override ToString() to append the GUID to what the base generates.
    override _.ToString() =
        $"%s{base.ToString()}: %O{instanceGUID}"
        
type TestClass() =
    // Assign an ArgumentID attribute to each parameter.
    // Assign an ArgumentUsage attribute to each parameter.
    member _.TestMethod(
        [<ArgumentID>]
        [<ArgumentUsage "Must pass an array here.">]
        strArray: string [],
        [<ArgumentID>]
        [<ArgumentUsage "Can pass param list or array here.">]
        [<ParamArray>] 
        strList: string []) = ()

// Create Attribute objects and compare them.
        
// Get the class type, and then get the MethodInfo object
// for TestMethod to access its metadata.
let clsType = typeof<TestClass>
let mInfo = clsType.GetMethod "TestMethod"

// There will be two elements in pInfoArray, one for each parameter.
let pInfoArray = mInfo.GetParameters()
if pInfoArray <> null then
    // Create an instance of the argument usage attribute on strArray.
    let arrayUsageAttr1 =
        Attribute.GetCustomAttribute(pInfoArray[0], typeof<ArgumentUsageAttribute>)
        :?> ArgumentUsageAttribute

    // Create another instance of the argument usage attribute on strArray.
    let arrayUsageAttr2 =
        Attribute.GetCustomAttribute(pInfoArray[0], typeof<ArgumentUsageAttribute>)
        :?> ArgumentUsageAttribute

    // Create an instance of the argument usage attribute on strList.
    let listUsageAttr =
        Attribute.GetCustomAttribute(pInfoArray[1], typeof<ArgumentUsageAttribute>)
        :?> ArgumentUsageAttribute

    // Create an instance of the argument ID attribute on strArray.
    let arrayIDAttr1 =
        Attribute.GetCustomAttribute(pInfoArray[0], typeof<ArgumentIDAttribute>)
        :?> ArgumentIDAttribute

    // Create another instance of the argument ID attribute on strArray.
    let arrayIDAttr2 =
        Attribute.GetCustomAttribute(pInfoArray[0], typeof<ArgumentIDAttribute>)
        :?> ArgumentIDAttribute

    // Create an instance of the argument ID attribute on strList.
    let listIDAttr =
        Attribute.GetCustomAttribute(pInfoArray[1], typeof<ArgumentIDAttribute>)
        :?> ArgumentIDAttribute

    // Compare various pairs of attributes for equality.
    printfn "\nCompare a usage attribute instance to another instance of the same attribute:"
    printfn $"   \"{arrayUsageAttr1}\" == \n   \"{arrayUsageAttr2}\"? {arrayUsageAttr1.Equals( arrayUsageAttr2)}"

    printfn "\nCompare a usage attribute to another usage attribute:"
    printfn $"   \"{arrayUsageAttr1}\" == \n   \"{listUsageAttr}\"? {arrayUsageAttr1.Equals(listUsageAttr)}"

    printfn "\nCompare an ID attribute instance to another instance of the same attribute:"
    printfn $"   \"{ arrayIDAttr1}\" == \n   \"{arrayIDAttr2}\"? {arrayIDAttr1.Equals(arrayIDAttr2)}"

    printfn "\nCompare an ID attribute to another ID attribute:"
    printfn $"   \"{arrayIDAttr1}\" == \n   \"{listIDAttr}\"? {arrayIDAttr1.Equals(listIDAttr)}"
else
    printfn $"The parameters information could not be retrieved for method {mInfo.Name}."

// The example displays an output similar to the following:
//         Compare a usage attribute instance to another instance of the same attribute:
//            "ArgumentUsageAttribute: Must pass an array here." ==
//            "ArgumentUsageAttribute: Must pass an array here."? True
//
//         Compare a usage attribute to another usage attribute:
//            "ArgumentUsageAttribute: Must pass an array here." ==
//            "ArgumentUsageAttribute: Can pass param list or array here."? False
//
//         Compare an ID attribute instance to another instance of the same attribute:
//            "ArgumentIDAttribute.22d1a176-4aca-427b-8230-0c1563e13187" ==
//            "ArgumentIDAttribute.7fa94bba-c290-48e1-a0de-e22f6c1e64f1"? False
//
//         Compare an ID attribute to another ID attribute:
//            "ArgumentIDAttribute.22d1a176-4aca-427b-8230-0c1563e13187" ==
//            "ArgumentIDAttribute.b9eea70d-9c0f-459e-a984-19c46b6c8789"? False