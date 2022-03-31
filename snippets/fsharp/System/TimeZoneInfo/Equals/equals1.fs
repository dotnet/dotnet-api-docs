// <Snippet1>
open System

let thisTimeZone = TimeZoneInfo.Local
let obj1 = TimeZoneInfo.FindSystemTimeZoneById "Pacific Standard Time"
let obj2 = TimeZoneInfo.FindSystemTimeZoneById "Eastern Standard Time"
printfn $"{thisTimeZone.Equals obj1}"
printfn $"{thisTimeZone.Equals obj2}"
// The example displays the following output:
//      True
//      False
// </Snippet1>