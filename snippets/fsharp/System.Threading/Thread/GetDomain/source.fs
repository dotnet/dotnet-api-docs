// <Snippet1>
open System
open System.Threading

let threadMethod () =
    printfn $"Thread {AppDomain.GetCurrentThreadId()} started in {Thread.GetDomain().FriendlyName} with AppDomainID = {Thread.GetDomainID()}."

let newThread = Thread threadMethod
newThread.Start()
// </Snippet1>
