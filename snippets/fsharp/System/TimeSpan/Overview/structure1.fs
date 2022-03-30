module structure

open System

// <Snippet1>
// Define two dates.
let date1 = DateTime(2010, 1, 1, 8, 0, 15)
let date2 = DateTime(2010, 8, 18, 13, 30, 30)

// Calculate the interval between the two dates.
let interval = date2 - date1
printfn $"{date2} - {date1} = {interval}"

// Display individual properties of the resulting TimeSpan object.
printfn $"""   {"Value of Days Component:",-35} {interval.Days,20}""" 
printfn $"""   {"Total Number of Days:",-35} {interval.TotalDays,20}""" 
printfn $"""   {"Value of Hours Component:",-35} {interval.Hours,20}""" 
printfn $"""   {"Total Number of Hours:",-35} {interval.TotalHours,20}""" 
printfn $"""   {"Value of Minutes Component:",-35} {interval.Minutes,20}""" 
printfn $"""   {"Total Number of Minutes:",-35} {interval.TotalMinutes,20}""" 
printfn $"""   {"Value of Seconds Component:",-35} {interval.Seconds,20:N0}""" 
printfn $"""   {"Total Number of Seconds:",-35} {interval.TotalSeconds,20:N0}""" 
printfn $"""   {"Value of Milliseconds Component:",-35} {interval.Milliseconds,20:N0}""" 
printfn $"""   {"Total Number of Milliseconds:",-35} {interval.TotalMilliseconds,20:N0}""" 
printfn $"""   {"Ticks:",-35} {interval.Ticks,20:N0}""" 

// This example displays the following output:
//       8/18/2010 1:30:30 PM - 1/1/2010 8:00:15 AM = 229.05:30:15
//          Value of Days Component:                             229
//          Total Number of Days:                   229.229340277778
//          Value of Hours Component:                              5
//          Total Number of Hours:                  5501.50416666667
//          Value of Minutes Component:                           30
//          Total Number of Minutes:                       330090.25
//          Value of Seconds Component:                           15
//          Total Number of Seconds:                      19,805,415
//          Value of Milliseconds Component:                       0
//          Total Number of Milliseconds:             19,805,415,000
//          Ticks:                               198,054,150,000,000
// </Snippet1>      