module Example

// <Snippet1>
open System

type Example() =
    // Mark OldProperty As Obsolete.
    [<ObsoleteAttribute("This property is obsolete. Use NewProperty instead.", false)>]
    member _.OldProperty =
        "The old property value."

    member _.NewProperty =
        "The new property value."

    // Mark OldMethod As Obsolete.
    [<ObsoleteAttribute("This method is obsolete. Call NewMethod instead.", true)>]
    member _.OldMethod() =
        "You have called OldMethod."

    member _.NewMethod() =
        "You have called NewMethod."

// Get all public members of this type.
let members = typeof<Example>.GetMembers()
// Count total obsolete members.
let mutable n = 0

// Try to get the ObsoleteAttribute for each public member.
printfn "Obsolete members in the Example class:\n"
for m in members do
    let attribs = m.GetCustomAttributes(typeof<ObsoleteAttribute>, false) |> box :?> ObsoleteAttribute[]
    if attribs.Length > 0 then
        let attrib = attribs[0]
        printfn $"Member Name: {m.DeclaringType.FullName}.{m.Name}"
        printfn $"   Message: {attrib.Message}"
        printfn $"""   Warning/Error: {if attrib.IsError then "Error" else "Warning"}"""
        n <- n + 1

if n = 0 then
    printfn "The Example type has no obsolete attributes."
// The example displays the following output:
//       Obsolete members in the Example class:
//
//       Member Name: Example+Example.OldMethod
//          Message: This method is obsolete. Call NewMethod instead.
//          Warning/Error: Error
//       Member Name: Example+Example.OldProperty
//          Message: This property is obsolete. Use NewProperty instead.
//          Warning/Error: Warning
// </Snippet1>