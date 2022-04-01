module getsystemtimezones1

// <Snippet6>
open System
open System.Globalization
open System.IO
open System.Collections.ObjectModel

[<EntryPoint>]
let main _ =
    let OUTPUTFILENAME = @"C:\Temp\TimeZoneInfo.txt"

    let dateFormats = CultureInfo.CurrentCulture.DateTimeFormat
    let timeZones = TimeZoneInfo.GetSystemTimeZones() 
    use sw = new StreamWriter(OUTPUTFILENAME, false)

    for timeZone in timeZones do
        let hasDST = timeZone.SupportsDaylightSavingTime
        let offsetFromUtc = timeZone.BaseUtcOffset
    
        sw.WriteLine $"ID: {timeZone.Id}"
        sw.WriteLine $"   Display Name: {timeZone.DisplayName, 40}"
        sw.WriteLine $"   Standard Name: {timeZone.StandardName, 39}"
        sw.Write $"   Daylight Name: {timeZone.DaylightName, 39}"
        sw.Write(if hasDST then "   ***Has " else "   ***Does Not Have ")
        sw.WriteLine "Daylight Saving Time***"
        let offsetString = $"{offsetFromUtc.Hours} hours, {offsetFromUtc.Minutes} minutes"
        sw.WriteLine $"   Offset from UTC: {offsetString, 40}"
        let adjustRules = timeZone.GetAdjustmentRules()
        sw.WriteLine $"   Number of adjustment rules: {adjustRules.Length, 26}"
        if adjustRules.Length > 0 then
            sw.WriteLine "   Adjustment Rules:"
            for rule in adjustRules do
                let transTimeStart = rule.DaylightTransitionStart
                let transTimeEnd = rule.DaylightTransitionEnd 
            
                sw.WriteLine $"      From {rule.DateStart} to {rule.DateEnd}"
                sw.WriteLine $"      Delta: {rule.DaylightDelta}"
                if not transTimeStart.IsFixedDateRule then
                    sw.WriteLine $"      Begins at {transTimeStart.TimeOfDay:t} on {transTimeStart.DayOfWeek} of week {transTimeStart.Week} of {dateFormats.MonthNames[transTimeStart.Month - 1]}"
                    sw.WriteLine $"      Ends at {transTimeEnd.TimeOfDay:t} on {transTimeEnd.DayOfWeek} of week {transTimeEnd.Week} of {dateFormats.MonthNames[transTimeEnd.Month - 1]}"
                else
                    sw.WriteLine $"      Begins at {transTimeStart.TimeOfDay:t} on {transTimeStart.Day} {dateFormats.MonthNames[transTimeStart.Month - 1]}"
                    sw.WriteLine $"      Ends at {transTimeEnd.TimeOfDay:t} on {transTimeEnd.Day} {dateFormats.MonthNames[transTimeEnd.Month - 1]}"
    0
// </Snippet6>