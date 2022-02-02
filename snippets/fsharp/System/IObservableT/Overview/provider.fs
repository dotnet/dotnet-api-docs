namespace global

open System

// <Snippet5>
[<Struct>]
type Location =
    { Latitude: double
      Longitude: double }
// </Snippet5>

// <Snippet7>
exception LocationUnknownException
// </Snippet7>

// <Snippet6>
type Unsubscriber(observers: ResizeArray<IObserver<Location>>, observer: IObserver<Location>) =
    interface IDisposable with
        member _.Dispose() =
            if observer <> null && observers.Contains observer then
                observers.Remove observer |> ignore

type LocationTracker() =
    // <Snippet13>
    let observers = ResizeArray<IObserver<Location>>()

    interface IObservable<Location> with
        member _.Subscribe(observer) =
            if observers.Contains observer |> not then
                observers.Add observer
            new Unsubscriber(observers, observer)

    // </Snippet13>
    member _.TrackLocation(loc: Nullable<Location>) =
        for observer in observers do
            if not loc.HasValue then
                observer.OnError LocationUnknownException
            else
                observer.OnNext loc.Value

    member _.EndTransmission() =
        for observer in observers.ToArray() do
            if observers.Contains observer then
                observer.OnCompleted()
        observers.Clear()
// </Snippet6>