// <Snippet1>
open System.Threading

let threadMethod () = Thread.Sleep 1000

let newThread = Thread threadMethod
newThread.SetApartmentState ApartmentState.MTA

printfn $"ThreadState: {newThread.ThreadState}, ApartmentState: {newThread.GetApartmentState()}"

newThread.Start()

// Wait for newThread to start and go to sleep.
Thread.Sleep 300

try
    // This causes an exception since newThread is sleeping.
    newThread.SetApartmentState ApartmentState.STA

with :? ThreadStateException as stateException ->
    printfn $"\n{stateException.GetType().Name} caught:\nThread is not in the Unstarted or Running state."
    printfn $"ThreadState: {newThread.ThreadState}, ApartmentState: {newThread.GetApartmentState()}"
// </Snippet1>
