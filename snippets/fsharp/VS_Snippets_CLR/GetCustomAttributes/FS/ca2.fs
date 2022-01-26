module ca2

// <Snippet2>
open System
open System.ComponentModel

// Assign some attributes to the module.
[<``module``: Description "A sample description">]

// Set the module's CLSCompliant attribute to false
// The CLSCompliant attribute is applicable for /target:module.
[<``module``: CLSCompliant false>]
do ()

type DemoClass = class end

// Get the Module type to access its metadata.
let ilmodule = typeof<DemoClass>.Module

// Iterate through all the attributes for the module.
for attr in Attribute.GetCustomAttributes ilmodule do
    match attr with
    // Check for the Description attribute.
    | :? DescriptionAttribute as attr ->
        printfn $"Module {ilmodule.Name} has the description \"{attr.Description}\"."
                
    // Check for the CLSCompliant attribute.
    | :? CLSCompliantAttribute as attr ->
        printfn $"""Module {ilmodule.Name} {if attr.IsCompliant then "is" else "is not"} CLSCompliant."""
    | _ -> ()
    
// Output:
// Module CustAttrs2CS.exe is not CLSCompliant.
// Module CustAttrs2CS.exe has the description "A sample description".

// </Snippet2>