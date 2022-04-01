module ShowTimeZoneNames1

// <Snippet2>
open System

let localZone = TimeZoneInfo.Local
printfn $"Local Time Zone ID: {localZone.Id}"
printfn $"   Display Name is: {localZone.DisplayName}."
printfn $"   Standard name is: {localZone.StandardName}."
printfn $"   Daylight saving name is: {localZone.DaylightName}."
// The example displays output like the following:
//     Local Time Zone ID: Pacific Standard Time
//        Display Name is: (UTC-08:00) Pacific Time (US & Canada).
//        Standard name is: Pacific Standard Time.
//        Daylight saving name is: Pacific Daylight Time.
// </Snippet2>