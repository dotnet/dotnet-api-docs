module fromdays

//<Snippet6>
// Example of the TimeSpan.FromDays( double ) method.
open System

let genTimeSpanFromDays days =
    // Create a TimeSpan object and TimeSpan string from 
    // a number of days.
    let interval = TimeSpan.FromDays days
    let timeInterval = string interval

    // Pad the end of the TimeSpan string with spaces if it 
    // does not contain milliseconds.
    let pIndex = timeInterval.IndexOf ':'
    let pIndex = timeInterval.IndexOf('.', pIndex)
    let timeInterval = 
        if pIndex < 0 then timeInterval + "        "
        else timeInterval

    printfn $"{days,21}{timeInterval,26}"

printfn "This example of TimeSpan.FromDays( double )\ngenerates the following output.\n"
printfn "%21s%18s" "FromDays" "TimeSpan"
printfn "%21s%18s" "--------" "--------"

genTimeSpanFromDays 0.000000006
genTimeSpanFromDays 0.000000017
genTimeSpanFromDays 0.000123456
genTimeSpanFromDays 1.234567898
genTimeSpanFromDays 12345.678987654
genTimeSpanFromDays 0.000011574
genTimeSpanFromDays 0.000694444
genTimeSpanFromDays 0.041666666
genTimeSpanFromDays 1
genTimeSpanFromDays 20.84745602

(*
This example of TimeSpan.FromDays( double )
generates the following output.

             FromDays          TimeSpan
             --------          --------
                6E-09          00:00:00.0010000
              1.7E-08          00:00:00.0010000
          0.000123456          00:00:10.6670000
          1.234567898        1.05:37:46.6660000
      12345.678987654    12345.16:17:44.5330000
           1.1574E-05          00:00:01
          0.000694444          00:01:00
          0.041666666          01:00:00
                    1        1.00:00:00
          20.84745602       20.20:20:20.2000000
*)
//</Snippet6>