//<Snippet1>
// Example of the TimeSpan fields.
open System

// Pad the end of a TimeSpan string with spaces if it does not 
// contain milliseconds.
let align (interval: TimeSpan) =
    let intervalStr = string interval
    let pointIndex = intervalStr.IndexOf ':'

    let pointIndex = intervalStr.IndexOf('.', pointIndex)
    if pointIndex < 0 then intervalStr + "        "
    else intervalStr


printfn "This example of the fields of the TimeSpan class\ngenerates the following output.\n"
printfn "%-22s%18s" "Field" "Value"
printfn "%-22s%18s" "-----" "-----"

// Display the maximum, minimum, and zero TimeSpan values.
printfn $"""{"Maximum TimeSpan",-22}{align TimeSpan.MaxValue,26}"""
printfn $"""{"Minimum TimeSpan",-22}{align TimeSpan.MinValue,26}"""
printfn $"""{"Zero TimeSpan",-22}{align TimeSpan.Zero,26}
"""

// Display the ticks-per-time-unit fields.
printfn $"""{"Ticks per day",-22}{TimeSpan.TicksPerDay,18:N0}"""
printfn $"""{"Ticks per hour",-22}{TimeSpan.TicksPerHour,18:N0}""" 
printfn $"""{"Ticks per minute",-22}{TimeSpan.TicksPerMinute,18:N0}""" 
printfn $"""{"Ticks per second",-22}{TimeSpan.TicksPerSecond,18:N0}""" 
printfn $"""{"Ticks per millisecond",-22}{TimeSpan.TicksPerMillisecond,18:N0}""" 

(*
This example of the fields of the TimeSpan class
generates the following output.

Field                              Value
-----                              -----
Maximum TimeSpan       10675199.02:48:05.4775807
Minimum TimeSpan      -10675199.02:48:05.4775808
Zero TimeSpan                   00:00:00

Ticks per day            864,000,000,000
Ticks per hour            36,000,000,000
Ticks per minute             600,000,000
Ticks per second              10,000,000
Ticks per millisecond             10,000
*)
//</Snippet1>