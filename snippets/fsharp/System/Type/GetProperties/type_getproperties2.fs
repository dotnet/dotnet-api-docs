module type_getproperties2

// <Snippet1>
open System.Reflection

// Create a class having four properties.
type PropertyClass() =
    member _.Property1 = 
        "hello"

    member _.Property2 = 
        "hello"

    member private _.Property3 = 
        32

    member internal _.Property4 =
       "value"

let getVisibility (accessor: MethodInfo) =
    if accessor.IsPublic then
        "Public"
    elif accessor.IsPrivate then
        "Private"
    elif accessor.IsFamily then
        "Protected"
    elif accessor.IsAssembly then
        "Internal/Friend"
    else
        "Protected Internal/Friend"

let displayPropertyInfo (propInfos: #seq<PropertyInfo>) = 
    // Display information for all properties.
    for propInfo in propInfos do
        let readable = propInfo.CanRead
        let writable = propInfo.CanWrite

        printfn $"   Property name: {propInfo.Name}"
        printfn $"   Property type: {propInfo.PropertyType}"
        printfn $"   Read-Write:    {readable && writable}"
        if readable then
            let getAccessor = propInfo.GetMethod
            printfn $"   Visibility:    {getVisibility getAccessor}"
        if writable then
            let setAccessor = propInfo.SetMethod
            printfn $"   Visibility:    {getVisibility setAccessor}"
        printfn ""

let t = typeof<PropertyClass>
// Get the public properties.
let propInfos = t.GetProperties(BindingFlags.Public ||| BindingFlags.Instance)
printfn $"The number of public properties: {propInfos.Length}.\n"
// Display the public properties.
displayPropertyInfo propInfos

// Get the nonpublic properties.
let propInfos1 = t.GetProperties(BindingFlags.NonPublic ||| BindingFlags.Instance)
printfn $"The number of non-public properties: {propInfos1.Length}.\n"
// Display all the nonpublic properties.
displayPropertyInfo propInfos1

// The example displays the following output:
//       The number of public properties: 2.
//
//          Property name: Property1
//          Property type: System.String
//          Read-Write:    False
//          Visibility:    Public
//
//          Property name: Property2
//          Property type: System.String
//          Read-Write:    False
//          Visibility:    Public
//
//       The number of non-public properties: 2.
//
//          Property name: Property3
//          Property type: System.Int32
//          Read-Write:    False
//          Visibility:    Private
//
//          Property name: Property4
//          Property type: System.String
//          Read-Write:    False
//          Visibility:    Internal/Friend
// </Snippet1>