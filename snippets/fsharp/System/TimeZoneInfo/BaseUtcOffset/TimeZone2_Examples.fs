module TimeZone2

open System

do
    // <Snippet1>
    let localZone = TimeZoneInfo.Local
    printfn $"""The {localZone.DisplayName} time zone is {abs localZone.BaseUtcOffset.Hours}:{abs localZone.BaseUtcOffset.Minutes} {if localZone.BaseUtcOffset >= TimeSpan.Zero then "later" else "earlier"} than Coordinated Universal Time."""
    // </Snippet1>                  

do
    let localZone = TimeZoneInfo.Local
    printfn $"Local Time Zone ID: {localZone.Id}"
    printfn $"   Display Name is: {localZone.DisplayName}."
    printfn $"   Standard name is: {localZone.StandardName}."
    printfn $"   Daylight saving name is: {localZone.DaylightName}."

do
    // <Snippet3>
    let universalZone = TimeZoneInfo.Utc
    printfn $"The universal time zone is {universalZone.DisplayName}."
    printfn $"Its standard name is {universalZone.StandardName}."
    printfn $"Its daylight savings name is {universalZone.DaylightName}."
    // </Snippet3>

do
    // <Snippet4>
    let zones = TimeZoneInfo.GetSystemTimeZones()
    for zone in zones do
        if not zone.SupportsDaylightSavingTime then
            Console.WriteLine zone.DisplayName
    // </Snippet4> 

do
    // <Snippet5>
    let zones = TimeZoneInfo.GetSystemTimeZones()
    printfn $"The local system has the following {zones.Count} time zones"
    for zone in zones do
        printfn $"{zone.Id}"
    // </Snippet5>

do
    // <Snippet7> 
    let thisTimeZone = TimeZoneInfo.Local
    let zone1 = TimeZoneInfo.FindSystemTimeZoneById "Pacific Standard Time"
    let zone2 = TimeZoneInfo.FindSystemTimeZoneById "Eastern Standard Time"
    printfn $"{thisTimeZone.Equals zone1}"
    printfn $"{thisTimeZone.Equals zone2}"
    // </Snippet7>

do
    // <Snippet8>
    // Specify DateTimeKind in Date constructor
    let baseTime = DateTime(2007, 11, 4, 0, 59, 00, DateTimeKind.Unspecified)

    // Get Pacific Standard Time zone
    let pstZone = TimeZoneInfo.FindSystemTimeZoneById "Pacific Standard Time"

    // List possible ambiguous times for 63-minute interval, from 12:59 AM to 2:01 AM 
    for i = 0 to 62 do
    // Because of assignment, newTime.Kind is also DateTimeKind.Unspecified
        let newTime = baseTime.AddMinutes i   
        printfn $"{newTime} is ambiguous: {pstZone.IsAmbiguousTime newTime}"
    // </Snippet8>      

do
    // <Snippet9>
    // Specify DateTimeKind in Date constructor
    let baseTime = DateTime(2007, 3, 11, 1, 59, 0, DateTimeKind.Unspecified)
    
    // Get Pacific Standard Time zone
    let pstZone = TimeZoneInfo.FindSystemTimeZoneById "Pacific Standard Time"

    // List possible invalid times for a 63-minute interval, from 1:59 AM to 3:01 AM
    for i = 0 to 62 do
        // Because of assignment, newTime.Kind is also DateTimeKind.Unspecified
        let newTime = baseTime.AddMinutes i
        printfn $"{newTime} is invalid: {pstZone.IsInvalidTime newTime}"
    // </Snippet9>