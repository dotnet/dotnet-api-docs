// <Snippet1>
open System
open System.Threading

module Slot =
    let private randomGenerator = Random()

    let slotTest () =
        // Set random data in each thread's data slot.
        let slotData = randomGenerator.Next(1, 200)
        let threadId = Thread.CurrentThread.ManagedThreadId

        Thread.SetData(Thread.GetNamedDataSlot "Random", slotData)

        // Show what was saved in the thread's data slot.
        printfn $"Data stored in thread_{threadId}'s data slot: {slotData, 3}"

        // Allow other threads time to execute SetData to show
        // that a thread's data slot is unique to itself.
        Thread.Sleep 1000

        let newSlotData = Thread.GetData(Thread.GetNamedDataSlot "Random") :?> int

        if newSlotData = slotData then
            printfn $"Data in thread_{threadId}'s data slot is still: {newSlotData, 3}"
        else
            printfn $"Data in thread_{threadId}'s data slot changed to: {newSlotData, 3}"

let newThreads =
    [| for _ = 0 to 3 do
           let thread = Thread Slot.slotTest
           thread.Start()
           thread |]

Thread.Sleep 2000

for tread in newThreads do
    tread.Join()
    printfn $"Thread_{tread.ManagedThreadId} finished."
// </Snippet1>
