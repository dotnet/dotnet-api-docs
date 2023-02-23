module timer2a

// <Snippet2>
open System
open System.Timers

let onTimedEvent source (e: ElapsedEventArgs) =
    printfn $"""The Elapsed event was raised at {e.SignalTime.ToString "HH:mm:ss.fff"}"""

// Create a timer with a two second interval.
let aTimer = new Timer 2000
// Hook up the Elapsed event for the timer. 
aTimer.Elapsed.AddHandler onTimedEvent
aTimer.AutoReset <- true
aTimer.Enabled <- true

printfn "\nPress the Enter key to exit the application...\n"
printfn $"""The application started at {DateTime.Now.ToString "HH:mm:ss.fff"}"""
stdin.ReadLine() |> ignore
aTimer.Stop()
aTimer.Dispose()

printfn "Terminating the application..."

// The example displays output like the following:
//       Press the Enter key to exit the application...
//
//       The application started at 09:40:29.068
//       The Elapsed event was raised at 09:40:31.084
//       The Elapsed event was raised at 09:40:33.100
//       The Elapsed event was raised at 09:40:35.100
//       The Elapsed event was raised at 09:40:37.116
//       The Elapsed event was raised at 09:40:39.116
//       The Elapsed event was raised at 09:40:41.117
//       The Elapsed event was raised at 09:40:43.132
//       The Elapsed event was raised at 09:40:45.133
//       The Elapsed event was raised at 09:40:47.148
//
//       Terminating the application...
// </Snippet2>