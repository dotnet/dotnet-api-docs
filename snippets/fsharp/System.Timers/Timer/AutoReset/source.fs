// <Snippet1>
open System.Threading
open System.Timers

// Handle the Elapsed event.
let onTimedEvent source e =
    printfn "Hello World!"

// Create a timer with a 1.5 second interval.
let interval = 1500.
let aTimer = new Timer(interval)

// Hook up the event handler for the Elapsed event.
aTimer.Elapsed.AddHandler(ElapsedEventHandler onTimedEvent)

// Only raise the event the first time Interval elapses.
aTimer.AutoReset <- false
aTimer.Enabled <- true

// Ensure the event fires before the exit message appears.
Thread.Sleep(interval * 2. |> int)
printfn "Press the Enter key to exit the program."
stdin.ReadLine() |> ignore

// This example displays the following output:
//       Hello World!
//       Press the Enter key to exit the program.
// </Snippet1>