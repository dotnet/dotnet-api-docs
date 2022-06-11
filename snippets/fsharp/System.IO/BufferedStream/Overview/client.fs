// <Snippet1>
module Client

open System
open System.IO
open System.Net
open System.Net.Sockets

let dataArraySize    =   100
let streamBufferSize =  1000
let numberOfLoops    = 10000

let sendData (netStream: Stream) (bufStream: Stream) =
    // Create random data to send to the server.
    let dataToSend = Array.zeroCreate dataArraySize
    Random().NextBytes dataToSend

    // Send the data using the NetworkStream.
    printfn "Sending data using NetworkStream."
    let startTime = DateTime.Now
    for _ = 0 to numberOfLoops - 1 do
        netStream.Write(dataToSend, 0, dataToSend.Length)
    let networkTime = (DateTime.Now - startTime).TotalSeconds
    printfn $"{numberOfLoops * dataToSend.Length} bytes sent in {networkTime:F1} seconds.\n"

    // <Snippet6>
    // Send the data using the BufferedStream.
    printfn "Sending data using BufferedStream."
    let startTime = DateTime.Now
    for _ = 0 to numberOfLoops - 1 do
        bufStream.Write(dataToSend, 0, dataToSend.Length)
    bufStream.Flush()
    let bufferedTime = (DateTime.Now - startTime).TotalSeconds
    printfn $"{numberOfLoops * dataToSend.Length} bytes sent in {bufferedTime:F1} seconds.\n"
    // </Snippet6>

    // Print the ratio of write times.
    printfn $"""Sending data using the buffered network stream was {networkTime / bufferedTime:P0} {if bufferedTime < networkTime then "faster" else "slower"} than using the network stream alone."""
    printfn ""

let receiveData (netStream: Stream) (bufStream: Stream) =
    let mutable bytesReceived = 0
    let receivedData = Array.zeroCreate dataArraySize

    // Receive data using the NetworkStream.
    printfn "Receiving data using NetworkStream."
    let startTime = DateTime.Now
    while bytesReceived < numberOfLoops * receivedData.Length do
        bytesReceived <- bytesReceived + netStream.Read(receivedData, 0, receivedData.Length)
    let networkTime = (DateTime.Now - startTime).TotalSeconds
    printfn $"{bytesReceived} bytes received in {networkTime:F1} seconds.\n"

    // <Snippet7>
    // Receive data using the BufferedStream.
    printfn "Receiving data using BufferedStream."
    bytesReceived <- 0
    let startTime = DateTime.Now

    let mutable numBytesToRead = receivedData.Length

    let mutable broken = false
    while not broken && numBytesToRead > 0 do
        // Read may return anything from 0 to numBytesToRead.
        let n = bufStream.Read(receivedData,0, receivedData.Length)
        // The end of the file is reached.
        if n = 0 then
            broken <- true
        else
            bytesReceived <- bytesReceived + n
            numBytesToRead <- numBytesToRead - n

    let bufferedTime = (DateTime.Now - startTime).TotalSeconds
    printfn $"{bytesReceived} bytes received in {bufferedTime:F1} seconds.\n"
    // </Snippet7>

    // Print the ratio of read times.
    printfn $"""Receiving data using the buffered network stream was {networkTime / bufferedTime:P0} {if bufferedTime < networkTime then "faster" else "slower"} than using the network stream alone."""

[<EntryPoint>]
let main args =
    // Check that an argument was specified when the
    // program was invoked.
    if args.Length = 0 then
        printfn "Error: The name of the host computer must be specified when the program is invoked."
    else
        let remoteName = args[0]

        // Create the underlying socket and connect to the server.
        let clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        clientSocket.Connect(IPEndPoint(Dns.GetHostEntry(remoteName).AddressList[0], 1800))

        printfn "Client is connected.\n"

        // <Snippet2>
        // Create a NetworkStream that owns clientSocket and
        // then create a BufferedStream on top of the NetworkStream.
        // Both streams are disposed when execution exits the
        // using statement.
        use netStream = new NetworkStream(clientSocket, true)
        use bufStream = new BufferedStream(netStream, streamBufferSize)
        // </Snippet2>
        // <Snippet3>
        // Check whether the underlying stream supports seeking.
        printfn $"""NetworkStream {if bufStream.CanSeek then "supports" else "does not support"} seeking.\n"""
        // </Snippet3>

        // Send and receive data.
        // <Snippet4>
        if bufStream.CanWrite then
            sendData netStream bufStream
        // </Snippet4>
        // <Snippet5>
        if bufStream.CanRead then
            receiveData netStream bufStream
        // </Snippet5>

        // <Snippet8>
        // When bufStream is closed, netStream is in turn
        // closed, which in turn shuts down the connection
        // and closes clientSocket.
        printfn "\nShutting down the connection."
        bufStream.Close()
        // </Snippet8>
    0
// </Snippet1>