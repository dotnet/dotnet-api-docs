// <Snippet1>
open System

// Find difference between Date.Now and Date.UtcNow
let date1 = DateTime.Now
let date2 = DateTime.UtcNow
let difference1 = date1 - date2
printfn $"{date1} - {date2} = {difference1}"

// Find difference between Now and UtcNow using DateTimeOffset
let dateOffset1 = DateTimeOffset.Now
let dateOffset2 = DateTimeOffset.UtcNow
let difference2 = dateOffset1 - dateOffset2
printfn $"{dateOffset1} - {dateOffset2} = {difference2}"
                 
// If run in the Pacific Standard time zone on 1/7/2022, the example
// displays the following output to the console:
//    1/7/2022 6:45:10 PM - 1/8/2022 2:45:10 AM = -08:00:00.0072573
//    1/7/2022 6:45:10 PM -08:00 - 1/8/2022 2:45:10 AM +00:00 = -00:00:00.0000278
// </Snippet1>