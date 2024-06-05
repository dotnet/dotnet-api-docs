//<Snippet1>
open System
open System.Reflection
open System.Collections.Generic

// Define a base class with two type parameters.
type Base<'T, 'U>() = class end

// Define a derived class. The derived class inherits from a constructed
// class that meets the following criteria:
//   (1) Its generic type definition is Base<T, U>.
//   (2) It specifies int for the first type parameter.
//   (3) For the second type parameter, it uses the same type that is used
//       for the type parameter of the derived class.
// Thus, the derived class is a generic type with one type parameter, but
// its base class is an open constructed type with one type argument and
// one type parameter.
type Derived<'V>() = inherit Base<int, 'V>()

let displayGenericTypeInfo (t: Type) =
    printfn $"\n{t}"
    printfn $"\tIs this a generic type definition? {t.IsGenericTypeDefinition}"
    printfn $"\tIs it a generic type? {t.IsGenericType}"
    printfn $"\tDoes it have unassigned generic parameters? {t.ContainsGenericParameters}"

    if t.IsGenericType then
        // If this is a generic type, display the type arguments.
        let typeArguments = t.GetGenericArguments()

        printfn $"\tList type arguments ({typeArguments.Length}):"

        for tParam in typeArguments do
            // IsGenericParameter is true only for generic type
            // parameters.
            if tParam.IsGenericParameter then
                printfn $"\t\t{tParam}  (unassigned - parameter position {tParam.GenericParameterPosition})"
            else
                printfn $"\t\t{tParam}"

printfn $"\r\n--- Display a generic type and the open constructed"
printfn $"    type from which it is derived."

// Create a Type object representing the generic type definition 
// for the Derived type, by omitting the type argument. (For
// types with multiple type parameters, supply the commas but
// omit the type arguments.) 
//
let derivedType = (typeof<Derived<_>>).GetGenericTypeDefinition()
displayGenericTypeInfo derivedType

// Display its open constructed base type.
displayGenericTypeInfo derivedType.BaseType

(* This example produces the following output:

--- Display a generic type and the open constructed
    type from which it is derived.

Derived`1[V]
        Is this a generic type definition? True
        Is it a generic type? True
        Does it have unassigned generic parameters? True
        List type arguments (1):
                V  (unassigned - parameter position 0)

Base`2[System.Int32,V]
        Is this a generic type definition? False
        Is it a generic type? True
        Does it have unassigned generic parameters? True
        List type arguments (2):
                System.Int32
                V  (unassigned - parameter position 0)
 *)
//</Snippet1>