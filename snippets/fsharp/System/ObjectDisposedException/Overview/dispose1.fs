module dispose1

// <Snippet1>
open System
open System.Threading

let timerNotification _ =
    printfn $"Timer event fired at {DateTime.Now:F}"

let t = new Timer(timerNotification, null, 100, Timeout.Infinite)
Thread.Sleep 2000
t.Dispose()

t.Change(200, 1000)
|> ignore
Thread.Sleep 3000

// The example displays output like the following:
//    Timer event fired at Monday, July 14, 2014 11:54:08 AM
//
//    Unhandled Exception: System.ObjectDisposedException: Cannot access a disposed object.
//       at System.Threading.TimerQueueTimer.Change(UInt32 dueTime, UInt32 period)
//       at <StartupCode$fs>.main()
// </Snippet1>