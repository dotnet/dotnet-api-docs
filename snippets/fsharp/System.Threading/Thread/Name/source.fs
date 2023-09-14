// <Snippet1>
open System.Threading

// Check whether the thread has previously been named
// to avoid a possible InvalidOperationException.
if isNull Thread.CurrentThread.Name then
    Thread.CurrentThread.Name <- "MainThread"
else
    printfn "Unable to name a previously named thread."
// </Snippet1>