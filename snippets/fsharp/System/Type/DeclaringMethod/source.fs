//<Snippet1>
open System.Reflection

//<Snippet2>
// Define a class with a generic method.
type Example =
    static member Generic<'T>(toDisplay: 'T) =
        printfn $"\r\nHere it is: {toDisplay}"
//</Snippet2>

let displayGenericMethodInfo (mi: MethodInfo) =
    printfn $"\n{mi}"

    //<Snippet5>
    printfn $"\tIs this a generic method definition? {mi.IsGenericMethodDefinition}"
    //</Snippet5>

    //<Snippet6>
    printfn $"\tIs it a generic method? {mi.IsGenericMethod}"
    //</Snippet6>

    //<Snippet7>
    printfn $"\tDoes it have unassigned generic parameters? {mi.ContainsGenericParameters}"
    //</Snippet7>

    //<Snippet8>
    // If this is a generic method, display its type arguments.
    //
    if mi.IsGenericMethod then
        let typeArguments = mi.GetGenericArguments()

        printfn $"\tList type arguments ({typeArguments.Length}):"

        for tParam in typeArguments do
            // IsGenericParameter is true only for generic type
            // parameters.
            if tParam.IsGenericParameter then
                printfn $"\t\t{tParam}  parameter position {tParam.GenericParameterPosition}\n\t\t   declaring method: {tParam.DeclaringMethod}"
            else
                printfn $"\t\t{tParam}"
    //</Snippet8>

printfn "\r\n--- Examine a generic method."

//<Snippet3>
// Create a Type object representing class Example, and
// get a MethodInfo representing the generic method.
//
let ex = typeof<Example>
let mi = ex.GetMethod "Generic"

displayGenericMethodInfo mi

// Assign the int type to the type parameter of the Example
// method.
//
let miConstructed = mi.MakeGenericMethod typeof<int>

displayGenericMethodInfo miConstructed
//</Snippet3>

// Invoke the method.
let args = [| box 42 |]
miConstructed.Invoke(null, args) |> ignore

// Invoke the method normally.
Example.Generic<int> 42

//<Snippet4>
// Get the generic type definition from the closed method,
// and show it's the same as the original definition.
//
let miDef = miConstructed.GetGenericMethodDefinition()
printfn $"\r\nThe definition is the same: {miDef = mi}"
//</Snippet4>

(* This example produces the following output:

--- Examine a generic method.

Void Generic[T](T)
        Is this a generic method definition? True
        Is it a generic method? True
        Does it have unassigned generic parameters? True
        List type arguments (1):
                T  parameter position 0
                   declaring method: Void Generic[T](T)

Void Generic[Int32](Int32)
        Is this a generic method definition? False
        Is it a generic method? True
        Does it have unassigned generic parameters? False
        List type arguments (1):
                System.Int32

Here it is: 42

Here it is: 42

The definition is the same: True

 *)
//</Snippet1>