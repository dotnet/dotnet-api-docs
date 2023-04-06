// Alternative to using SignalTime to ensure that Elapsed
// events are not processed if they occur after the timer
// has been stopped. The object is to avoid race conditions.
//<Snippet1>
open System
open System.Threading

// Change these values to control the behavior of the program.
let testRuns = 100
// Times are given in milliseconds:
let testRunsFor = 500
let timerIntervalBase = 100
let timerIntervalDelta = 20

// Timers.
let timer1 = new Timers.Timer()
let timer2 = new Timers.Timer()
let mutable currentTimer = Unchecked.defaultof<Timers.Timer>

let rand = Random()

// This is the synchronization point that prevents events
// from running concurrently, and prevents the main thread
// from executing code after the Stop method until any
// event handlers are done executing.
let mutable syncPoint = 0

// Count the number of times the event handler is called,
// is executed, is skipped, or is called after Stop.
let mutable numEvents = 0
let mutable numExecuted = 0
let mutable numSkipped = 0
let mutable numLate = 0

// Count the number of times the thread that calls Stop
// has to wait for an Elapsed event to finish.
let mutable numWaits = 0

let controlThreadProc () =
    // Allow the timer to run for a period of time, and then
    // stop it.
    Thread.Sleep testRunsFor
    currentTimer.Stop()

    // The 'counted' flag ensures that if this thread has
    // to wait for an event to finish, the wait only gets
    // counted once.
    let mutable counted = false

    // Ensure that if an event is currently executing,
    // no further processing is done on this thread until
    // the event handler is finished. This is accomplished
    // by using CompareExchange to place -1 in syncPoint,
    // but only if syncPoint is currently zero (specified
    // by the third parameter of CompareExchange).
    // CompareExchange returns the original value that was
    // in syncPoint. If it was not zero, then there's an
    // event handler running, and it is necessary to try
    // again.
    while Interlocked.CompareExchange(&syncPoint, -1, 0) <> 0 do
        // Give up the rest of this thread's current time
        // slice. This is a naive algorithm for yielding.
        Thread.Sleep 1

        // Tally a wait, but don't count multiple calls to
        // Thread.Sleep.
        if not counted then
            numWaits <- numWaits + 1
            counted <- true

// Any processing done after this point does not conflict
// with timer events. This is the purpose of the call to
// CompareExchange. If the processing done here would not
// cause a problem when run concurrently with timer events,
// then there is no need for the extra synchronization.

let testRun () =
    // Set syncPoint to zero before starting the test
    // run.
    syncPoint <- 0

    // Test runs alternate between Timer1 and Timer2, to avoid
    // race conditions between tests, or with very late events.
    if currentTimer = timer1 then
        currentTimer <- timer2
    else
        currentTimer <- timer1

    currentTimer.Interval <-
        timerIntervalBase - timerIntervalDelta + (timerIntervalDelta * 2 |> rand.Next)
        |> float

    currentTimer.Enabled <- true

    // Start the control thread that shuts off the timer.
    let t = new Thread(ThreadStart controlThreadProc)
    t.Start()

    // Wait until the control thread is done before proceeding.
    // This keeps the test runs from overlapping.
    t.Join()

let handleElapsed sender e =
    numEvents <- numEvents + 1

    // This example assumes that overlapping events can be
    // discarded. That is, if an Elapsed event is raised before
    // the previous event is finished processing, the second
    // event is ignored.
    //
    // CompareExchange is used to take control of syncPoint,
    // and to determine whether the attempt was successful.
    // CompareExchange attempts to put 1 into syncPoint, but
    // only if the current value of syncPoint is zero
    // (specified by the third parameter). If another thread
    // has set syncPoint to 1, or if the control thread has
    // set syncPoint to -1, the current event is skipped.
    // (Normally it would not be necessary to use a local
    // variable for the return value. A local variable is
    // used here to determine the reason the event was
    // skipped.)
    //
    let sync = Interlocked.CompareExchange(&syncPoint, 1, 0)

    if sync = 0 then
        // No other event was executing.
        // The event handler simulates an amount of work
        // lasting between 50 and 200 milliseconds, so that
        // some events will overlap.
        timerIntervalBase - timerIntervalDelta / 2 + rand.Next timerIntervalDelta
        |> Thread.Sleep

        numExecuted <- numExecuted + 1

        // Release control of syncPoint.
        syncPoint <- 0
    else if sync = 1 then
        numSkipped <- numSkipped + 1
    else
        numLate <- numLate + 1


// Event-handling methods for the Elapsed events of the two
// timers.
let timer1_ElapsedEventHandler = handleElapsed

let timer2_ElapsedEventHandler = handleElapsed

[<EntryPoint; MTAThread>]
let main _ =
    timer1.Elapsed.AddHandler timer1_ElapsedEventHandler
    timer2.Elapsed.AddHandler timer2_ElapsedEventHandler

    printfn ""

    for i = 1 to testRuns do
        testRun ()
        printf $"\rTest {i}/{testRuns}    "

    printfn $"{testRuns} test runs completed."
    printfn $"{numEvents} events were raised."
    printfn $"{numExecuted} events executed."
    printfn $"{numSkipped} events were skipped for concurrency."
    printfn $"{numLate} events were skipped because they were late."
    printfn $"Control thread waited {numWaits} times for an event to complete."
    0

// On a dual-processor computer, this code example produces
// results similar to the following:
//     Test 100/100    100 test runs completed.
//     436 events were raised.
//     352 events executed.
//     84 events were skipped for concurrency.
//     0 events were skipped because they were late.
//     Control thread waited 77 times for an event to complete.
//</Snippet1>
