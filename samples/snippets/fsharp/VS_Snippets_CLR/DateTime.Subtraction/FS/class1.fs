//<Snippet1>
open System

let date1 = DateTime(1996, 6, 3, 22, 15, 0)
let date2 = DateTime(1996, 12, 6, 13, 2, 0)
let date3 = DateTime(1996, 10, 12, 8, 42, 0)

// diff1 gets 185 days, 14 hours, and 47 minutes.
let diff1 = date2.Subtract date1

// date4 gets 4/9/1996 5:55:00 PM.
let date4 = date3.Subtract diff1

// diff2 gets 55 days 4 hours and 20 minutes.
let diff2 = date2 - date3

// date5 gets 4/9/1996 5:55:00 PM.
let date5 = date1 - diff2
//</Snippet1>

System.Console.WriteLine(diff1)
System.Console.WriteLine(date4)
System.Console.WriteLine(diff2)
System.Console.WriteLine(date4)