module source

//<Snippet1>
open System
open System.Collections.Generic

type Test() = class end

let displayGenericTypeInfo (t: Type) =
    printfn $"\n{t}"

    printfn $"\tIs this a generic type definition? {t.IsGenericTypeDefinition}"

    printfn "\tIs it a generic type? {t.IsGenericType}"

    //<Snippet2>
    if t.IsGenericType then
        // If this is a generic type, display the type arguments.
        let typeArguments = t.GetGenericArguments()

        printfn $"\tList type arguments ({typeArguments.Length}):" 

        for tParam in typeArguments do
            // If this is a type parameter, display its position.
            if tParam.IsGenericParameter then
                printfn $"\t\t{tParam}\t(unassigned - parameter position {tParam.GenericParameterPosition})"
            else
                printfn $"\t\t{tParam}"
    //</Snippet2>

printfn "\r\n--- Display information about a constructed type, its"
printfn "    generic type definition, and an ordinary type."

// Create a Dictionary of Test objects, using strings for the keys.       
let d = Dictionary<string, Test>()

// Display information for the constructed type and its generic
// type definition.
displayGenericTypeInfo (d.GetType())
displayGenericTypeInfo (d.GetType().GetGenericTypeDefinition())

// Display information for an ordinary type.
displayGenericTypeInfo typeof<string>

(* This example produces the following output:

--- Display information about a constructed type, its
    generic type definition, and an ordinary type.

System.Collections.Generic.Dictionary[System.String,Test]
        Is this a generic type definition? False
        Is it a generic type? True
        List type arguments (2):
                System.String
                Test

System.Collections.Generic.Dictionary[TKey,TValue]
        Is this a generic type definition? True
        Is it a generic type? True
        List type arguments (2):
                TKey    (unassigned - parameter position 0)
                TValue  (unassigned - parameter position 1)

System.String
        Is this a generic type definition? False
        Is it a generic type? False
 *)
//</Snippet1>