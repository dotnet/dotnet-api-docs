module cto_eq_obj

//<Snippet1>
// Example of the TimeSpan.CompareTo( Object ) and 
// TimeSpan.Equals( Object ) methods.
open System

// Compare the TimeSpan to the Object parameters, 
// and display the Object parameters with the results.
let compTimeSpanToObject (left: TimeSpan) (right: obj) rightText =
    printfn $"""{"Object: " + rightText,-33}{right}"""
    printfn $"""{"Left.Equals( Object )",-33}{left.Equals right}"""
        
    printf "%-33s" "Left.CompareTo( Object )"

    // Catch the exception if CompareTo( ) throws one.
    try
        printfn $"{left.CompareTo right}\n" 
    with ex ->
        printfn $"Error: {ex.Message}\n"

let left = TimeSpan(0, 5, 0)

printfn "This example of the TimeSpan.Equals( Object ) and \nTimeSpan.CompareTo( Object ) methods generates the \nfollowing output by creating several different TimeSpan \nobjects and comparing them with a 5-minute TimeSpan.\n" 
printfn $"""{"Left: TimeSpan( 0, 5, 0 )",-33}{left}\n"""

// Create objects to compare with a 5-minute TimeSpan.
compTimeSpanToObject left (TimeSpan(0, 0, 300)) 
    "TimeSpan( 0, 0, 300 )"
compTimeSpanToObject left (TimeSpan(0, 5, 1)) 
    "TimeSpan( 0, 5, 1 )"
compTimeSpanToObject left (TimeSpan(0, 5, -1)) 
    "TimeSpan( 0, 5, -1 )"
compTimeSpanToObject left (TimeSpan 3000000000L ) 
    "TimeSpan( 3000000000 )"
compTimeSpanToObject left 3000000000L "long 3000000000L"
compTimeSpanToObject left "00:05:00" "string \"00:05:00\""

(*
This example of the TimeSpan.Equals( Object ) and
TimeSpan.CompareTo( Object ) methods generates the
following output by creating several different TimeSpan
objects and comparing them with a 5-minute TimeSpan.

Left: TimeSpan( 0, 5, 0 )        00:05:00

Object: TimeSpan( 0, 0, 300 )    00:05:00
Left.Equals( Object )            True
Left.CompareTo( Object )         0

Object: TimeSpan( 0, 5, 1 )      00:05:01
Left.Equals( Object )            False
Left.CompareTo( Object )         -1

Object: TimeSpan( 0, 5, -1 )     00:04:59
Left.Equals( Object )            False
Left.CompareTo( Object )         1

Object: TimeSpan( 3000000000 )   00:05:00
Left.Equals( Object )            True
Left.CompareTo( Object )         0

Object: long 3000000000L         3000000000
Left.Equals( Object )            False
Left.CompareTo( Object )         Error: Object must be of type TimeSpan.

Object: string "00:05:00"        00:05:00
Left.Equals( Object )            False
Left.CompareTo( Object )         Error: Object must be of type TimeSpan.
*)
//</Snippet1>