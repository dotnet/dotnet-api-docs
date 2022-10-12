module docallbackbyval

// <Snippet2>
open System

[<Serializable>]
type PingPong() as this =
    [<DefaultValue>]
    val mutable greetings: string
    do  
        this.greetings <- "PING!"

    member _.MyCallBack() =
        let mutable name = AppDomain.CurrentDomain.FriendlyName

        if name = AppDomain.CurrentDomain.SetupInformation.ApplicationName then
            name <- "defaultDomain"
        printfn $"{this.greetings} from {name}"

let otherDomain = AppDomain.CreateDomain "otherDomain"

let pp = PingPong()
pp.MyCallBack()
pp.greetings <- "PONG!"
otherDomain.DoCallBack(CrossAppDomainDelegate pp.MyCallBack)

// Output:
//   PING! from defaultDomain
//   PONG! from otherDomain
// </Snippet2>