module type_gettype

// <Snippet1>
open System

try
    // Get the type of a specified class.
    let myType1 = Type.GetType "System.Int32"
    printfn $"The full name is {myType1.FullName}.\n"
with :? TypeLoadException as e ->
    printfn $"{e.GetType().Name}: Unable to load type System.Int32"

try
    // Since NoneSuch does not exist in this assembly, GetType throws a TypeLoadException.
    let myType2 = Type.GetType("NoneSuch", true)
    printfn $"The full name is {myType2.FullName}."
with :? TypeLoadException as e ->
    printfn $"{e.GetType().Name}: Unable to load type NoneSuch"
// The example displays the following output:
//       The full name is System.Int32.
//
//       TypeLoadException: Unable to load type NoneSuch
// </Snippet1>
