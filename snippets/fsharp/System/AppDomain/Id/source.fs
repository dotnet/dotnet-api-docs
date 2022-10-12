//<Snippet1>
open System

// This method has the same signature as the CrossAppDomainDelegate,
// so that it can be executed easily in the new application domain.
let showDomainInfo () =
    let ad = AppDomain.CurrentDomain
    printfn $"\nFriendlyName: {ad.FriendlyName}"
    printfn $"Id: {ad.Id}"
    printfn $"IsDefaultAppDomain: {ad.IsDefaultAppDomain()}"

// The following attribute indicates to the loader that assemblies
// in the global assembly cache should be shared across multiple
// application domains.
[<LoaderOptimizationAttribute(LoaderOptimization.MultiDomainHost)>]
[<EntryPoint>]
let main _ =
    // Show information for the default application domain.
    showDomainInfo ()

    // Create a new application domain and display its information.
    let newDomain = AppDomain.CreateDomain "MyMultiDomain"
    newDomain.DoCallBack(CrossAppDomainDelegate showDomainInfo)
    0
//</Snippet1>