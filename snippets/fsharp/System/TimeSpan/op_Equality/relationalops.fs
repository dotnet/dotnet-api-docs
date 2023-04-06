//<Snippet1>
// Example of the TimeSpan relational operators.
open System

let dataPrint x y = printfn $"%34s{x}    {y}"

// Compare TimeSpan parameters, and display them with the results.
let compareTimeSpans (left: TimeSpan) (right: TimeSpan) rightText =
    printfn ""
    dataPrint ("Right: " + rightText) right
    dataPrint "Left == Right" (left = right)
    dataPrint "Left >  Right" (left > right)
    dataPrint "Left >= Right" (left >= right)
    dataPrint "Left != Right" (left <> right)
    dataPrint "Left <  Right" (left < right)
    dataPrint "Left <= Right" (left <= right)

let left = TimeSpan( 2, 0, 0 )

printfn "This example of the TimeSpan relational operators generates \nthe following output. It creates several different TimeSpan \nobjects and compares them with a 2-hour TimeSpan.\n"
dataPrint "Left: TimeSpan( 2, 0, 0 )" left

// Create objects to compare with a 2-hour TimeSpan.
compareTimeSpans left (TimeSpan(0, 120, 0)) "TimeSpan( 0, 120, 0 )"
compareTimeSpans left (TimeSpan(2, 0, 1)) "TimeSpan( 2, 0, 1 )"
compareTimeSpans left (TimeSpan(2, 0, -1)) "TimeSpan( 2, 0, -1 )"
compareTimeSpans left (TimeSpan.FromDays(1. / 12.)) "TimeSpan.FromDays( 1 / 12 )"

(*
This example of the TimeSpan relational operators generates
the following output. It creates several different TimeSpan
objects and compares them with a 2-hour TimeSpan.

         Left: TimeSpan( 2, 0, 0 )    02:00:00

      Right: TimeSpan( 0, 120, 0 )    02:00:00
                     Left == Right    True
                     Left >  Right    False
                     Left >= Right    True
                     Left != Right    False
                     Left <  Right    False
                     Left <= Right    True

        Right: TimeSpan( 2, 0, 1 )    02:00:01
                     Left == Right    False
                     Left >  Right    False
                     Left >= Right    False
                     Left != Right    True
                     Left <  Right    True
                     Left <= Right    True

       Right: TimeSpan( 2, 0, -1 )    01:59:59
                     Left == Right    False
                     Left >  Right    True
                     Left >= Right    True
                     Left != Right    True
                     Left <  Right    False
                     Left <= Right    False

Right: TimeSpan.FromDays( 1 / 12 )    02:00:00
                     Left == Right    True
                     Left >  Right    False
                     Left >= Right    True
                     Left != Right    False
                     Left <  Right    False
                     Left <= Right    True
*)
//</Snippet1>