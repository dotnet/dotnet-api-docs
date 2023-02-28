module source1
// <Snippet1>
open System
open System.IO
open System.Threading

// Maintain state information to be passed to
// EndWriteCallback and EndReadCallback.
type State(fStream: FileStream, writeArray: byte[], manualEvent: ManualResetEvent) =
    // readArray stores data that is read from the file.
    let readArray = Array.zeroCreate writeArray.Length

    member _.FStream = fStream
    member _.WriteArray = writeArray
    member _.ReadArray = readArray
    member _.ManualEvent = manualEvent

// When BeginRead is finished reading data from the file, the
// EndReadCallback method is called to end the asynchronous
// read operation and then verify the data.
// <Snippet4>
let endReadCallback (asyncResult: IAsyncResult) =
    let tempState = asyncResult.AsyncState :?> State
    let readCount = tempState.FStream.EndRead asyncResult

    let mutable i = 0
    let mutable errored = false

    while i < readCount do
        if tempState.ReadArray[i] <> tempState.WriteArray[i] then
            printfn "Error writing data."
            tempState.FStream.Close()
            errored <- true
            i <- readCount

        i <- i + 1

    printfn $"The data was written to {tempState.FStream.Name} and verified."
    tempState.FStream.Close()
    // Signal the main thread that the verification is finished.
    tempState.ManualEvent.Set() |> ignore
// </Snippet4>


// When BeginWrite is finished writing data to the file, the
// EndWriteCallback method is called to end the asynchronous
// write operation and then read back and verify the data.
// <Snippet3>
let endWriteCallback (asyncResult: IAsyncResult) =
    let tempState = asyncResult.AsyncState :?> State
    let fStream = tempState.FStream
    fStream.EndWrite asyncResult

    // Asynchronously read back the written data.
    fStream.Position <- 0

    let asyncResult =
        fStream.BeginRead(tempState.ReadArray, 0, tempState.ReadArray.Length, AsyncCallback endReadCallback, tempState)

    // Concurrently do other work, such as
    // logging the write operation.
    ()

// </Snippet3>

// <Snippet2>
// Create a synchronization object that gets
// signaled when verification is complete.
let manualEvent = new ManualResetEvent false

// Create random data to write to the file.
let writeArray = Array.zeroCreate 100000
Random.Shared.NextBytes writeArray

let fStream =
    new FileStream("Test#@@#.dat", FileMode.Create, FileAccess.ReadWrite, FileShare.None, 4096, true)

// Check that the FileStream was opened asynchronously.

if fStream.IsAsync then "" else "not "
|> printfn "fStream was %sopened asynchronously."

// Asynchronously write to the file.
let asyncResult =
    fStream.BeginWrite(
        writeArray,
        0,
        writeArray.Length,
        AsyncCallback endWriteCallback,
        State(fStream, writeArray, manualEvent)
    )

// Concurrently do other work and then wait
// for the data to be written and verified.
manualEvent.WaitOne(5000, false) |> ignore
// </Snippet2>
// </Snippet1>
