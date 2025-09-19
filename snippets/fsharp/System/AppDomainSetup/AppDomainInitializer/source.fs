//<Snippet1>
open System
open System.Security.Policy

// Get a reference to the default application domain.
let current = AppDomain.CurrentDomain

// Create the AppDomainSetup that will be used to set up the child
// AppDomain.
let ads = AppDomainSetup()

// Use the evidence from the default application domain to
// create evidence for the child application domain.
let ev = Evidence current.Evidence

// The callback function invoked when the child application domain is
// initialized. The function simply displays the arguments that were
// passed to it.
let appDomainInit args =
    printfn $"AppDomain \"{AppDomain.CurrentDomain.FriendlyName}\" is initialized with these arguments:"
    for arg in args do
        printfn $"    {arg}"

// Create an AppDomainInitializer delegate that represents the
// callback method, AppDomainInit. Assign this delegate to the
// AppDomainInitializer property of the AppDomainSetup object.
let adi = AppDomainInitializer appDomainInit
ads.AppDomainInitializer <- adi

// Create an array of strings to pass as arguments to the callback
// method. Assign the array to the AppDomainInitializerArguments
// property.
let initArgs = [| "String1"; "String2" |]
ads.AppDomainInitializerArguments <- initArgs

// Create a child application domain named "ChildDomain", using
// the evidence and the AppDomainSetup object.
let ad = AppDomain.CreateDomain("ChildDomain", ev, ads)

printfn "Press the Enter key to exit the example program."
stdin.ReadLine() |> ignore

(* This code example produces the following output:

AppDomain "ChildDomain" is initialized with these arguments:
    String1
    String2
 *)
//</Snippet1>