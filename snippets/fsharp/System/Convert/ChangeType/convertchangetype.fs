module convertchangetype

//<snippet1>
open System

let d = -2.345
let i = Convert.ChangeType(d, typeof<int>) :?> int

printfn $"The double value {d} when converted to an int becomes {i}"

let s = "12/12/98"
let dt = Convert.ChangeType(s, typeof<DateTime>) :?> DateTime

printfn $"The string value {s} when converted to a Date becomes {dt}"
//</snippet1>