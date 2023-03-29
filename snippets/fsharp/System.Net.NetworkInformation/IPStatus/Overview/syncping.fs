module Examples.System.Net.NetworkInformation.PingTest

//NCLPingSync
//<snippet1>
open System
open System.Net.NetworkInformation
open System.Text

// args[0] can be an IPaddress or host name.
[<EntryPoint>]
let main args =
    //<snippet3>
    //<snippet2>
    let pingSender = new Ping()

    // Use the default Ttl value which is 128,
    // but change the fragmentation behavior.
    let options = PingOptions()
    options.DontFragment <- true

    //</snippet2>
    // Create a buffer of 32 bytes of data to be transmitted.
    let data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
    let buffer = Encoding.ASCII.GetBytes data
    let timeout = 120
    let reply: PingReply = pingSender.Send(args.[0], timeout, buffer, options)
    //</snippet3>
    //<snippet4>

    match reply.Status with
    | IPStatus.Success ->
        Console.WriteLine("Address: {0}", reply.Address.ToString())
        Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime)
        Console.WriteLine("Time to live: {0}", reply.Options.Ttl)
        Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment)
        Console.WriteLine("Buffer size: {0}", reply.Buffer.Length)
        0
    | _ -> 1
//</snippet4>
//</snippet1>
