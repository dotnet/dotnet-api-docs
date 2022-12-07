module program

open System
open System.Globalization

let createCustomTimeZone () =
    // <Snippet1>
    // Create alternate Central Standard Time to include historical time zone information
    let delta = TimeSpan(1, 0, 0)
    let adjustmentList = ResizeArray()

    // Define end rule (for 1976-2006)
    let transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(DateTime(1, 1, 1, 2, 0, 0), 10, 5, DayOfWeek.Sunday)
    // Define rule (1976-1986)
    let transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(DateTime(1, 1, 1, 2, 0, 0), 04, 05, DayOfWeek.Sunday)
    TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(DateTime(1976, 1, 1), DateTime(1986, 12, 31), delta, transitionRuleStart, transitionRuleEnd)
    |> adjustmentList.Add
    // Define rule (1987-2006)  
    let transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(DateTime(1, 1, 1, 2, 0, 0), 04, 01, DayOfWeek.Sunday)
    TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(DateTime(1987, 1, 1), DateTime(2006, 12, 31), delta, transitionRuleStart, transitionRuleEnd)
    |> adjustmentList.Add
    // Define rule (2007- )  
    let transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(DateTime(1, 1, 1, 2, 0, 0), 03, 02, DayOfWeek.Sunday)
    let transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(DateTime(1, 1, 1, 2, 0, 0), 11, 01, DayOfWeek.Sunday)
    TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(DateTime(2007, 01, 01), DateTime.MaxValue.Date, delta, transitionRuleStart, transitionRuleEnd)
    |> adjustmentList.Add
                
    // Create custom U.S. Central Standard Time zone         
    TimeZoneInfo.CreateCustomTimeZone("Central Standard Time", TimeSpan(-6, 0, 0), 
                                      "(GMT-06:00) Central Time (US Only)", "Central Standard Time", 
                                      "Central Daylight Time", adjustmentList.ToArray())       
    // </Snippet1>   

let compareRulesForEquality () =
    // <Snippet2>
    // Get CST, Canadian CST, and Mexican CST adjustment rules
    let usCstAdjustments =
        let timeZoneName = "Central Standard Time"
        try
            TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetAdjustmentRules()
        with
        | :? TimeZoneNotFoundException ->
            printfn $"The {timeZoneName} time zone is not defined in the registry."
            null
        | :? InvalidTimeZoneException ->
            printfn $"Data for the {timeZoneName} time zone is invalid."
            null
    let canCstAdjustments = 
        let timeZoneName = "Canada Central Standard Time"
        try
            TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetAdjustmentRules()
        with
        | :? TimeZoneNotFoundException ->
            printfn $"The {timeZoneName} time zone is not defined in the registry."
            null
        | :? InvalidTimeZoneException ->
            printfn $"Data for the {timeZoneName} time zone is invalid."
            null
    let mexCstAdjustments = 
        let timeZoneName = "Central Standard Time (Mexico)"
        try
            TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetAdjustmentRules()
        with
        | :? TimeZoneNotFoundException ->
            printfn $"The {timeZoneName} time zone is not defined in the registry."
            null
        | :? InvalidTimeZoneException ->
            printfn $"Data for the {timeZoneName} time zone is invalid."
            null
    // Determine if CST and other time zones have the same rules
    for rule in usCstAdjustments do
        printfn $"Comparing Central Standard Time rule for {rule.DateStart:d} to {rule.DateEnd:d} with:"
        // Compare with Canada Central Standard Time
        if canCstAdjustments.Length = 0 then
            printfn "   Canada Central Standard Time has no adjustment rules."
        else
            for canRule in canCstAdjustments do
                printfn $"""   Canadian CST for {canRule.DateStart:d} to {canRule.DateEnd:d}: {if rule.Equals canRule then "Equal" else "Not Equal"}"""

        // Compare with Mexico Central Standard Time
        if mexCstAdjustments.Length = 0 then
            printfn "   Mexican Central Standard Time has no adjustment rules."
        else
            for mexRule in mexCstAdjustments do
                printfn $"""   Mexican CST for {mexRule.DateStart:d} to {mexRule.DateEnd:d}: {if rule.Equals mexRule then "Equal" else "Not Equal"}"""
    // This code displays the following output to the console:
    // 
    // Comparing Central Standard Time rule for 1/1/0001 to 12/31/9999 with:
    //    Canada Central Standard Time has no adjustment rules.
    //    Mexican CST for 1/1/0001 to 12/31/9999: Equal
    // </Snippet2>

// <Snippet3>   
type WeekOfMonth = 
    | First = 1
    | Second = 2
    | Third = 3
    | Fourth = 4
    | Last = 5

let showStartAndEndDates () =
    // Get all time zones from system
    let timeZones = TimeZoneInfo.GetSystemTimeZones()
    let monthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
    // Get each time zone
    for timeZone in timeZones do
        let adjustments = timeZone.GetAdjustmentRules()
        // Display message for time zones with no adjustments
        if adjustments.Length = 0 then
            printfn $"{timeZone.StandardName} has no adjustment rules"
        else
            // Handle time zones with 1 or 2+ adjustments differently
            let mutable ctr = 0
            let showCount, spacer = 
                if adjustments.Length > 1 then
                    true, "   "
                else 
                    false, ""
            printfn $"{timeZone.StandardName} Adjustment rules"

            // Iterate adjustment rules
            for adjustment in adjustments do
                if showCount then
                    printfn $"   Adjustment rule #{ctr + 1}"
                    ctr <- ctr + 1
                // Display general adjustment information
                printfn $"{spacer}   Start Date: {adjustment.DateStart:D}"
                printfn $"{spacer}   End Date: {adjustment.DateEnd:D}"
                printfn $"{spacer}   Time Change: {adjustment.DaylightDelta.Hours}:{adjustment.DaylightDelta.Minutes:D2} hours"
                // Get transition start information
                let transitionStart = adjustment.DaylightTransitionStart
                printf $"{spacer}   Annual Start: "
                if transitionStart.IsFixedDateRule then
                    printfn $"On {monthNames[transitionStart.Month - 1]} {transitionStart.Day} at {transitionStart.TimeOfDay:t}"
                else
                    printfn $"The {transitionStart.Week |> enum<WeekOfMonth>} {transitionStart.DayOfWeek} of {monthNames[transitionStart.Month - 1]} at {transitionStart.TimeOfDay:t}"
                // Get transition end information
                let transitionEnd = adjustment.DaylightTransitionEnd
                printf $"{spacer}   Annual End: "
                if transitionEnd.IsFixedDateRule then
                    printfn $"On {monthNames[transitionEnd.Month - 1]} {transitionEnd.Day} at {transitionEnd.TimeOfDay:t}"
                else
                    printfn $"The {enum<WeekOfMonth> transitionEnd.Week} {transitionEnd.DayOfWeek} of {monthNames[transitionEnd.Month - 1]} at {transitionEnd.TimeOfDay:t}" 
        Console.WriteLine()
// </Snippet3>
createCustomTimeZone () |> ignore
compareRulesForEquality ()
showStartAndEndDates ()
