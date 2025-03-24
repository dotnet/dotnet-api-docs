module EqualsEx1

// <Snippet1>
open System
open System.Reflection

let isEqualTo (t: Type) (inst: obj) =
    match inst with
    | :? Type as t2 ->
        printfn $"{t.Name} = {t2.Name}: {t.Equals t2}\n"
    | _ ->
        printfn "Cannot cast the argument to a type.\n"

do 
    let t = typeof<int>
    typeof<int>.GetTypeInfo()
    |> isEqualTo t

    typeof<String>
    |> isEqualTo t

    let t = typeof<obj>
    typeof<obj>
    |> isEqualTo t

    let t = typeof<ResizeArray<_>>.GetGenericTypeDefinition()
    let obj4: obj = (ResizeArray<String>()).GetType()
    isEqualTo t obj4

    let t = typeof<Type>
    let obj5: obj = null
    isEqualTo t obj5
// The example displays the following output:
//       Int32 = Int32: True
//       
//       Int32 = String: False
//       
//       Object = Object: True
//       
//       List`1 = List`1: False
//       
//       Cannot cast the argument to a type.
// </Snippet1>