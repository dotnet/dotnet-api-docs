module continuewith1
// <Snippet1>
open System
open System.Threading.Tasks

let firstTask =
    Task.Factory.StartNew(fun () ->
        let rnd = Random()
        let dates = Array.zeroCreate 100
        let buffer = Array.zeroCreate 8
        let mutable i = dates.GetLowerBound 0

        while i <= dates.GetUpperBound 0 do
            rnd.NextBytes buffer
            let ticks = BitConverter.ToInt64(buffer, 0)

            if ticks > DateTime.MinValue.Ticks && ticks < DateTime.MaxValue.Ticks then
                dates[i] <- DateTime ticks
                i <- i + 1

        dates)

let continuationTask =
    firstTask.ContinueWith(
        Action<Task<DateTime[]>>(fun antecedent ->
            let dates: DateTime[] = antecedent.Result
            let mutable earliest = dates[0]
            let mutable latest = earliest

            for i = dates.GetLowerBound 0 + 1 to dates.GetUpperBound 0 do
                if dates.[i] < earliest then
                    earliest <- dates.[i]

                if dates.[i] > latest then
                    latest <- dates.[i]

            printfn $"Earliest date: {earliest}"
            printfn $"Latest date: {latest}")
    )
// Since a console application otherwise terminates, wait for the continuation to complete.
continuationTask.Wait()


// The example displays output like the following:
//       Earliest date: 2/11/0110 12:03:41 PM
//       Latest date: 7/29/9989 2:14:49 PM
// </Snippet1>
