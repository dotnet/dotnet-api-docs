// <Snippet1>
// <Snippet2>
open System
open System.Threading

// Variable for continual checking in the
// While loop in the WaitForFullGCProc method.
let mutable checkForNotify = false

// Variable for suspending work
// (such servicing allocated server requests)
// after a notification is received and then
// resuming allocation after inducing a garbage collection.
let mutable bAllocate = false

// Variable for ending the example.
let mutable finalExit = false

// Collection for objects that simulate the server request workload.
let load = ResizeArray<byte []>()


// <Snippet9>
let redirectRequests () =
    // Code that sends requests
    // to other servers.

    // Suspend work.
    bAllocate <- false

let finishExistingRequests () =
    // Code that waits a period of time
    // for pending requests to finish.

    // Clear the simulated workload.
    load.Clear()

let acceptRequests () =
    // Code that resumes processing
    // requests on this server.

    // Resume work.
    bAllocate <- true
// </Snippet9>

// <Snippet5>
let onFullGCApproachNotify () =
    printfn "Redirecting requests."

    // Method that tells the request queuing
    // server to not direct requests to this server.
    redirectRequests ()

    // Method that provides time to
    // finish processing pending requests.
    finishExistingRequests ()

    // This is a good time to induce a GC collection
    // because the runtime will induce a full GC soon.
    // To be very careful, you can check precede with a
    // check of the GC.GCCollectionCount to make sure
    // a full GC did not already occur since last notified.
    GC.Collect()
    printfn "Induced a collection."
// </Snippet5>


// <Snippet6>
let onFullGCCompleteEndNotify () =
    // Method that informs the request queuing server
    // that this server is ready to accept requests again.
    acceptRequests ()
    printfn "Accepting requests again."
// </Snippet6>

// <Snippet8>
let waitForFullGCProc () =
    let mutable broken = false

    while not broken do
        let mutable broken = false
        // CheckForNotify is set to true and false in Main.
        while checkForNotify && not broken do
            // <Snippet3>
            // Check for a notification of an approaching collection.
            match GC.WaitForFullGCApproach() with
            | GCNotificationStatus.Succeeded ->
                printfn "GC Notification raised."
                onFullGCApproachNotify ()
                // <Snippet4>
                // Check for a notification of a completed collection.
                match GC.WaitForFullGCComplete() with
                | GCNotificationStatus.Succeeded ->
                    printfn "GC Notification raised."
                    onFullGCCompleteEndNotify ()
                | GCNotificationStatus.Canceled ->
                    printfn "GC Notification cancelled."
                    broken <- true
                | _ ->
                    // Could be a time out.
                    printfn "GC Notification not applicable."
                    broken <- true
            // </Snippet4>
            | GCNotificationStatus.Canceled ->
                printfn "GC Notification cancelled."
                broken <- true
            | _ ->
                // This can occur if a timeout period
                // is specified for WaitForFullGCApproach(Timeout)
                // or WaitForFullGCComplete(Timeout)
                // and the time out period has elapsed.
                printfn "GC Notification not applicable."
                broken <- true
        // </Snippet3>

        Thread.Sleep 500
        // FinalExit is set to true right before
        // the main thread cancelled notification.
        if finalExit then broken <- true
// </Snippet8>



try
    // Register for a notification.
    GC.RegisterForFullGCNotification(10, 10)
    printfn "Registered for GC notification."

    checkForNotify <- true
    bAllocate <- true

    // Start a thread using WaitForFullGCProc.
    let thWaitForFullGC = Thread(ThreadStart waitForFullGCProc)
    thWaitForFullGC.Start()

    // While the thread is checking for notifications in
    // WaitForFullGCProc, create objects to simulate a server workload.
    try
        let mutable lastCollCount = 0
        let mutable newCollCount = 0

        let mutable broken = false

        while not broken do
            if bAllocate then
                load.Add(Array.zeroCreate<byte> 1000)
                newCollCount <- GC.CollectionCount 2

                if newCollCount <> lastCollCount then
                    // Show collection count when it increases:
                    printfn $"Gen 2 collection count: {GC.CollectionCount(2)}"
                    lastCollCount <- newCollCount
                // For ending the example (arbitrary).
                if newCollCount = 500 then
                    finalExit <- true
                    checkForNotify <- false
                    broken <- true
    with :? OutOfMemoryException -> printfn "Out of memory."

    // <Snippet7>
    finalExit <- true
    checkForNotify <- false
    GC.CancelFullGCNotification()
// </Snippet7>
with :? InvalidOperationException as invalidOp ->
    printfn $"GC Notifications are not supported while concurrent GC is enabled.\n{invalidOp.Message}"
// </Snippet2>
// </Snippet1>
