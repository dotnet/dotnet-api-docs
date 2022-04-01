module Progarm

open System
// <Snippet1>
let datNowLocal = DateTime.Now
printfn $"Converting {datNowLocal}, Kind {datNowLocal.Kind}:"
printfn $"   ConvertTimeToUtc: {TimeZoneInfo.ConvertTimeToUtc datNowLocal}, Kind {TimeZoneInfo.ConvertTimeToUtc(datNowLocal).Kind}\n"

let datNowUtc = DateTime.UtcNow
printfn $"Converting {datNowUtc}, Kind {datNowUtc.Kind}"
printfn $"   ConvertTimeToUtc: {TimeZoneInfo.ConvertTimeToUtc datNowUtc}, Kind {TimeZoneInfo.ConvertTimeToUtc(datNowUtc).Kind}\n"

let datNow = DateTime(2007, 10, 26, 13, 32, 00)
printfn $"Converting {datNow}, Kind {datNow.Kind}"
printfn $"   ConvertTimeToUtc: {TimeZoneInfo.ConvertTimeToUtc datNow}, Kind {TimeZoneInfo.ConvertTimeToUtc(datNow).Kind}\n"

let datAmbiguous = DateTime(2007, 11, 4, 1, 30, 00)
printfn $"Converting {datAmbiguous}, Kind {datAmbiguous.Kind}, Ambiguous {TimeZoneInfo.Local.IsAmbiguousTime datAmbiguous}"
printfn $"   ConvertTimeToUtc: {TimeZoneInfo.ConvertTimeToUtc datAmbiguous}, Kind {TimeZoneInfo.ConvertTimeToUtc(datAmbiguous).Kind}\n"

let datInvalid = DateTime(2007, 3, 11, 02, 30, 00)    
printfn $"Converting {datInvalid}, Kind {datInvalid.Kind}, Invalid {TimeZoneInfo.Local.IsInvalidTime datInvalid}"
try
    printfn $"   ConvertTimeToUtc: {TimeZoneInfo.ConvertTimeToUtc datInvalid}, Kind {TimeZoneInfo.ConvertTimeToUtc(datInvalid).Kind}"
with :? ArgumentException as e ->
    printfn $"   {e.GetType().Name}: Cannot convert {datInvalid} to UTC."
printfn ""

let datNearMax = DateTime(9999, 12, 31, 22, 00, 00)
printfn $"Converting {datNearMax}, Kind {datNearMax.Kind}"
printfn $"   ConvertTimeToUtc: {TimeZoneInfo.ConvertTimeToUtc datNearMax}, Kind {TimeZoneInfo.ConvertTimeToUtc(datNearMax).Kind}\n"
//
// This example produces the following output if the local time zone 
// is Pacific Standard Time:
//
//    Converting 8/31/2007 2:26:28 PM, Kind Local:
//       ConvertTimeToUtc: 8/31/2007 9:26:28 PM, Kind Utc
//    
//    Converting 8/31/2007 9:26:28 PM, Kind Utc
//       ConvertTimeToUtc: 8/31/2007 9:26:28 PM, Kind Utc
//    
//    Converting 10/26/2007 1:32:00 PM, Kind Unspecified
//       ConvertTimeToUtc: 10/26/2007 8:32:00 PM, Kind Utc
//    
//    Converting 11/4/2007 1:30:00 AM, Kind Unspecified, Ambiguous True
//       ConvertTimeToUtc: 11/4/2007 9:30:00 AM, Kind Utc
//    
//    Converting 3/11/2007 2:30:00 AM, Kind Unspecified, Invalid True
//       ArgumentException: Cannot convert 3/11/2007 2:30:00 AM to UTC.
//    
//    Converting 12/31/9999 10:00:00 PM, Kind Unspecified
//       ConvertTimeToUtc: 12/31/9999 11:59:59 PM, Kind Utc
// 
// </Snippet1>

// <Snippet3>
let currentTime = DateTime.Now
printfn "Current Times:\n"
printfn $"""Los Angeles: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Pacific Standard Time")}"""
printfn $"""Chicago: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central Standard Time")}"""
printfn $"""New York: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Eastern Standard Time")}"""
printfn $"""London: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "GMT Standard Time")}"""
printfn $"""Moscow: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Russian Standard Time")}"""
printfn $"""New Delhi: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "India Standard Time")}"""
printfn $"""Beijing: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "China Standard Time")}"""
printfn $"""Tokyo: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Tokyo Standard Time")}"""
// </Snippet3>      