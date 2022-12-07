module Program

open System
open System.IO

do
    // <Snippet1>
    let displayName = "(GMT+06:00) Antarctica/Mawson Time"
    let standardName = "Mawson Time" 
    let offset = TimeSpan(06, 00, 00)
    let mawson = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName)
    printfn $"The current time is {TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, mawson)} {mawson.StandardName}"
    // </Snippet1>
    
do
    // <Snippet2>
    // Define transition times to/from DST
    let startTransition = 
        TimeZoneInfo.TransitionTime.CreateFloatingDateRule(DateTime(1, 1, 1, 4, 0, 0), 10, 2, DayOfWeek.Sunday) 
    let endTransition = 
        TimeZoneInfo.TransitionTime.CreateFloatingDateRule(DateTime(1, 1, 1, 3, 0, 0), 3, 2, DayOfWeek.Sunday)
    // Define adjustment rule
    let delta = TimeSpan(1, 0, 0)
    let adjustment = 
        TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(DateTime(1999, 10, 1), DateTime.MaxValue.Date, delta, startTransition, endTransition)
    // Create array for adjustment rules
    let adjustments = [| adjustment |]
    // Define other custom time zone arguments
    let displayName = "(GMT-04:00) Antarctica/Palmer Time"
    let standardName = "Palmer Time"
    let daylightName = "Palmer Daylight Time"
    let offset = TimeSpan(-4, 0, 0)
    let palmer = 
        TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName, daylightName, adjustments)
    printfn $"The current time is {TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, palmer)} {palmer.StandardName}"
    // </Snippet2>

do 
    // <Snippet3>
    // Define transition times to/from DST
    let startTransition = 
        TimeZoneInfo.TransitionTime.CreateFloatingDateRule(DateTime(1, 1, 1, 4, 0, 0), 10, 2, DayOfWeek.Sunday) 
    let endTransition = 
        TimeZoneInfo.TransitionTime.CreateFloatingDateRule(DateTime(1, 1, 1,3, 0, 0), 3, 2, DayOfWeek.Sunday)
    // Define adjustment rule
    let delta = TimeSpan(1, 0, 0)
    let adjustment = 
        TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(DateTime(1999, 10, 1), DateTime.MaxValue.Date, delta, startTransition, endTransition)
    // Create array for adjustment rules
    let adjustments = [| adjustment |]
    // Define other custom time zone arguments
    let displayName = "(GMT-04:00) Antarctica/Palmer Time"
    let standardName = "Palmer Standard Time"
    let daylightName = "Palmer Daylight Time"
    let offset = TimeSpan(-4, 0, 0)
    // Create custom time zone without copying DST information
    let palmer = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName, daylightName, adjustments, true)
    // Indicate whether time zone//s adjustment rules are present
    printfn $"""{palmer.StandardName} {if String.IsNullOrEmpty palmer.DaylightName then "" else "(" + palmer.DaylightName + ")"}has {palmer.GetAdjustmentRules().Length} adjustment rules."""
    // Indicate whether time zone supports DST
    printfn $"{palmer.StandardName} supports DST: {palmer.SupportsDaylightSavingTime}"
    // </Snippet3>

// <Snippet4> 
let initializeTimeZone () =
    // Determine if South Pole time zone is defined in system
    try
        TimeZoneInfo.FindSystemTimeZoneById "Antarctica/South Pole Standard Time"
    // Time zone does not exist create it, store it in a text file, and return it
    with _ ->
        let filename = @".\TimeZoneInfo.txt"
        let mutable southPole = Unchecked.defaultof<TimeZoneInfo>
        let mutable found = false
        
        if File.Exists filename then
            use reader = new StreamReader(filename)
            while reader.Peek() >= 0 && not found do
                let timeZoneInfo = reader.ReadLine()
                if timeZoneInfo.Contains "Antarctica/South Pole" then
                    southPole <- TimeZoneInfo.FromSerializedString timeZoneInfo
                    reader.Close()
                    found <- true
        if not found then
            // Define transition times to/from DST
            let startTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(DateTime(1, 1, 1, 2, 0, 0), 10, 1, DayOfWeek.Sunday) 
            let endTransition = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(DateTime(1, 1, 1, 2, 0, 0), 3, 3, DayOfWeek.Sunday)
            // Define adjustment rule
            let delta = TimeSpan(1, 0, 0)
            let adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(DateTime(1989, 10, 1), DateTime.MaxValue.Date, delta, startTransition, endTransition)
            // Create array for adjustment rules
            let adjustments = [| adjustment |]
            // Define other custom time zone arguments
            let displayName = "(GMT+12:00) Antarctica/South Pole"
            let standardName = "Antarctica/South Pole Standard Time"
            let daylightName = "Antarctica/South Pole Daylight Time"
            let offset = TimeSpan(12, 0, 0)
            southPole <- TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName, daylightName, adjustments)
            // Write time zone to the file
            use writer = new StreamWriter(filename, true)
            writer.WriteLine(southPole.ToSerializedString())
        southPole
// </Snippet4>