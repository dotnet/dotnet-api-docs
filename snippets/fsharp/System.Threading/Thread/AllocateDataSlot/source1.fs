module source1
// <Snippet1>
open System
open System.Threading

type ThreadData() =
    // Create a static variable to hold the data for each thread.
    [<ThreadStatic; DefaultValue>]
    static val mutable private threadSpecificData : int

    static member ThreadStaticDemo() =
        // Store the managed thread id for each thread in the static
        // variable.
        ThreadData.threadSpecificData <- Thread.CurrentThread.ManagedThreadId
        
        // Allow other threads time to execute the same code, to show
        // that the static data is unique to each thread.
        Thread.Sleep 1000

        // Display the static data.
        printfn $"Data for managed thread {Thread.CurrentThread.ManagedThreadId}: {ThreadData.threadSpecificData}" 

for i = 0 to 2 do 
    let newThread = Thread ThreadData.ThreadStaticDemo
    newThread.Start()

// This code example produces output similar to the following:
//       Data for managed thread 4: 4
//       Data for managed thread 5: 5
//       Data for managed thread 3: 3
// </Snippet1>