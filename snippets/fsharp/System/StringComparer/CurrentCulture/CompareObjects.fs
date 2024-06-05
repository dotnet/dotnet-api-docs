open System

// <Snippet1>
let compareCurrentCultureStringComparer () =
    let stringComparer1 = StringComparer.CurrentCulture
    let stringComparer2 = StringComparer.CurrentCulture
    // Displays false
    printfn $"{StringComparer.ReferenceEquals(stringComparer1, stringComparer2)}"
// </Snippet1>

// <Snippet2>
let compareCurrentCultureInsensitiveStringComparer () =
    let stringComparer1 = StringComparer.CurrentCultureIgnoreCase
    let stringComparer2 = StringComparer.CurrentCultureIgnoreCase
    // Displays false
    printfn $"{StringComparer.ReferenceEquals(stringComparer1, stringComparer2)}"
// </Snippet2>
compareCurrentCultureStringComparer()
compareCurrentCultureInsensitiveStringComparer()