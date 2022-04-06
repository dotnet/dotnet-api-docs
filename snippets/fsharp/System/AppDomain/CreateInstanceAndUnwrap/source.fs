module source

//<Snippet1>
open System
open System.Reflection

type Worker() =
    inherit MarshalByRefObject()
    member _.PrintDomain() =
        printfn $"Object is executing in AppDomain \"{AppDomain.CurrentDomain.FriendlyName}\""

// Create an ordinary instance in the current AppDomain
let localWorker = Worker()
localWorker.PrintDomain()

// Create a new application domain, create an instance
// of Worker in the application domain, and execute code
// there.
let ad = AppDomain.CreateDomain "New domain"
let remoteWorker = 
    ad.CreateInstanceAndUnwrap(typeof<Worker>.Assembly.FullName, "Worker") :?> Worker
remoteWorker.PrintDomain()

// This code produces output similar to the following:
//     Object is executing in AppDomain "source.exe"
//     Object is executing in AppDomain "New domain"
//</Snippet1>