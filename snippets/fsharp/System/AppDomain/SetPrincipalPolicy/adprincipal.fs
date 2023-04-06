// <SNIPPET1>
open System
open System.Security.Principal
open System.Threading

let printPrincipalInformation () =
    let curPrincipal = Thread.CurrentPrincipal
    if curPrincipal <> null then
        printfn $"Type: {curPrincipal.GetType().Name}"
        printfn $"Name: {curPrincipal.Identity.Name}"
        printfn $"Authenticated: {curPrincipal.Identity.IsAuthenticated}\n"

[<EntryPoint>]
let main _ =
    // Create a new thread with a generic principal.
    let t = Thread(ThreadStart printPrincipalInformation)
    t.Start()
    t.Join()

    // Set the principal policy to WindowsPrincipal.
    let currentDomain = AppDomain.CurrentDomain
    currentDomain.SetPrincipalPolicy PrincipalPolicy.WindowsPrincipal
        
    // The new thread will have a Windows principal representing the
    // current user.
    let t = Thread(ThreadStart printPrincipalInformation)
    t.Start()
    t.Join()

    // Create a principal to use for new threads.
    let identity = GenericIdentity "NewUser"
    let principal = GenericPrincipal(identity, null)
    currentDomain.SetThreadPrincipal principal
        
    // Create a new thread with the principal created above.
    let t = Thread(ThreadStart printPrincipalInformation)
    t.Start()
    t.Join()

    // Wait for user input before terminating.
    Console.ReadLine() |> ignore
    0

// </SNIPPET1>