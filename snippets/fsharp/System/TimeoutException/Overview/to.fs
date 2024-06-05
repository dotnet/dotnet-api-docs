//<snippet1>
// This example demonstrates the use of the TimeoutException
// exception in conjunction with the SerialPort class.

open System
open System.IO.Ports

try
// Set the COM1 serial port to speed = 4800 baud, parity = odd,
// data bits = 8, stop bits = 1.
    let sp = new SerialPort("COM1", 4800, Parity.Odd, 8, StopBits.One)
// Timeout after 2 seconds.
    sp.ReadTimeout <- 2000
    sp.Open()

// Read until either the default newline termination string
// is detected or the read operation times out.
    let input = sp.ReadLine()

    sp.Close()

// Echo the input.
    printfn $"{input}"

// Only catch timeout exceptions.
with :? TimeoutException as e ->
    printfn $"{e}"
(*
This example produces the following results:

(Data received at the serial port is echoed to the console if the
read operation completes successfully before the specified timeout period
expires. Otherwise, a timeout exception like the following is thrown.)

System.TimeoutException: The operation has timed-out.
   at System.IO.Ports.SerialStream.ReadByte(Int32 timeout)
   at System.IO.Ports.SerialPort.ReadOneChar(Int32 timeout)
   at System.IO.Ports.SerialPort.ReadTo(String value)
   at System.IO.Ports.SerialPort.ReadLine()
   at Sample.main()
*)
//</snippet1>