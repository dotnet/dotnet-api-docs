module timer1

// <Snippet1>
open System.Timers

let onTimedEvent source (e: ElapsedEventArgs) =
    printfn $"The Elapsed event was raised at {e.SignalTime}"

// Create a timer and set a two second interval.
let aTimer = new Timer()
aTimer.Interval <- 2000

// Hook up the Elapsed event for the timer. 
aTimer.Elapsed.AddHandler onTimedEvent

// Have the timer fire repeated events (true is the default)
aTimer.AutoReset <- true

// Start the timer
aTimer.Enabled <- true

printfn "Press the Enter key to exit the program at any time... "
stdin.ReadLine() |> ignore

// The example displays output like the following: 
//       Press the Enter key to exit the program at any time... 
//       The Elapsed event was raised at 5/20/2015 8:48:58 PM 
//       The Elapsed event was raised at 5/20/2015 8:49:00 PM 
//       The Elapsed event was raised at 5/20/2015 8:49:02 PM 
//       The Elapsed event was raised at 5/20/2015 8:49:04 PM 
//       The Elapsed event was raised at 5/20/2015 8:49:06 PM 
// </Snippet1>