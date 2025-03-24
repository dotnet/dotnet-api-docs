//<Snippet1>
open System
open System.Collections.Generic

type Test() = class end

let displayTypeInfo (t: Type) =
    printfn $"\n{t}"
    printfn $"\tIs this a generic type definition? {t.IsGenericTypeDefinition}"
    printfn $"\tIs it a generic type? {t.IsGenericType}"
    let typeArguments = t.GetGenericArguments()
    printfn $"\tList type arguments ({typeArguments.Length}):"
    for tParam in typeArguments do
        printfn $"\t\t{tParam}"

printfn "\n--- Get the generic type that defines a constructed type."

// Create a Dictionary of Test objects, using strings for the keys.
let d = Dictionary<string, Test>()

// Get a Type object representing the constructed type.
let constructed = d.GetType()
displayTypeInfo constructed

let generic = constructed.GetGenericTypeDefinition()
displayTypeInfo generic


(* This example produces the following output:

--- Get the generic type that defines a constructed type.

System.Collections.Generic.Dictionary`2[System.String,Test]
        Is this a generic type definition? False
        Is it a generic type? True
        List type arguments (2):
                System.String
                Test

System.Collections.Generic.Dictionary`2[TKey,TValue]
        Is this a generic type definition? True
        Is it a generic type? True
        List type arguments (2):
                TKey
                TValue
 *)
//</Snippet1>