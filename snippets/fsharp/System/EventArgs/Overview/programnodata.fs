module programnodata

// <snippet5>
open System

type Counter(threshold) =
    let mutable total = 0

    let thresholdReached = Event<_>()

    member this.Add(x) =
        total <- total + x
        if total >= threshold then
            thresholdReached.Trigger(this, EventArgs.Empty)

    [<CLIEvent>]
    member _.ThresholdReached = thresholdReached.Publish

let c_ThresholdReached(sender, arg) =
    printfn "The threshold was reached."
    exit 0

let c = Counter(Random().Next 10)
c.ThresholdReached.Add c_ThresholdReached

printfn "press 'a' key to increase total"
while Console.ReadKey(true).KeyChar = 'a' do
    printfn "adding one"
    c.Add 1

// </snippet5>