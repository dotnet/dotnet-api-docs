module source

//<Snippet1>
open System
open System.Collections.Generic

type Test() = class end

let displayTypeInfo (t: Type) =
    printfn $"\r\n{t}"

    printfn $"\tIs this a generic type definition? {t.IsGenericTypeDefinition}" 

    printfn $"\tIs it a generic type? {t.IsGenericType}"

    let typeArguments = t.GetGenericArguments()
    printfn $"\tList type arguments ({typeArguments.Length}):"
    for tParam in typeArguments do
        printfn $"\t\t{tParam}"

printfn "\r\n--- Create a constructed type from the generic Dictionary type."

// Create a type object representing the generic Dictionary 
// type, by calling .GetGenericTypeDefinition().
let generic = typeof<Dictionary<_,_>>.GetGenericTypeDefinition()
displayTypeInfo generic

// Create an array of types to substitute for the type
// parameters of Dictionary. The key is of type string, and
// the type to be contained in the Dictionary is Test.
let typeArgs = [| typeof<string>; typeof<Test> |]

// Create a Type object representing the constructed generic type.
let constructed = generic.MakeGenericType typeArgs
displayTypeInfo constructed

(* This example produces the following output:

--- Create a constructed type from the generic Dictionary type.

System.Collections.Generic.Dictionary`2[TKey,TValue]
        Is this a generic type definition? True
        Is it a generic type? True
        List type arguments (2):
                TKey
                TValue

System.Collections.Generic.Dictionary`2[System.String, Test]
        Is this a generic type definition? False
        Is it a generic type? True
        List type arguments (2):
                System.String
                Test
 *)
//</Snippet1>