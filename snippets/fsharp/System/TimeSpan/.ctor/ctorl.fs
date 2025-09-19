module ctorl

//<Snippet1>
// Example of the TimeSpan( long ) constructor.
open System

// Create a TimeSpan object and display its value.
let createTimeSpan ticks =
    let elapsedTime = TimeSpan ticks

    // Format the constructor for display.
    let ctor = $"TimeSpan( {ticks} )"

    // Pad the end of a TimeSpan string with spaces if
    // it does not contain milliseconds.
    let elapsedStr = string elapsedTime
    let pointIndex = elapsedStr.IndexOf ':'

    let pointIndex = elapsedStr.IndexOf('.', pointIndex)
    let elapsedStr =
        if pointIndex < 0 then elapsedStr + "        "
        else elapsedStr

    // Display the constructor and its value.
    printfn $"{ctor,-33}{elapsedStr,24}"

Console.WriteLine( 
    "This example of the TimeSpan( long ) constructor " +
    "\ngenerates the following output.\n" )
Console.WriteLine( "{0,-33}{1,16}", "Constructor", "Value" )
Console.WriteLine( "{0,-33}{1,16}", "-----------", "-----" )

createTimeSpan 1L        
createTimeSpan 999999L       
createTimeSpan -1000000000000L    
createTimeSpan 18012202000000L 
createTimeSpan 999999999999999999L
createTimeSpan 1000000000000000000L

(*
This example of the TimeSpan( long ) constructor
generates the following output.

Constructor                                 Value
-----------                                 -----
TimeSpan( 1 )                            00:00:00.0000001
TimeSpan( 999999 )                       00:00:00.0999999
TimeSpan( -1000000000000 )            -1.03:46:40
TimeSpan( 18012202000000 )            20.20:20:20.2000000
TimeSpan( 999999999999999999 )   1157407.09:46:39.9999999
TimeSpan( 1000000000000000000 )  1157407.09:46:40
*)
//</Snippet1>