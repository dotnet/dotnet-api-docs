module fromminutes

//<Snippet4>
// Example of the TimeSpan.FromMinutes( double ) method.
open System

let genTimeSpanFromMinutes minutes =
    // Create a TimeSpan object and TimeSpan string from 
    // a number of minutes.
    let interval = TimeSpan.FromMinutes minutes
    let timeInterval = string interval

    // Pad the end of the TimeSpan string with spaces if it 
    // does not contain milliseconds.
    let pIndex = timeInterval.IndexOf ':'
    let pIndex = timeInterval.IndexOf('.', pIndex)
    let timeInterval =
        if pIndex < 0 then timeInterval + "        "
        else timeInterval

    printfn $"{minutes,21}{timeInterval,26}"

printfn "This example of TimeSpan.FromMinutes( double )\ngenerates the following output.\n"
printfn "%21s%18s" "FromMinutes" "TimeSpan"
printfn "%21s%18s" "-----------" "--------"

genTimeSpanFromMinutes 0.00001
genTimeSpanFromMinutes 0.00002
genTimeSpanFromMinutes 0.12345
genTimeSpanFromMinutes 1234.56789
genTimeSpanFromMinutes 12345678.98765
genTimeSpanFromMinutes 0.01666
genTimeSpanFromMinutes 1
genTimeSpanFromMinutes 60
genTimeSpanFromMinutes 1440
genTimeSpanFromMinutes 30020.33667

(*
This example of TimeSpan.FromMinutes( double )
generates the following output.

          FromMinutes          TimeSpan
          -----------          --------
                1E-05          00:00:00.0010000
                2E-05          00:00:00.0010000
              0.12345          00:00:07.4070000
           1234.56789          20:34:34.0730000
       12345678.98765     8573.09:18:59.2590000
              0.01666          00:00:01
                    1          00:01:00
                   60          01:00:00
                 1440        1.00:00:00
          30020.33667       20.20:20:20.2000000
*)
//</Snippet4>