module ca5

// <Snippet5>
open System
open System.Reflection
open System.ComponentModel

type AClass() =
    member _.ParamArrayAndDesc(
        // Add ParamArray and Description attributes.
        [<Description "This argument is a ParamArray">]
        [<ParamArray>]
        args: int[]) = ()

// Get the Class type to access its metadata.
let clsType = typeof<AClass>

// Get the type information for the method.
let mInfo = clsType.GetMethod "ParamArrayAndDesc"
if mInfo <> null then
    // Get the parameter information.
    let pInfo = mInfo.GetParameters()
    if pInfo <> null then
        // Iterate through all the attributes for the parameter.
        for attr in Attribute.GetCustomAttributes pInfo[0] do
            match attr with 
            // Check for the ParamArray attribute.
            | :? ParamArrayAttribute ->
                printfn $"Parameter {pInfo[0].Name} for method {mInfo.Name} has the ParamArray attribute."
                                
            // Check for the Description attribute.
            | :? DescriptionAttribute as attr ->
                printfn $"Parameter {pInfo[0].Name} for method {mInfo.Name} has a description attribute."
                printfn $"The description is: \"{attr.Description}\""
            | _ -> ()

// Output:
// Parameter args for method ParamArrayAndDesc has a description attribute.
// The description is: "This argument is a ParamArray"
// Parameter args for method ParamArrayAndDesc has the ParamArray attribute.

// </Snippet5>
