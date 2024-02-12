module Fullname5

// <Snippet5>
type Base<'T>() = class end

type Derived<'T>() = inherit Base<'T>()

let t = typeof<Derived<_>>.GetGenericTypeDefinition()
printfn $"Generic Class: {t.FullName}"
printfn $"   Contains Generic Paramters: {t.ContainsGenericParameters}"
printfn $"   Generic Type Definition: {t.IsGenericTypeDefinition}\n"

let baseType = t.BaseType
match baseType.FullName with
| null -> "(unassigned) " + string baseType
| _ -> baseType.FullName
|> printfn "Its Base Class: %s"

printfn $"   Contains Generic Paramters: {baseType.ContainsGenericParameters}"
printfn $"   Generic Type Definition: {baseType.IsGenericTypeDefinition}"
printfn $"   Full Name: {baseType.GetGenericTypeDefinition().FullName}\n"

let t2 = typeof<Base<_>>.GetGenericTypeDefinition()
printfn $"Generic Class: {t2.FullName}"
printfn $"   Contains Generic Paramters: {t2.ContainsGenericParameters}"
printfn $"   Generic Type Definition: {t2.IsGenericTypeDefinition}\n"                 
// The example displays the following output:
//       Generic Class: Derived`1
//          Contains Generic Paramters: True
//          Generic Type Definition: True
//       
//       Its Base Class: (unassigned) Base`1[T]
//          Contains Generic Paramters: True
//          Generic Type Definition: False
//          Full Name: Base`1
//       
//       Generic Class: Base`1
//          Contains Generic Paramters: True
//          Generic Type Definition: True
// </Snippet5>