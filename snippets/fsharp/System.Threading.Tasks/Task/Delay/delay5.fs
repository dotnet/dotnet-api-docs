module delay5

open System.Diagnostics
open System.Threading.Tasks

let delayAtStart () =
    // <Snippet5>
    let sw = Stopwatch.StartNew()

    let delay =
        Task
            .Delay(1000)
            .ContinueWith(fun _ ->
                sw.Stop()
                sw.ElapsedMilliseconds)

    printfn $"Elapsed milliseconds: {delay.Result}"
// The example displays output like the following:
//        Elapsed milliseconds: 1013
// </Snippet5>


let delayDuring () =
    // <Snippet6>
    let delay =
        Task.Run(fun () ->
            let sw = Stopwatch.StartNew()
            Task.Delay(2000).Wait()
            sw.Stop()
            sw.ElapsedMilliseconds)

    printfn $"Elapsed milliseconds: {delay.Result}"
// The example displays output like the following:
//        Elapsed milliseconds: 2006
// </Snippet6>


let delayDuringLang () =
    // <Snippet7>
    let delay =
        Task.Run<int64>(fun () ->
            task {
                let sw = Stopwatch.StartNew()
                do! Task.Delay 2500
                sw.Stop()
                return sw.ElapsedMilliseconds
            })

    printfn $"Elapsed milliseconds: {delay.Result}"
// The example displays output like the following:
//        Elapsed milliseconds: 2501
// </Snippet7>


delayAtStart ()
printfn "---"
delayDuring ()
printfn "---"
delayDuringLang ()
