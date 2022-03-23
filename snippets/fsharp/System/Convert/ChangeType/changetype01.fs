module changetype01

// <Snippet2>
open System

let d = -2.345
let i = Convert.ChangeType(d, TypeCode.Int32) :?> int

printfn $"The Double {d} when converted to an Int32 is {i}"

let s = "12/12/2009"
let dt = Convert.ChangeType(s, typeof<DateTime>) :?> DateTime

printfn $"The String {s} when converted to a Date is {dt}"
// The example displays the following output:
//    The Double -2.345 when converted to an Int32 is -2
//    The String 12/12/2009 when converted to a Date is 12/12/2009 12:00:00 AM
// </Snippet2>