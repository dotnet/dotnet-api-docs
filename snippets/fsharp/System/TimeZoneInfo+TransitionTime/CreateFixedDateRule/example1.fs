module example1

// <Snippet5>
open System
open System.Globalization

let displayTransitionInfo (transition: TimeZoneInfo.TransitionTime) year label =
    // For non-fixed date rules, get local calendar
    let cal = CultureInfo.CurrentCulture.Calendar
    // Get first day of week for transition
    // For example, the 3rd week starts no earlier than the 15th of the month
    let startOfWeek = transition.Week * 7 - 6
    // What day of the week does the month start on?
    let firstDayOfWeek = cal.GetDayOfWeek(DateTime(year, transition.Month, 1)) |> int 
    // Determine how much start date has to be adjusted
    let changeDayOfWeek = int transition.DayOfWeek

    let transitionDay = 
        if firstDayOfWeek <= changeDayOfWeek then
            startOfWeek + (changeDayOfWeek - firstDayOfWeek)
        else     
            startOfWeek + (7 - firstDayOfWeek + changeDayOfWeek)

    // Adjust for months with no fifth week
    let transitionDay =
        if transitionDay > cal.GetDaysInMonth(year, transition.Month) then  
            transitionDay - 7
        else 
            transitionDay

    printfn $"   {label} {transition.DayOfWeek}, {DateTime(year, transition.Month, transitionDay):d} at {transition.TimeOfDay:t}"   

let getAdjustment (adjustments: TimeZoneInfo.AdjustmentRule seq) year =
    adjustments
    // Iterate adjustment rules for time zone
    // Determine if this adjustment rule covers year desired
    |> Seq.tryFind (fun adjustment -> adjustment.DateStart.Year <= year && adjustment.DateEnd >= DateTime year)
    |> Option.defaultValue null

let getTransitionTimes year =
    // Instantiate DateTimeFormatInfo object for month names
    let dateFormat = CultureInfo.CurrentCulture.DateTimeFormat

    // Get and iterate time zones on local computer
    let timeZones = TimeZoneInfo.GetSystemTimeZones()
    for timeZone in timeZones do
        printfn $"{timeZone.StandardName}:"
        let adjustments = timeZone.GetAdjustmentRules()
        let startYear = year
        let mutable endYear = startYear

        if adjustments.Length = 0 then
            printfn "   No adjustment rules."
        else
            let adjustment = getAdjustment adjustments year
            if adjustment = null then
                Console.WriteLine("   No adjustment rules available for this year.")
            else
                // Determine if starting transition is fixed 
                let startTransition = adjustment.DaylightTransitionStart
                // Determine if starting transition is fixed and display transition info for year
                if startTransition.IsFixedDateRule then
                    printfn $"   Begins on {dateFormat.GetMonthName startTransition.Month} {startTransition.Day} at {startTransition.TimeOfDay:t}"
                else
                    displayTransitionInfo startTransition startYear "Begins on"

                // Determine if ending transition is fixed and display transition info for year
                let mutable endTransition = adjustment.DaylightTransitionEnd
                
                // Does the transition back occur in an earlier month (i.e., 
                // the following year) than the transition to DST? If so, make
                // sure we have the right adjustment rule.
                if endTransition.Month < startTransition.Month then
                    endTransition <- (getAdjustment adjustments (year + 1)).DaylightTransitionEnd
                    endYear <- endYear + 1
                
                if endTransition.IsFixedDateRule then
                    printfn $"   Ends on {dateFormat.GetMonthName endTransition.Month} {endTransition.Day} at {endTransition.TimeOfDay:t}"
                else
                    displayTransitionInfo endTransition endYear "Ends on"

// </Snippet5>
getTransitionTimes 2007
