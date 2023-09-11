// <Snippet1>
open System.Threading

let threadMethod () =
    Thread.Sleep 1000

let newThread = Thread threadMethod

printfn $"ThreadState: {newThread.ThreadState}"
newThread.Start()

// Wait for newThread to start and go to sleep.
Thread.Sleep 300
printfn $"ThreadState: {newThread.ThreadState}"

// Wait for newThread to restart.
Thread.Sleep 1000
printfn $"ThreadState: {newThread.ThreadState}"

// The example displays the following output:
//       ThreadState: Unstarted
//       ThreadState: WaitSleepJoin
//       ThreadState: Stopped
// </Snippet1>