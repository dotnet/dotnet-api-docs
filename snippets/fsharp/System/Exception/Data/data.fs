//<snippet1>
// This example demonstrates the Exception.Data property.
open System
open System.Collections

let nestedRoutine2 displayDetails =
    let e = Exception "This statement is the original exception message."
    if displayDetails then
        let s = "Information from nestedRoutine2."
        let i = -903
        let dt = DateTime.Now
        e.Data.Add("stringInfo", s)
        e.Data["IntInfo"] <- i
        e.Data["DateTimeInfo"] <- dt
    raise e

let nestedRoutine1 displayDetails =
    try
        nestedRoutine2 displayDetails
    with e ->
        e.Data["ExtraInfo"] <- "Information from nestedRoutine1."
        e.Data.Add("MoreExtraInfo", "More information from nestedRoutine1.")
        reraise ()

let runTest displayDetails =
    try
        nestedRoutine1 displayDetails
    with e ->
        printfn "An exception was thrown."
        printfn $"{e.Message}"
        if e.Data.Count > 0 then
            printfn "  Extra details:"
            for de in e.Data do
                let de = de :?> DictionaryEntry
                printfn $"""    Key: {"'" + de.Key.ToString() + "'",-20}      Value: {de.Value}"""

printfn "\nException with some extra information..."
runTest false
printfn "\nException with all extra information..."
runTest true

   
// The example displays the following output:
//    Exception with some extra information...
//    An exception was thrown.
//    This statement is the original exception message.
//      Extra details:
//        Key: 'ExtraInfo'               Value: Information from NestedRoutine1.
//        Key: 'MoreExtraInfo'           Value: More information from NestedRoutine1.
//
//    Exception with all extra information...
//    An exception was thrown.
//    This statement is the original exception message.
//      Extra details:
//        Key: 'stringInfo'              Value: Information from NestedRoutine2.
//        Key: 'IntInfo'                 Value: -903
//        Key: 'DateTimeInfo'            Value: 7/29/2013 10:50:13 AM
//        Key: 'ExtraInfo'               Value: Information from NestedRoutine1.
//        Key: 'MoreExtraInfo'           Value: More information from NestedRoutine1.
//</snippet1>