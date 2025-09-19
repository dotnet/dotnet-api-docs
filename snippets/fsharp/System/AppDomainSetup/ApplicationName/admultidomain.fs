//  <SNIPPET1>
open System
open System.Reflection

type Worker() =
    inherit MarshalByRefObject()
    member internal _.TestLoad() =
        // You must supply a valid fully qualified assembly name here.
        Assembly.Load "Text assembly name, Culture, PublicKeyToken, Version" |> ignore
        for assem in AppDomain.CurrentDomain.GetAssemblies() do
            printfn $"{assem.FullName}"

// The following attribute indicates to loader that multiple application
// domains are used in this application.
[<LoaderOptimizationAttribute(LoaderOptimization.MultiDomainHost)>]
[<EntryPoint>]
let main _ =
    // Create application domain setup information for new application domain.
    let domaininfo = AppDomainSetup()
    domaininfo.ApplicationBase <- System.Environment.CurrentDirectory
    domaininfo.ApplicationName <- "MyMultiDomain Application"

    //Create evidence for the new appdomain from evidence of current application domain.
    let adevidence = AppDomain.CurrentDomain.Evidence

    // Create appdomain.
    let newDomain = AppDomain.CreateDomain("MyMultiDomain", adevidence, domaininfo)

    // Load an assembly into the new application domain.
    let w = 
        newDomain.CreateInstanceAndUnwrap(typeof<Worker>.Assembly.GetName().Name, "Worker" ) :?> Worker
    w.TestLoad()

    //Unload the application domain, which also unloads the assembly.
    AppDomain.Unload newDomain
    0
//  </SNIPPET1>