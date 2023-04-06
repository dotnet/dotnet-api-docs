module TimeZone2Concepts

open System

do
    // <Snippet8>
    let timeUtc = DateTime.UtcNow
    try
        let cstZone = TimeZoneInfo.FindSystemTimeZoneById "Central Standard Time"
        let cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone)
        printfn $"The date and time are {cstTime} {if cstZone.IsDaylightSavingTime cstTime then cstZone.DaylightName else cstZone.StandardName}."
    with
    | :? TimeZoneNotFoundException ->
        printfn "The registry does not define the Central Standard Time zone."
    | :? InvalidTimeZoneException ->
        printfn "Registry data on the Central Standard Time zone has been corrupted."
    // </Snippet8>

do
    // <Snippet9>
    let hwTime = DateTime(2007, 02, 01, 08, 00, 00)
    try
        let hwZone = TimeZoneInfo.FindSystemTimeZoneById "Hawaiian Standard Time"
        printfn $"{hwTime} {if hwZone.IsDaylightSavingTime hwTime then hwZone.DaylightName else hwZone.StandardName} is {TimeZoneInfo.ConvertTime(hwTime, hwZone, TimeZoneInfo.Local)} local time." 
    with
    | :? TimeZoneNotFoundException ->
        printfn "The registry does not define the Hawaiian Standard Time zone."
    | :? InvalidTimeZoneException ->
        printfn "Registry data on the Hawaiian Standard Time zone has been corrupted."
    // </Snippet9>