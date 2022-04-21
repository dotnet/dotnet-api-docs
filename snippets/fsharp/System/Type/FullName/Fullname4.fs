module Fullname4

// <Snippet4>
open System.Reflection

type GenericType1<'T>() = 
    member _.Display(elements: 'T[]) = ()  
    member _.HandleT(obj: 'T) = ()
    member _.ChangeValue(arg: 'T byref) = true

let t = typeof<GenericType1<_>>.GetGenericTypeDefinition()

printfn $"Type Name: {t.FullName}"

let methods = 
    t.GetMethods(BindingFlags.Instance ||| BindingFlags.DeclaredOnly ||| BindingFlags.Public)

for method in methods do
    printfn $"   Method: {method.Name}"
    // Get method parameters.
    let param = method.GetParameters()[0]
    let paramType = param.ParameterType
    if method.Name = "HandleT" then
        let paramType = paramType.MakePointerType()
        match paramType.FullName with
        | null -> string paramType + " (unassigned)"
        | _ -> paramType.FullName
        |> printfn "      Parameter: %s" 
// The example displays the following output:
//       Type Name: GenericType1`1
//          Method: Display
//             Parameter: T[] (unassigned))
//          Method: HandleT
//             Parameter: T* (unassigned)
//          Method: ChangeValue
//             Parameter: T& (unassigned)
// </Snippet4>