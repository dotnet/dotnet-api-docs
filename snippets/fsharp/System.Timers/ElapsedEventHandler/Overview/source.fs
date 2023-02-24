// <Snippet1>
// To avoid confusion with other Timer classes, this sample always uses the fully-qualified
// name of System.Timers.Timer instead of a using statement for System.Timers.
module Example

let mutable aTimer = new System.Timers.Timer()

let onTimedEvent source (e: System.Timers.ElapsedEventArgs) =
    printfn $"The Elapsed event was raised at {e.SignalTime}"

[<EntryPoint>]
let main _ =
    // Normally, the timer is declared at the class level, so that it stays in scope as long as it
    // is needed. If the timer is declared in a long-running method, KeepAlive must be used to prevent
    // the JIT compiler from allowing aggressive garbage collection to occur before the method ends.
    // You can experiment with this by commenting out the class-level declaration and uncommenting
    // the declaration below then uncomment the GC.KeepAlive(aTimer) at the end of the method.
    //System.Timers.Timer aTimer

    // Set a two second interval.
    aTimer.Interval <- 2000

    // Alternate method: create a Timer with an interval argument to the constructor.
    //aTimer = new System.Timers.Timer(2000)

    // Create a timer with a two second interval.
    aTimer <- new System.Timers.Timer(2000)

    // Hook up the Elapsed event for the timer.
    aTimer.Elapsed.AddHandler onTimedEvent

    // Have the timer fire repeated events (true is the default)
    aTimer.AutoReset <- true

    // Start the timer
    aTimer.Enabled <- true

    printfn "Press the Enter key to exit the program at any time... "
    stdin.ReadLine() |> ignore

    // If the timer is declared in a long-running method, use KeepAlive to prevent garbage collection
    // from occurring before the method ends.
    //GC.KeepAlive(aTimer)
    0

// This example displays output like the following:
//       Press the Enter key to exit the program at any time...
//       The Elapsed event was raised at 5/20/2015 8:48:58 PM
//       The Elapsed event was raised at 5/20/2015 8:49:00 PM
//       The Elapsed event was raised at 5/20/2015 8:49:02 PM
//       The Elapsed event was raised at 5/20/2015 8:49:04 PM
//       The Elapsed event was raised at 5/20/2015 8:49:06 PM

// </Snippet1>
