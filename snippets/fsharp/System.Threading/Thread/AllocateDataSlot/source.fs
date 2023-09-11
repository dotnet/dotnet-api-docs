module source
// <Snippet1>
open System
open System.Threading

module Slot =
    let randomGenerator = Random()
    let localSlot = Thread.AllocateDataSlot()


    let slotTest () =
        // Set different data in each thread's data slot.
        Thread.SetData(localSlot, randomGenerator.Next(1, 200))

        // Write the data from each thread's data slot.
        printfn $"Data in thread_{AppDomain.GetCurrentThreadId()}'s data slot: {Thread.GetData localSlot, 3}"

        // Allow other threads time to execute SetData to show
        // that a thread's data slot is unique to the thread.
        Thread.Sleep 1000

        printfn $"Data in thread_{AppDomain.GetCurrentThreadId()}'s data slot: {Thread.GetData localSlot, 3}"

let newThreads =
    [| for _ = 0 to 3 do
           let thread = Thread Slot.slotTest
           thread.Start()
           thread |]
// </Snippet1>