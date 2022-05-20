// <Snippet1>
open System
open System.Runtime.InteropServices

[<ComVisible true>]
type MyComVisibleType() =
    do
        printfn "MyComVisibleType instantiated!"

[<ComVisible false>]
type MyComNonVisibleType() =
    do
        printfn "MyComNonVisibleType instantiated!"

let createComInstance typeName =
    try
        let currentDomain = AppDomain.CurrentDomain
        let assemblyName = currentDomain.FriendlyName
        currentDomain.CreateComInstanceFrom(assemblyName, typeName)
        |> ignore
    with e ->
        printfn $"{e.Message}"

createComInstance "MyComNonVisibleType"   // Fail!
createComInstance "MyComVisibleType"      // OK!

// </Snippet1>