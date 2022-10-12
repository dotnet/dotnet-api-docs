module fromseconds

//<Snippet3>
// Example of the TimeSpan.FromSeconds( double ) method.
open System

let genTimeSpanFromSeconds seconds =
    // Create a TimeSpan object and TimeSpan string from 
    // a number of seconds.
    let interval = TimeSpan.FromSeconds seconds
    let timeInterval = string interval

    // Pad the end of the TimeSpan string with spaces if it 
    // does not contain milliseconds.
    let pIndex = timeInterval.IndexOf ':'
    let pIndex = timeInterval.IndexOf('.', pIndex)
    let timeInterval =
        if pIndex < 0 then timeInterval + "        "
        else timeInterval

    printfn $"{seconds,21}{timeInterval,26}"

printfn "This example of TimeSpan.FromSeconds( double )\ngenerates the following output.\n"
printfn "%21s%18s" "FromSeconds" "TimeSpan"
printfn "%21s%18s" "-----------" "--------"

genTimeSpanFromSeconds 0.001
genTimeSpanFromSeconds 0.0015
genTimeSpanFromSeconds 12.3456
genTimeSpanFromSeconds 123456.7898
genTimeSpanFromSeconds 1234567898.7654
genTimeSpanFromSeconds 1
genTimeSpanFromSeconds 60
genTimeSpanFromSeconds 3600
genTimeSpanFromSeconds 86400
genTimeSpanFromSeconds 1801220.2

(*
This example of TimeSpan.FromSeconds( double )
generates the following output.

          FromSeconds          TimeSpan
          -----------          --------
                0.001          00:00:00.0010000
               0.0015          00:00:00.0020000
              12.3456          00:00:12.3460000
          123456.7898        1.10:17:36.7900000
      1234567898.7654    14288.23:31:38.7650000
                    1          00:00:01
                   60          00:01:00
                 3600          01:00:00
                86400        1.00:00:00
            1801220.2       20.20:20:20.2000000
*)
//</Snippet3>