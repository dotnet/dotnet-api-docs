module frommillisec

//<Snippet2>
// Example of the TimeSpan.FromMilliseconds( double ) method.
open System

let genTimeSpanFromMillisec millisec =
    // Create a TimeSpan object and TimeSpan string from 
    // a number of milliseconds.
    let interval = TimeSpan.FromMilliseconds millisec
    let timeInterval = string interval

    // Pad the end of the TimeSpan string with spaces if it 
    // does not contain milliseconds.
    let pIndex = timeInterval.IndexOf ':'
    let pIndex = timeInterval.IndexOf('.', pIndex)
    let timeInterval =
        if pIndex < 0 then timeInterval + "        "
        else timeInterval

    printfn $"{millisec,21}{timeInterval,26}"

printfn "This example of TimeSpan.FromMilliseconds( double )\ngenerates the following output.\n"
printfn "%21s%18s" "FromMilliseconds" "TimeSpan"
printfn "%21s%18s" "----------------" "--------"

genTimeSpanFromMillisec 1
genTimeSpanFromMillisec 1.5
genTimeSpanFromMillisec 12345.6
genTimeSpanFromMillisec 123456789.8
genTimeSpanFromMillisec 1234567898765.4
genTimeSpanFromMillisec 1000
genTimeSpanFromMillisec 60000
genTimeSpanFromMillisec 3600000
genTimeSpanFromMillisec 86400000
genTimeSpanFromMillisec 1801220200

(*
This example of TimeSpan.FromMilliseconds( double )
generates the following output.

     FromMilliseconds          TimeSpan
     ----------------          --------
                    1          00:00:00.0010000
                  1.5          00:00:00.0020000
              12345.6          00:00:12.3460000
          123456789.8        1.10:17:36.7900000
      1234567898765.4    14288.23:31:38.7650000
                 1000          00:00:01
                60000          00:01:00
              3600000          01:00:00
             86400000        1.00:00:00
           1801220200       20.20:20:20.2000000
*)
//</Snippet2>