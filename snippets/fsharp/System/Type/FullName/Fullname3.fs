module Fullname3x

// <Snippet3>
open System

let t = typeof<Nullable<_>>.GetGenericTypeDefinition()
printfn $"{t.FullName}"
if t.IsGenericType then
    printf "   Generic Type Parameters: "
    let gtArgs = t.GetGenericArguments()
    for arg in gtArgs do
        match arg.FullName with
        | null -> "(unassigned) " + string arg
        | _ -> arg.FullName
        |> printfn "%s"
    printfn ""
// The example displays the following output:
//       System.Nullable`1
//          Generic Type Parameters: (unassigned) T
// </Snippet3>