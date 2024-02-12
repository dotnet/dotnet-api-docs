namespace global 

// <Snippet8>
open System

type LocationReporter(name) =
    let mutable unsubscriber = Unchecked.defaultof<IDisposable>

    member _.Name = name

    member this.Subscribe(provider: IObservable<Location>) =
        if provider <> null then
            unsubscriber <- provider.Subscribe this

    member _.Unsubscribe() =
        unsubscriber.Dispose()

    interface IObserver<Location> with
        // <Snippet11>
        member this.OnCompleted() =
            printfn $"The Location Tracker has completed transmitting data to {name}."
            this.Unsubscribe()
        // </Snippet11>

        // <Snippet10>
        member _.OnError(_) =
            printfn $"{name}: The location cannot be determined."
        // </Snippet10>

        // <Snippet12>
        member _.OnNext(value) =
            printfn $"{name}: The current location is {value.Latitude}, {value.Longitude}"
        // </Snippet12>

// </Snippet8>