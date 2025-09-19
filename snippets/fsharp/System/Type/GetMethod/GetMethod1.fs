module GetMethod1

// <Snippet1>
open System
open System.Collections

let getAddMethod (typ: Type) = 
    let method = 
        // Determine if this is a generic type.
        if typ.IsGenericType then
            // Is it an open generic type?
            if typ.ContainsGenericParameters then
                typ.GetMethod("Add", typ.GetGenericArguments())
            // Get closed generic type arguments.
            else
                typ.GetMethod("Add", typ.GenericTypeArguments)
        // This is not a generic type.
        else
            typ.GetMethod("Add", [| typeof<obj> |])

    // Test if an Add method was found.
    if method = null then
        printfn "No Add method found."
    else
        let t = method.ReflectedType
        printf $"{t.Namespace}.{t.Name}.{method.Name}("
        let parms = method.GetParameters()
        for i = 0 to parms.Length - 1 do
            printf $"""{parms[i].ParameterType.Name}{if i < parms.Length - 1 then ", " else ""}"""
        printfn ")"

// Get a Type object that represents a non-generic type.
getAddMethod typeof<ArrayList>

let list = ResizeArray<String>()
// Get a Type object that represents a constructed generic type.
let closed = list.GetType()
getAddMethod closed

// Get a Type object that represents an open generic type.
let opn = typeof<ResizeArray<_>>.GetGenericTypeDefinition()
getAddMethod opn

// The example displays the following output:
//       System.Collections.ArrayList.Add(Object)
//       System.Collections.Generic.List`1.Add(String)
//       System.Collections.Generic.List`1.Add(T)
// </Snippet1>