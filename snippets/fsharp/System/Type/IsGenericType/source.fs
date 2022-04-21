//<Snippet1>
open System

type Base<'T, 'U>() = class end

type G<'T>() = class end

type Derived<'V>() =
    inherit Base<string, 'V>()
    
    [<DefaultValue>]
    val mutable public F : G<Derived<'V>>

let displayGenericType (t: Type) caption =
    printfn $"\n{caption}"
    printfn $"    Type: {t}"

    printfn $"\t            IsGenericType: {t.IsGenericType}" 
    printfn $"\t  IsGenericTypeDefinition: {t.IsGenericTypeDefinition}" 
    printfn $"\tContainsGenericParameters: {t.ContainsGenericParameters}"
    printfn $"\t       IsGenericParameter: {t.IsGenericParameter}"

// Get the generic type definition for Derived, and the base
// type for Derived.
let tDerived = typeof<Derived<_>>.GetGenericTypeDefinition()
let tDerivedBase = tDerived.BaseType

// Declare an array of Derived<int>, and get its type.
let d = Array.zeroCreate<Derived<int>> 0
let tDerivedArray = d.GetType()

// Get a generic type parameter, the type of a field, and a
// type that is nested in Derived. Notice that in order to
// get the nested type it is necessary to either (1) specify
// the generic type definition Derived<>, as shown here,
// or (2) specify a type parameter for Derived.
let tT = typeof<Base<_,_>>.GetGenericTypeDefinition().GetGenericArguments()[0]
let tF = tDerived.GetField("F").FieldType

displayGenericType tDerived "Derived<V>"
displayGenericType tDerivedBase "Base type of Derived<V>"
displayGenericType tDerivedArray "Array of Derived<int>"
displayGenericType tT "Type parameter T from Base<T>"
displayGenericType tF "Field type, G<Derived<V>>"

(* This code example produces the following output:

Derived<V>
    Type: Derived`1[V]
                    IsGenericType: True
          IsGenericTypeDefinition: True
        ContainsGenericParameters: True
               IsGenericParameter: False

Base type of Derived<V>
    Type: Base`2[System.String,V]
                    IsGenericType: True
          IsGenericTypeDefinition: False
        ContainsGenericParameters: True
               IsGenericParameter: False

Array of Derived<int>
    Type: Derived`1[System.Int32][]
                    IsGenericType: False
          IsGenericTypeDefinition: False
        ContainsGenericParameters: False
               IsGenericParameter: False

Type parameter T from Base<T>
    Type: T
                    IsGenericType: False
          IsGenericTypeDefinition: False
        ContainsGenericParameters: True
               IsGenericParameter: True

Field type, G<Derived<V>>
    Type: G`1[Derived`1[V]]
                    IsGenericType: True
          IsGenericTypeDefinition: False
        ContainsGenericParameters: True
               IsGenericParameter: False
 *)
//</Snippet1>