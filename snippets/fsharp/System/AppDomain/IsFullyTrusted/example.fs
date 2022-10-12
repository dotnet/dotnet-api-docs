//<Snippet1>
open System
open System.IO
open System.Security
open System.Security.Policy

type Worker() =
    inherit MarshalByRefObject()
    member _.TestIsFullyTrusted() =
        let ad = AppDomain.CurrentDomain
        printfn $"\nApplication domain '{ad.FriendlyName}': IsFullyTrusted = {ad.IsFullyTrusted}"

        printfn $"   IsFullyTrusted = {typeof<Worker>.Assembly.IsFullyTrusted} for the current assembly"

        printfn $"   IsFullyTrusted = {typeof<int>.Assembly.IsFullyTrusted} for mscorlib"

// ------------ Helper function ---------------------------------------
let getInternetSandbox () =
    // Create the permission set to grant to all assemblies.
    let hostEvidence = Evidence()
    hostEvidence.AddHostEvidence(Zone System.Security.SecurityZone.Internet)
    let pset = SecurityManager.GetStandardSandbox hostEvidence

    // Identify the folder to use for the sandbox.
    let ads = AppDomainSetup()
    ads.ApplicationBase <- Directory.GetCurrentDirectory()

    // Create the sandboxed application domain.
    AppDomain.CreateDomain("Sandbox", hostEvidence, ads, pset, null)

let w = Worker()
w.TestIsFullyTrusted()

let adSandbox = getInternetSandbox()
let w2 = 
    adSandbox.CreateInstanceAndUnwrap(typeof<Worker>.Assembly.FullName, typeof<Worker>.FullName) :?> Worker
w2.TestIsFullyTrusted()
(* This example produces output similar to the following:

Application domain 'Example.exe': IsFullyTrusted = True
   IsFullyTrusted = True for the current assembly
   IsFullyTrusted = True for mscorlib

Application domain 'Sandbox': IsFullyTrusted = False
   IsFullyTrusted = False for the current assembly
   IsFullyTrusted = True for mscorlib
 *)
//</Snippet1>