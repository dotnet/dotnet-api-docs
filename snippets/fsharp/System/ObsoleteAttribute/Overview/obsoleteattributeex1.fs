(*

// <Snippet1>
open System

// Mark oldValue As Obsolete.
[<ObsoleteAttribute("This value is obsolete. Use newValue instead.", false)>]
let oldValue =
    "The old property value."

let newValue =
    "The new property value."

// Mark callOldFunction As Obsolete.
[<ObsoleteAttribute("This function is obsolete. Call callNewFunction instead.", true)>]
let callOldFunction () =
    "You have called CallOldMethod."

let callNewFunction () =
    "You have called CallNewMethod."

printfn $"{oldValue}"
printfn ""
printfn $"{callOldFunction ()}"
// The attempt to compile this example produces output like the following output:
//    Example.fs(23,12): error FS0101: This construct is deprecated. This function is obsolete. Call callNewFunction instead.
//    Example.fs(21,12): warning FS0044: This construct is deprecated. This value is obsolete. Use newValue instead.
// </Snippet1>
*)
