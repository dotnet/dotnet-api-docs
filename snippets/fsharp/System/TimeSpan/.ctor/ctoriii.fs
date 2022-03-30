module ctoriii

//<Snippet2>
// Example of the TimeSpan( int, int, int ) constructor.
open System

// Create a TimeSpan object and display its value.
let createTimeSpan hours minutes seconds =
    let elapsedTime = TimeSpan(hours, minutes, seconds)

    // Format the constructor for display.
    let ctor = $"TimeSpan( {hours}, {minutes}, {seconds} )"

    // Display the constructor and its value.
    printfn $"{ctor,-37}{elapsedTime,16}"

printfn "This example of the TimeSpan( int, int, int ) \nconstructor generates the following output.\n"
printfn "%-37s%16s" "Constructor" "Value"
printfn "%-37s%16s" "-----------" "-----"

createTimeSpan 10 20 30
createTimeSpan -10 20 30
createTimeSpan 0 0 37230
createTimeSpan 1000 2000 3000
createTimeSpan 1000 -2000 -3000
createTimeSpan 999999 999999 999999

(*
This example of the TimeSpan( int, int, int )
constructor generates the following output.

Constructor                                     Value
-----------                                     -----
TimeSpan( 10, 20, 30 )                       10:20:30
TimeSpan( -10, 20, 30 )                     -09:39:30
TimeSpan( 0, 0, 37230 )                      10:20:30
TimeSpan( 1000, 2000, 3000 )              43.02:10:00
TimeSpan( 1000, -2000, -3000 )            40.05:50:00
TimeSpan( 999999, 999999, 999999 )     42372.15:25:39
*)
//</Snippet2>