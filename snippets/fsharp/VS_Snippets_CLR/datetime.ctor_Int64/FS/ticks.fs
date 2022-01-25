//<snippet1>
// This example demonstrates the DateTime(Int64) constructor.
open System
open System.Globalization

// Create a DateTime for the maximum date and time using ticks.
let dt1 = DateTime DateTime.MaxValue.Ticks

// Create a DateTime for the minimum date and time using ticks.
let dt2 = DateTime DateTime.MinValue.Ticks

// Create a custom DateTime for 7/28/1979 at 10:35:05 PM using a
// calendar based on the "en-US" culture, and ticks.
let ticks = DateTime(1979, 07, 28, 22, 35, 5, CultureInfo("en-US", false).Calendar).Ticks
let dt3 = DateTime ticks

printfn $"""1) The maximum date and time is {dt1.ToString "MM-dd/yyyy hh:mm:ss tt"}"""
printfn $"""2) The minimum date and time is {dt2.ToString "MM/dd/yyyy hh:mm:ss tt"}"""
printfn $"""3) The custom  date and time is {dt3.ToString "MM/dd/yyyy hh:mm:ss tt"}"""

printfn $"\nThe custom date and time is created from {ticks:N0} ticks."

// This example produces the following results:
//
// 1) The maximum date and time is 12/31/9999 11:59:59 PM
// 2) The minimum date and time is 01/01/0001 12:00:00 AM
// 3) The custom  date and time is 07/28/1979 10:35:05 PM
//
// The custom date and time is created from 624,376,461,050,000,000 ticks.
//</snippet1>