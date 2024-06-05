module ca1

// <Snippet1>
open System
open System.Reflection

[<assembly: AssemblyTitle "CustAttrs1CS">]
[<assembly: AssemblyDescription "GetCustomAttributes() Demo">]
[<assembly: AssemblyCompany"Microsoft">]
do ()

type Example = class end

// Get the Assembly object to access its metadata.
let assembly = typeof<Example>.Assembly

// Iterate through the attributes for the assembly.
for attr in Attribute.GetCustomAttributes assembly do
    match attr with
    // Check for the AssemblyTitle attribute.
    | :? AssemblyTitleAttribute as attr ->    
        printfn $"Assembly title is \"{attr.Title}\"."
    // Check for the AssemblyDescription attribute.
    | :? AssemblyDescriptionAttribute as attr ->
        printfn $"Assembly description is \"{attr.Description}\"."
    // Check for the AssemblyCompany attribute.
    | :? AssemblyCompanyAttribute as attr ->
        printfn $"Assembly company is {attr.Company}."
    | _ -> ()
    
// The example displays the following output:
//     Assembly title is "CustAttrs1CS".
//     Assembly description is "GetCustomAttributes() Demo".
//     Assembly company is Microsoft.
// </Snippet1>