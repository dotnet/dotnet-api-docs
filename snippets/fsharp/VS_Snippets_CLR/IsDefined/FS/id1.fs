module id1

//<Snippet1>
open System
open System.Reflection

// Add an AssemblyDescription attribute
[<assembly: AssemblyDescription "A sample description">]
do ()

type DemoClass = class end

// Get the class type to access its metadata.
let clsType = typeof<DemoClass>

// Get the assembly object.
let assembly = clsType.Assembly;

// Store the assembly's name.
let assemblyName = assembly.GetName().Name

// See if the Assembly Description is defined.
let isdef = 
    Attribute.IsDefined(assembly, typeof<AssemblyDescriptionAttribute>)

if isdef then
    // Affirm that the attribute is defined.
    printfn $"The AssemblyDescription attribute is defined for assembly {assemblyName}."
    
    // Get the description attribute itself.
    let adAttr =
        Attribute.GetCustomAttribute(assembly, typeof<AssemblyDescriptionAttribute>)
        :?> AssemblyDescriptionAttribute

    // Display the description.
    if adAttr <> null then
        printfn $"The description is \"{adAttr.Description}\"."
    else
        printfn $"The description could not be retrieved."
else
    printfn $"The AssemblyDescription attribute is not defined for assembly {assemblyName}."

// Output:
//  The AssemblyDescription attribute is defined for assembly IsDef1FS.
//  The description is "A sample description".

//</Snippet1>
