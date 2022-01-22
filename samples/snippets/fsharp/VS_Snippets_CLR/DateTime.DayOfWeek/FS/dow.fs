//<snippet1>
// This example demonstrates the DateTime.DayOfWeek property
open System

// Assume the current culture is en-US.
// Create a DateTime for the first of May, 2003.
let dt = DateTime(2003, 5, 1)
printfn $"Is Thursday the day of the week for {dt:d}?: {dt.DayOfWeek = DayOfWeek.Thursday}"
printfn $"The day of the week for {dt:d} is {dt.DayOfWeek}." 

// This example produces the following results:
// 
// Is Thursday the day of the week for 5/1/2003?: True
// The day of the week for 5/1/2003 is Thursday.
//</snippet1>