module ctoriiiii

//<Snippet4>
// Example of the TimeSpan( int, int, int, int, int ) constructor. 
open System

// Create a TimeSpan object and display its value.
let createTimeSpan days hours minutes seconds millisec =
    let elapsedTime = TimeSpan(days, hours, minutes, seconds, millisec)

    // Format the constructor for display.
    let ctor = $"TimeSpan( {days}, {hours}, {minutes}, {seconds}, {millisec} )"

    // Display the constructor and its value.
    printfn $"{ctor,-48}{elapsedTime,24}"

printfn "This example of the TimeSpan( int, int, int, int, int ) \nconstructor generates the following output.\n"
printfn "%-48s%16s" "Constructor" "Value"
printfn "%-48s%16s" "-----------" "-----"

createTimeSpan 10 20 30 40 50
createTimeSpan -10 20 30 40 50
createTimeSpan 0 0 0 0 937840050
createTimeSpan 1111 2222 3333 4444 5555
createTimeSpan 1111 -2222 -3333 -4444 -5555
createTimeSpan 99999 99999 99999 99999 99999

(*
This example of the TimeSpan( int, int, int, int, int )
constructor generates the following output.

Constructor                                                Value
-----------                                                -----
TimeSpan( 10, 20, 30, 40, 50 )                       10.20:30:40.0500000
TimeSpan( -10, 20, 30, 40, 50 )                      -9.03:29:19.9500000
TimeSpan( 0, 0, 0, 0, 937840050 )                    10.20:30:40.0500000
TimeSpan( 1111, 2222, 3333, 4444, 5555 )           1205.22:47:09.5550000
TimeSpan( 1111, -2222, -3333, -4444, -5555 )       1016.01:12:50.4450000
TimeSpan( 99999, 99999, 99999, 99999, 99999 )    104236.05:27:18.9990000
*)
//</Snippet4>