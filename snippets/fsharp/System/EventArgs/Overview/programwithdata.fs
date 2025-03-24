module programwithdata

// <snippet6>
open System

type ThresholdReachedEventArgs(threshold, timeReached) =
    inherit EventArgs()
    member _.Threshold = threshold
    member _.TimeReached = timeReached

type Counter(threshold) =
    let mutable total = 0

    let thresholdReached = Event<_>()

    member this.Add(x) =
        total <- total + x
        if total >= threshold then
            let args = ThresholdReachedEventArgs(threshold, DateTime.Now)
            thresholdReached.Trigger(this, args)

    [<CLIEvent>]
    member _.ThresholdReached = thresholdReached.Publish

let c_ThresholdReached(sender, e: ThresholdReachedEventArgs) =
    printfn $"The threshold of {e.Threshold} was reached at {e.TimeReached}."
    exit 0

let c = Counter(Random().Next 10)
c.ThresholdReached.Add c_ThresholdReached

printfn "press 'a' key to increase total"
while Console.ReadKey(true).KeyChar = 'a' do
    printfn "adding one"
    c.Add 1
// </snippet6>