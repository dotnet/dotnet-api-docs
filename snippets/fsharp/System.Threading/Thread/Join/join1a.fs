module join1a
// <Snippet1>
open System.Threading

let mutable thread1, thread2 =
    Unchecked.defaultof<Thread>, Unchecked.defaultof<Thread>

let threadProc () =
    printfn $"\nCurrent thread: {Thread.CurrentThread.Name}"

    if
        Thread.CurrentThread.Name = "Thread1"
        && thread2.ThreadState <> ThreadState.Unstarted
    then
        thread2.Join()

    Thread.Sleep 4000
    printfn $"\nCurrent thread: {Thread.CurrentThread.Name}"
    printfn $"Thread1: {thread1.ThreadState}"
    printfn $"Thread2: {thread2.ThreadState}\n"

thread1 <- Thread threadProc
thread1.Name <- "Thread1"
thread1.Start()

thread2 <- Thread threadProc
thread2.Name <- "Thread2"
thread2.Start()

// The example displays output like the following:
//       Current thread: Thread1
//
//       Current thread: Thread2
//
//       Current thread: Thread2
//       Thread1: WaitSleepJoin
//       Thread2: Running
//
//
//       Current thread: Thread1
//       Thread1: Running
//       Thread2: Stopped
// </Snippet1>
