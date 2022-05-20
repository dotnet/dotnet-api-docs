module docallback_byref

// <Snippet3>
open System
type PingPong() as this =
    inherit MarshalByRefObject()
    [<DefaultValue>]
    val mutable greetings: string
    do  
        this.greetings <- "PING!"

    // Callback will always execute within defaultDomain due to inheritance from MarshalByRefObject
    member this.MyCallBack() =
        let mutable name = AppDomain.CurrentDomain.FriendlyName
        if name = AppDomain.CurrentDomain.SetupInformation.ApplicationName then
            name <- "defaultDomain"
        printfn $"{this.greetings} from {name}"

let otherDomain = AppDomain.CreateDomain "otherDomain"

let pp = new PingPong()
pp.MyCallBack()
pp.greetings <- "PONG!"
otherDomain.DoCallBack(CrossAppDomainDelegate pp.MyCallBack)

// Output:
//   PING! from defaultDomain
//   PONG! from defaultDomain
// </Snippet3>