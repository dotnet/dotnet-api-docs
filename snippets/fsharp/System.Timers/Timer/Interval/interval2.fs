// What is the resolution of the system clock?

// <Snippet1>
open System
open System.IO
open System.Timers

let aTimer = new Timer 5
let eventlog = ResizeArray()
let mutable nEventsFired = 0
let mutable previousTime = DateTime()
       
let onTimedEvent source (e: ElapsedEventArgs) =
    String.Format("Elapsed event at {0:HH':'mm':'ss.ffffff} ({1})", e.SignalTime, if nEventsFired = 0 then 0. else (e.SignalTime - previousTime).TotalMilliseconds)
    |> eventlog.Add
    nEventsFired <- nEventsFired + 1

    previousTime <- e.SignalTime

    if nEventsFired = 20 then
        printfn "No more events will fire..."
        aTimer.Enabled <- false

[<EntryPoint>]
let main _ =
    use sr = new StreamWriter(@".\Interval.txt")
    // Create a timer with a five millisecond interval.
    aTimer.Elapsed.AddHandler onTimedEvent
    // Hook up the Elapsed event for the timer. 
    aTimer.AutoReset <- true
    sr.WriteLine $"The timer should fire every {aTimer.Interval} milliseconds."
    aTimer.Enabled <- true

    printfn "Press the Enter key to exit the program... "
    stdin.ReadLine() |> ignore
    for item in eventlog do
        sr.WriteLine item
    printfn "Terminating the application..."
    0

// The example writes output like the following to a file:
//       The timer should fire every 5 milliseconds.
//       Elapsed event at 08:42:49.370344 (0)
//       Elapsed event at 08:42:49.385345 (15.0015)
//       Elapsed event at 08:42:49.400347 (15.0015)
//       Elapsed event at 08:42:49.415348 (15.0015)
//       Elapsed event at 08:42:49.430350 (15.0015)
//       Elapsed event at 08:42:49.445351 (15.0015)
//       Elapsed event at 08:42:49.465353 (20.002)
//       Elapsed event at 08:42:49.480355 (15.0015)
//       Elapsed event at 08:42:49.495356 (15.0015)
//       Elapsed event at 08:42:49.510358 (15.0015)
//       Elapsed event at 08:42:49.525359 (15.0015)
//       Elapsed event at 08:42:49.540361 (15.0015)
//       Elapsed event at 08:42:49.555362 (15.0015)
//       Elapsed event at 08:42:49.570364 (15.0015)
//       Elapsed event at 08:42:49.585365 (15.0015)
//       Elapsed event at 08:42:49.605367 (20.002)
//       Elapsed event at 08:42:49.620369 (15.0015)
//       Elapsed event at 08:42:49.635370 (15.0015)
//       Elapsed event at 08:42:49.650372 (15.0015)
//       Elapsed event at 08:42:49.665373 (15.0015)
// </Snippet1>