// <Snippet1>
module Server

open System
open System.Net
open System.Net.Sockets

// This is a Windows Sockets 2 error code.
let WSAETIMEDOUT = 10060

let mutable bytesReceived = -1 
let mutable totalReceived = 0
let receivedData = Array.zeroCreate 2000000

// Create random data to send to the client.
let dataToSend = Array.zeroCreate 2000000
Random().NextBytes dataToSend

let ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0]

let ipEndpoint = IPEndPoint(ipAddress, 1800)

// Create a socket and listen for incoming connections.
let serverSocket = 
    use listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
    listenSocket.Bind ipEndpoint
    listenSocket.Listen 1

    // Accept a connection and create a socket to handle it.
    listenSocket.Accept()

printfn "Server is connected.\n"

try
    // Send data to the client.
    printf "Sending data ... "
    let bytesSent = serverSocket.Send(dataToSend, 0, dataToSend.Length, SocketFlags.None)
    printfn $"{bytesSent} bytes sent.\n"

    // Set the timeout for receiving data to 2 seconds.
    serverSocket.SetSocketOption(SocketOptionLevel.Socket,
        SocketOptionName.ReceiveTimeout, 2000)

    // Receive data from the client.
    printf "Receiving data ... "
    try
        try
            while bytesReceived <> 0 do
                bytesReceived <- serverSocket.Receive(receivedData, 0, receivedData.Length, SocketFlags.None)
                totalReceived <- totalReceived + bytesReceived

        with :? SocketException as e ->
            if e.ErrorCode = WSAETIMEDOUT then
                // Data was not received within the given time.
                // Assume that the transmission has ended.
                ()
            else
                printfn $"{e.GetType().Name}: {e.Message}\n"
    finally
        printfn $"{totalReceived} bytes received.\n"
finally
    serverSocket.Shutdown SocketShutdown.Both
    printfn "Connection shut down."
    serverSocket.Close()
// </Snippet1>