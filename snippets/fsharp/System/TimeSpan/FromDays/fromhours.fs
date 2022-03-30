module fromhours

//<Snippet5>
// Example of the TimeSpan.FromHours( double ) method.
open System

let genTimeSpanFromHours hours =
    // Create a TimeSpan object and TimeSpan string from 
    // a number of hours.
    let interval = TimeSpan.FromHours hours
    let timeInterval = string interval

    // Pad the end of the TimeSpan string with spaces if it 
    // does not contain milliseconds.
    let pIndex = timeInterval.IndexOf ':'
    let pIndex = timeInterval.IndexOf('.', pIndex)
    let timeInterval =
        if pIndex < 0 then timeInterval + "        "
        else timeInterval

    printfn $"{hours,21}{timeInterval,26}"

printfn "This example of TimeSpan.FromHours( double )\ngenerates the following output.\n"
printfn "%21s%18s" "FromHours" "TimeSpan"
printfn "%21s%18s" "---------" "--------"

genTimeSpanFromHours 0.0000002
genTimeSpanFromHours 0.0000003
genTimeSpanFromHours 0.0012345
genTimeSpanFromHours 12.3456789
genTimeSpanFromHours 123456.7898765
genTimeSpanFromHours 0.0002777
genTimeSpanFromHours 0.0166666
genTimeSpanFromHours 1
genTimeSpanFromHours 24
genTimeSpanFromHours 500.3389445

(*
This example of TimeSpan.FromHours( double )
generates the following output.

            FromHours          TimeSpan
            ---------          --------
                2E-07          00:00:00.0010000
                3E-07          00:00:00.0010000
            0.0012345          00:00:04.4440000
           12.3456789          12:20:44.4440000
       123456.7898765     5144.00:47:23.5550000
            0.0002777          00:00:01
            0.0166666          00:01:00
                    1          01:00:00
                   24        1.00:00:00
          500.3389445       20.20:20:20.2000000
*)
//</Snippet5>