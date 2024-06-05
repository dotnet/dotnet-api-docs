module program

// <Snippet1>
open System

let cst = TimeZoneInfo.FindSystemTimeZoneById "Central Standard Time"
let local = TimeZoneInfo.Local
printfn $"{TimeZoneInfo.ConvertTime(DateTime.Now, local, cst)}"

TimeZoneInfo.ClearCachedData()
try
   printfn $"{TimeZoneInfo.ConvertTime(DateTime.Now, local, cst)}"
with :? ArgumentException as e ->
   printfn $"{e.GetType().Name}\n   {e.Message}"
// </Snippet1>