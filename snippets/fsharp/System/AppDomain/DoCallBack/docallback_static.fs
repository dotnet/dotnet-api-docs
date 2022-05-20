module docallback_static

// <Snippet1>
open System

let mutable greetings = "PONG!"

let myCallBack () =
    let mutable name = AppDomain.CurrentDomain.FriendlyName

    if name = AppDomain.CurrentDomain.SetupInformation.ApplicationName then
        name <- "defaultDomain"
    printfn $"{greetings} from {name}"

let otherDomain = AppDomain.CreateDomain "otherDomain"
greetings <- "PING!"
myCallBack ()
otherDomain.DoCallBack(CrossAppDomainDelegate myCallBack)

// Output:
//   PING! from defaultDomain
//   PONG! from otherDomain
// </Snippet1>