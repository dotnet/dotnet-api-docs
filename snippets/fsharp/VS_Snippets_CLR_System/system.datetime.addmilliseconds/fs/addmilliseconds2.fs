open System

// <Snippet1>
let dateFormat = "MM/dd/yyyy hh:mm:ss.fffffff"
let date1 = DateTime(2010, 9, 8, 16, 0, 0)
printfn $"Original date: {date1.ToString dateFormat} ({date1.Ticks:N0} ticks)\n"

let date2 = date1.AddMilliseconds 1
printfn $"Second date:   {date2.ToString dateFormat} ({date2.Ticks:N0} ticks)"
printfn $"Difference between dates: {date2 - date1} ({date2.Ticks - date1.Ticks:N0} ticks)\n"

let date3 = date1.AddMilliseconds 1.5
printfn $"Third date:    {date3.ToString dateFormat} ({date3.Ticks:N0} ticks)"
printfn $"Difference between dates: {date3 - date1} ({date3.Ticks - date1.Ticks:N0} ticks)"

// The example displays the following output:
//    Original date: 09/08/2010 04:00:00.0000000 (634,195,584,000,000,000 ticks)
//
//    Second date:   09/08/2010 04:00:00.0010000 (634,195,584,000,010,000 ticks)
//    Difference between dates: 00:00:00.0010000 (10,000 ticks)
//
//    Third date:    09/08/2010 04:00:00.0020000 (634,195,584,000,020,000 ticks)
//    Difference between dates: 00:00:00.0020000 (20,000 ticks)
// </Snippet1>