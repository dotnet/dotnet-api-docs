// <Snippet1>
open System.Threading

type StayAwake() =
    member val SleepSwitch = false with get, set

    member this.ThreadMethod() =
        printfn "newThread is executing ThreadMethod."

        while not this.SleepSwitch do
            // Use SpinWait instead of Sleep to demonstrate the
            // effect of calling Interrupt on a running thread.
            Thread.SpinWait 10000000

        try
            printfn "newThread going to sleep."

            // When newThread goes to sleep, it is immediately
            // woken up by a ThreadInterruptedException.
            Thread.Sleep Timeout.Infinite
        with :? ThreadInterruptedException ->
            printfn "newThread cannot go to sleep - interrupted by main thread."

let stayAwake = StayAwake()
let newThread = Thread stayAwake.ThreadMethod
newThread.Start()

// The following line causes an exception to be thrown
// in ThreadMethod if newThread is currently blocked
// or becomes blocked in the future.
newThread.Interrupt()
printfn "Main thread calls Interrupt on newThread."

// Tell newThread to go to sleep.
stayAwake.SleepSwitch <- true

// Wait for newThread to end.
newThread.Join()
// </Snippet1>
