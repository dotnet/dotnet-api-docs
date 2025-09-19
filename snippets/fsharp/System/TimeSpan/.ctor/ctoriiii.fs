module ctoriiii

//<Snippet3>
open System

// Create a TimeSpan object and display its value.
let createTimeSpan days hours minutes seconds =
    let elapsedTime = TimeSpan(days, hours, minutes, seconds)

    // Format the constructor for display.
    let ctor = $"TimeSpan( {days}, {hours}, {minutes}, {seconds} )"

    // Display the constructor and its value.
    printfn $"{ctor,-44}{elapsedTime,16}" 
    
printfn "%-44s%16s" "Constructor" "Value"
printfn "%-44s%16s" "-----------" "-----" 

createTimeSpan 10 20 30 40
createTimeSpan -10 20 30 40
createTimeSpan 0 0 0 937840
createTimeSpan 1000 2000 3000 4000
createTimeSpan 1000 -2000 -3000 -4000
createTimeSpan 999999 999999 999999 999999
// The example displays the following output:
//       Constructor                                            Value
//       -----------                                            -----
//       TimeSpan( 10, 20, 30, 40 )                       10.20:30:40
//       TimeSpan( -10, 20, 30, 40 )                      -9.03:29:20
//       TimeSpan( 0, 0, 0, 937840 )                      10.20:30:40
//       TimeSpan( 1000, 2000, 3000, 4000 )             1085.11:06:40
//       TimeSpan( 1000, -2000, -3000, -4000 )           914.12:53:20
//       TimeSpan( 999999, 999999, 999999, 999999 )  1042371.15:25:39
//</Snippet3>