module fromticks

//<Snippet1>
// Example of the TimeSpan.FromTicks( long ) method.
open System

let genTimeSpanFromTicks ticks =
    // Create a TimeSpan object and TimeSpan string from 
    // a number of ticks.
    let interval = TimeSpan.FromTicks ticks
    let timeInterval = string interval

    // Pad the end of the TimeSpan string with spaces if it 
    // does not contain milliseconds.
    let pIndex = timeInterval.IndexOf ':'
    let pIndex = timeInterval.IndexOf('.', pIndex)
    let timeInterval = 
        if pIndex < 0 then timeInterval + "        "
        else timeInterval

    printfn $"{ticks,21}{timeInterval,26}"

printfn "This example of TimeSpan.FromTicks( long )\ngenerates the following output.\n"
printfn "%21s%18s" "FromTicks" "TimeSpan"
printfn "%21s%18s" "---------" "--------"

genTimeSpanFromTicks 1
genTimeSpanFromTicks 12345
genTimeSpanFromTicks 123456789
genTimeSpanFromTicks 1234567898765L
genTimeSpanFromTicks 12345678987654321L
genTimeSpanFromTicks 10000000
genTimeSpanFromTicks 600000000
genTimeSpanFromTicks 36000000000L
genTimeSpanFromTicks 864000000000L
genTimeSpanFromTicks 18012202000000L

(*
This example of TimeSpan.FromTicks( long )
generates the following output.

            FromTicks          TimeSpan
            ---------          --------
                    1          00:00:00.0000001
                12345          00:00:00.0012345
            123456789          00:00:12.3456789
        1234567898765        1.10:17:36.7898765
    12345678987654321    14288.23:31:38.7654321
             10000000          00:00:01
            600000000          00:01:00
          36000000000          01:00:00
         864000000000        1.00:00:00
       18012202000000       20.20:20:20.2000000
*)
//</Snippet1>