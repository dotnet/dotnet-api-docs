module TryParse1

// <Snippet1>
open System

let parseTimeSpan intervalStr =
    // Write the first part of the output line.
    printf $"%20s{intervalStr}   "

    // Parse the parameter, and then convert it back to a string.
    match TimeSpan.TryParse intervalStr with
    | true, intervalVal ->
        let intervalToStr = string intervalVal

        // Pad the end of the TimeSpan string with spaces if it 
        // does not contain milliseconds.
        let pIndex = intervalToStr.IndexOf ':'
        let pIndex = intervalToStr.IndexOf('.', pIndex)
        let intervalToStr =
            if pIndex < 0 then
                intervalToStr + "        "
            else intervalStr
        printfn $"{intervalToStr,21}"
        // Handle failure of TryParse method.
    | _ ->
        printfn "Parse operation failed."

printfn "%20s   %21s" "String to Parse" "TimeSpan"
printfn "%20s   %21s" "---------------" "---------------------"

parseTimeSpan "0"
parseTimeSpan "14"
parseTimeSpan "1:2:3"
parseTimeSpan "0:0:0.250"
parseTimeSpan "10.20:30:40.50"
parseTimeSpan "99.23:59:59.9999999"
parseTimeSpan "0023:0059:0059.0099"
parseTimeSpan "23:0:0"
parseTimeSpan "24:0:0"
parseTimeSpan "0:59:0"
parseTimeSpan "0:60:0"
parseTimeSpan "0:0:59"
parseTimeSpan "0:0:60"
parseTimeSpan "10:"
parseTimeSpan "10:0"
parseTimeSpan ":10"
parseTimeSpan "0:10"
parseTimeSpan "10:20:"
parseTimeSpan "10:20:0"
parseTimeSpan ".123"
parseTimeSpan "0.12:00"
parseTimeSpan "10."
parseTimeSpan "10.12"
parseTimeSpan "10.12:00"
//            String to Parse                TimeSpan
//            ---------------   ---------------------
//                          0        00:00:00
//                         14     14.00:00:00
//                      1:2:3        01:02:03
//                  0:0:0.250        00:00:00.2500000
//             10.20:30:40.50     10.20:30:40.5000000
//        99.23:59:59.9999999     99.23:59:59.9999999
//        0023:0059:0059.0099        23:59:59.0099000
//                     23:0:0        23:00:00
//                     24:0:0   Parse operation failed.
//                     0:59:0        00:59:00
//                     0:60:0   Parse operation failed.
//                     0:0:59        00:00:59
//                     0:0:60   Parse operation failed.
//                        10:   Parse operation failed.
//                       10:0        10:00:00
//                        :10   Parse operation failed.
//                       0:10        00:10:00
//                     10:20:   Parse operation failed.
//                    10:20:0        10:20:00
//                       .123   Parse operation failed.
//                    0.12:00        12:00:00
//                        10.   Parse operation failed.
//                      10.12   Parse operation failed.
//                   10.12:00     10.12:00:00
// </Snippet1>