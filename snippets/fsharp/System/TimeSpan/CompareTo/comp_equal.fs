module comp_equal

//<Snippet2>
// Example of the TimeSpan.Compare( TimeSpan, TimeSpan ) and 
// TimeSpan.Equals( TimeSpan, TimeSpan ) methods.
open System

// Compare TimeSpan parameters, and display them with the results.
let compareTimeSpans left right rightText =
    printfn $"""
{"Right: " + rightText,-38}{right}"""
    printfn $"""{"TimeSpan.Equals( Left, Right )",-38}{TimeSpan.Equals(left, right)}"""
    printfn $"""{"TimeSpan.Compare( Left, Right )",-38}{TimeSpan.Compare(left, right)}""" 

let left = TimeSpan(2, 0, 0)

printfn "This example of the TimeSpan.Equals( TimeSpan, TimeSpan ) and \nTimeSpan.Compare( TimeSpan, TimeSpan ) methods generates the \nfollowing output by creating several different TimeSpan \nobjects and comparing them with a 2-hour TimeSpan.\n"
printfn $"""{"Left: TimeSpan( 2, 0, 0 )",-38}{left}"""

// Create objects to compare with a 2-hour TimeSpan.
compareTimeSpans left (TimeSpan(0, 120, 0)) 
    "TimeSpan( 0, 120, 0 )"
compareTimeSpans left (TimeSpan( 2, 0, 1 ))
    "TimeSpan( 2, 0, 1 )"
compareTimeSpans left (TimeSpan( 2, 0, -1 )) 
    "TimeSpan( 2, 0, -1 )"
compareTimeSpans left (TimeSpan 72000000000L)
    "TimeSpan( 72000000000 )"
compareTimeSpans left (TimeSpan.FromDays( 1. / 12. ))
    "TimeSpan.FromDays( 1 / 12 )"

(*
This example of the TimeSpan.Equals( TimeSpan, TimeSpan ) and
TimeSpan.Compare( TimeSpan, TimeSpan ) methods generates the
following output by creating several different TimeSpan
objects and comparing them with a 2-hour TimeSpan.

Left: TimeSpan( 2, 0, 0 )             02:00:00

Right: TimeSpan( 0, 120, 0 )          02:00:00
TimeSpan.Equals( Left, Right )        True
TimeSpan.Compare( Left, Right )       0

Right: TimeSpan( 2, 0, 1 )            02:00:01
TimeSpan.Equals( Left, Right )        False
TimeSpan.Compare( Left, Right )       -1

Right: TimeSpan( 2, 0, -1 )           01:59:59
TimeSpan.Equals( Left, Right )        False
TimeSpan.Compare( Left, Right )       1

Right: TimeSpan( 72000000000 )        02:00:00
TimeSpan.Equals( Left, Right )        True
TimeSpan.Compare( Left, Right )       0

Right: TimeSpan.FromDays( 1 / 12 )    02:00:00
TimeSpan.Equals( Left, Right )        True
TimeSpan.Compare( Left, Right )       0
*)
//</Snippet2>