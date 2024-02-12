open System
open System.Reflection

// <Snippet1>
type MyType() =
    do
        printfn "\nMyType instantiated!"

let instantiateMyTypeFail (domain: AppDomain) =
    // Calling InstantiateMyType will always fail since the assembly info
    // given to CreateInstance is invalid.
    try
        // You must supply a valid fully qualified assembly name here.
        domain.CreateInstance("Assembly text name, Version, Culture, PublicKeyToken", "MyType")
        |> ignore
    with e ->
        printfn $"\n{e.Message}"

let instantiateMyTypeSucceed (domain: AppDomain) =
    try
        let asmname = Assembly.GetCallingAssembly().FullName
        domain.CreateInstance(asmname, "MyType")
        |> ignore
    with e ->
        printfn $"\n{e.Message}"

let myResolveEventHandler _ _ =
    printfn "Resolving..."
    typeof<MyType>.Assembly


let currentDomain = AppDomain.CurrentDomain

// This call will fail to create an instance of MyType since the
// assembly resolver is not set
instantiateMyTypeFail currentDomain

currentDomain.add_AssemblyResolve (ResolveEventHandler myResolveEventHandler)

// This call will succeed in creating an instance of MyType since the
// assembly resolver is now set.
instantiateMyTypeFail currentDomain

// This call will succeed in creating an instance of MyType since the
// assembly name is valid.
instantiateMyTypeSucceed currentDomain

// </Snippet1>