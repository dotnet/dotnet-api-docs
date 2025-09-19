module Program

open System
open System.Globalization

let compareForEquality () =
    // <Snippet1>
    let tt1 = TimeZoneInfo.TransitionTime.CreateFixedDateRule(DateTime(1, 1, 1, 02, 00, 00), 11, 03)
    let tt2 = TimeZoneInfo.TransitionTime.CreateFixedDateRule(DateTime(1, 1, 1, 02, 00, 00), 11, 03)
    let tt3 = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(DateTime(1, 1, 1, 02, 00, 00), 10, 05, DayOfWeek.Sunday)
    let tz = TimeZoneInfo.Local
    printfn $"{tt1.Equals tz}"         // Returns False (overload with argument of type Object)
    printfn $"{tt1.Equals tt1}"        // Returns True (an object always equals itself)
    printfn $"{tt1.Equals tt2}"        // Returns True (identical property values)
    printfn $"{tt1.Equals tt3}"        // Returns False (different property values)
    // </Snippet1>

let compareTransitionTimesForEquality () =
    // <Snippet7>
    let tt1 = TimeZoneInfo.TransitionTime.CreateFixedDateRule(DateTime(1, 1, 1, 02, 00, 00), 11, 03)
    let tt2 = TimeZoneInfo.TransitionTime.CreateFixedDateRule(DateTime(1, 1, 1, 02, 00, 00), 11, 03)
    let tt3 = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(DateTime(1, 1, 1, 02, 00, 00), 10, 05, DayOfWeek.Sunday)
    printfn $"{tt1.Equals tt1}"        // Returns True (an object always equals itself)
    printfn $"{tt1.Equals tt2}"        // Returns True (identical property values)
    printfn $"{tt1.Equals tt3}"        // Returns False (different property values)
    // </Snippet7>

let createTransitionRules () =
    // <Snippet2>
    let delta = TimeSpan(1, 0, 0)
    let adjustmentList = ResizeArray()
                        
    // Define a fictitious new time zone consisting of fixed and floating adjustment rules 
    // Define fixed rule (for 1900-1955)
    let transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFixedDateRule(DateTime(1, 1, 1, 2, 0, 0), 3, 15)
    let transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFixedDateRule(DateTime(1, 1, 1, 3, 0, 0), 11, 15)
    let adjustment = 
        TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(DateTime(1900, 1, 1), DateTime(1955, 12, 31), delta, transitionRuleStart, transitionRuleEnd)
    adjustmentList.Add adjustment
    // Define floating rule (for 1956- )
    let transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(DateTime(1, 1, 1, 2, 0, 0), 3, 5, DayOfWeek.Sunday)
    let transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(DateTime(1, 1, 1, 3, 0, 0), 10, 4, DayOfWeek.Sunday) 
    let adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(DateTime(1956, 1, 1), DateTime.MaxValue.Date, delta, transitionRuleStart, transitionRuleEnd)
    adjustmentList.Add adjustment 

    // Create fictitious time zone   
    let imaginaryTZ = 
        TimeZoneInfo.CreateCustomTimeZone("Fictitious Standard Time", TimeSpan(-9, 0, 0), 
                    "(GMT-09:00) Fictitious Time", "Fictitious Standard Time", 
                    "Fictitious Daylight Time", adjustmentList.ToArray())
    // </Snippet2> 
    ()

// <Snippet3>
let getFixedTransitionTimes () =
    let timeZones = TimeZoneInfo.GetSystemTimeZones()
    let dateInfo = CultureInfo.CurrentCulture.DateTimeFormat
    for zone in timeZones do
        let adjustmentRules = zone.GetAdjustmentRules()
        for adjustmentRule in adjustmentRules do
            let daylightStart = adjustmentRule.DaylightTransitionStart
            if daylightStart.IsFixedDateRule then
                printfn $"For {zone.StandardName}, daylight savings time begins at {daylightStart.TimeOfDay:t} on {dateInfo.GetMonthName daylightStart.Month} {daylightStart.Day} from {adjustmentRule.DateStart:d} to {adjustmentRule.DateEnd:d}." 
            let daylightEnd = adjustmentRule.DaylightTransitionEnd
            if daylightEnd.IsFixedDateRule then
                printfn $"For {zone.StandardName}, daylight savings time ends at {daylightEnd.TimeOfDay:t} on {dateInfo.GetMonthName daylightEnd.Month} {daylightEnd.Day} from {adjustmentRule.DateStart:d} to {adjustmentRule.DateEnd:d}." 
// </Snippet3>

// <Snippet4>
type WeekOfMonth =
    | First = 1
    | Second = 2
    | Third = 3
    | Fourth = 4
    | Last = 5

let getFloatingTransitionTimes () =
    let timeZones = TimeZoneInfo.GetSystemTimeZones()
    for zone in timeZones do
        let adjustmentRules = zone.GetAdjustmentRules()
        let dateInfo = CultureInfo.CurrentCulture.DateTimeFormat
        for adjustmentRule in adjustmentRules do
            let daylightStart = adjustmentRule.DaylightTransitionStart
            if not daylightStart.IsFixedDateRule then
                printfn $"{zone.StandardName}, {adjustmentRule.DateStart:d}-{adjustmentRule.DateEnd:d}: Begins at {daylightStart.TimeOfDay:t} on the {enum<WeekOfMonth> daylightStart.Week} {daylightStart.DayOfWeek} of {dateInfo.GetMonthName daylightStart.Month}." 
            
            let daylightEnd = adjustmentRule.DaylightTransitionEnd
            if not daylightEnd.IsFixedDateRule then
                printfn $"{zone.StandardName}, {adjustmentRule.DateStart:d}-{adjustmentRule.DateEnd:d}: Ends at {daylightEnd.TimeOfDay:t} on the {enum<WeekOfMonth> daylightEnd.Week} {daylightEnd.DayOfWeek} of {dateInfo.GetMonthName daylightEnd.Month}." 
// </Snippet4>

module AdditionalExamples =
    // <Snippet6>
    type WeekOfMonth =
        | First = 1
        | Second = 2
        | Third = 3
        | Fourth = 4
        | Last = 5

    let getAllTransitionTimes () =
        let timeZones = TimeZoneInfo.GetSystemTimeZones()
        let dateInfo = CultureInfo.CurrentCulture.DateTimeFormat
        
        for zone in timeZones do
            printfn $"{zone.StandardName} transition time information:"
            let adjustmentRules= zone.GetAdjustmentRules()
            
            // Indicate that time zone has no adjustment rules
            if adjustmentRules.Length = 0 then
                printfn "   No adjustment rules defined."
            else
                // Iterate adjustment rules       
                for adjustmentRule in adjustmentRules do
                    printfn $"   Adjustment rule from {adjustmentRule.DateStart:d} to {adjustmentRule.DateEnd:d}:"                                 
                    
                    // Get start of transition
                    let daylightStart = adjustmentRule.DaylightTransitionStart
                    // Display information on fixed date rule
                    if not daylightStart.IsFixedDateRule then
                        printfn $"      Begins at {daylightStart.TimeOfDay:t} on the {enum<WeekOfMonth> daylightStart.Week} {daylightStart.DayOfWeek} of {dateInfo.GetMonthName daylightStart.Month}."
                    // Display information on floating date rule 
                    else
                        printfn $"      Begins at {daylightStart.TimeOfDay:t} on the {enum<WeekOfMonth> daylightStart.Week} {daylightStart.DayOfWeek} of {dateInfo.GetMonthName daylightStart.Month}."
                    
                    // Get end of transition
                    let daylightEnd = adjustmentRule.DaylightTransitionEnd
                    // Display information on fixed date rule
                    if not daylightEnd.IsFixedDateRule then
                        printfn $"      Ends at {daylightEnd.TimeOfDay:t} on the {enum<WeekOfMonth> daylightEnd.Week} {daylightEnd.DayOfWeek} of {dateInfo.GetMonthName daylightEnd.Month}."
                    // Display information on floating date rule
                    else
                        printfn $"      Ends at {daylightStart.TimeOfDay:t} on the {enum<WeekOfMonth> daylightStart.Week} {daylightStart.DayOfWeek} of {dateInfo.GetMonthName daylightStart.Month}."
    // </Snippet6>

compareForEquality ()
printfn ""
compareTransitionTimesForEquality()
printfn ""
createTransitionRules()
printfn ""
getFixedTransitionTimes ()
printfn ""
getFloatingTransitionTimes ()
printfn ""
AdditionalExamples.getAllTransitionTimes ()