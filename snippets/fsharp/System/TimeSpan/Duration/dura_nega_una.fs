//<Snippet1>
// Example of the TimeSpan.Duration( ) and TimeSpan.Negate( ) methods,
// and the TimeSpan Unary Negation and Unary Plus operators.
open System

let showDurationNegate (interval: TimeSpan) =
    // Display the TimeSpan value and the results of the 
    // Duration and Negate methods.
    printfn $"{interval,22}{interval.Duration(),22}{interval.Negate(),22}"

printfn "This example of TimeSpan.Duration( ), TimeSpan.Negate( ), \nand the TimeSpan Unary Negation and Unary Plus operators \ngenerates the following output.\n" 
printfn "%22s%22s%22s" "TimeSpan" "Duration( )" "Negate( )"
printfn "%22s%22s%22s" "--------" "-----------" "---------"

// Create TimeSpan objects and apply the Unary Negation
// and Unary Plus operators to them.
showDurationNegate (TimeSpan 1)
showDurationNegate (TimeSpan -1234567)
showDurationNegate (+ TimeSpan(0, 0, 10, -20, -30) )
showDurationNegate (+ TimeSpan(0, -10, 20, -30, 40) )
showDurationNegate (- TimeSpan(1, 10, 20, 40, 160 ) )
showDurationNegate (- TimeSpan(-10, -20, -30, -40, -50) )

(*
This example of TimeSpan.Duration( ), TimeSpan.Negate( ),
and the TimeSpan Unary Negation and Unary Plus operators
generates the following output.

              TimeSpan           Duration( )             Negate( )
              --------           -----------             ---------
      00:00:00.0000001      00:00:00.0000001     -00:00:00.0000001
     -00:00:00.1234567      00:00:00.1234567      00:00:00.1234567
      00:09:39.9700000      00:09:39.9700000     -00:09:39.9700000
     -09:40:29.9600000      09:40:29.9600000      09:40:29.9600000
   -1.10:20:40.1600000    1.10:20:40.1600000    1.10:20:40.1600000
   10.20:30:40.0500000   10.20:30:40.0500000  -10.20:30:40.0500000
*)
//</Snippet1>