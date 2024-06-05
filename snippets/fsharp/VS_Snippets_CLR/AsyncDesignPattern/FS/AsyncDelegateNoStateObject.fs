// <Snippet4>
// The following example demonstrates using asynchronous methods to
// get Domain Name System information for the specified host computers.
// This example uses a delegate to obtain the results of each asynchronous
// operation.

open System
open System.Net
open System.Net.Sockets
open System.Threading
open System.Collections.Specialized

let mutable requestCounter = 0
let hostData = ResizeArray<Result<IPHostEntry, string>>()
let hostNames = StringCollection()

let updateUserInterface () =
    // Print a message to indicate that the application
    // is still working on the remaining requests.
    printfn $"{requestCounter} requests remaining."

// The following function is called when each asynchronous operation completes.
let processDnsInformation (result: IAsyncResult) =
    string result.AsyncState
    |> hostNames.Add 
    |> ignore
    try
        try
            // Get the results.
            Dns.EndGetHostEntry result
            |> Ok
            |> hostData.Add
        // Store the exception message.
        with :? SocketException as e ->
            Error e.Message
            |> hostData.Add 
    finally
        // Decrement the request counter in a thread-safe manner.
        Interlocked.Decrement &requestCounter 
        |> ignore

// Create the delegate that will process the results of the asynchronous request.
let callBack = AsyncCallback processDnsInformation

let mutable host = " "
while host.Length > 0 do
    printf " Enter the name of a host computer or <enter> to finish: "
    host <- stdin.ReadLine()
    if host.Length > 0 then
        // Increment the request counter in a thread safe manner.
        Interlocked.Increment &requestCounter |> ignore
        // Start the asynchronous request for DNS information.
        Dns.BeginGetHostEntry(host, callBack, host) |> ignore

// The user has entered all of the host names for lookup.
// Now wait until the threads complete.
while requestCounter > 0 do
    updateUserInterface ()

// Display the results.
for i = 0 to hostNames.Count - 1 do
    match hostData[i] with 
    | Error message ->
        // A SocketException was thrown.
        printfn $"Request for {hostNames[i]} returned message: {message}"
    | Ok entry ->    
        // Get the results.
        let aliases = entry.Aliases
        let addresses = entry.AddressList
        if aliases.Length > 0 then
            printfn $"Aliases for {hostNames[i]}"
            for alias in aliases do
                printfn $"{alias}"

        if addresses.Length > 0 then
            printfn $"Addresses for {hostNames[i]}"
            for address in addresses do
                printfn $"{address}"

//</Snippet4>