// <Snippet1>
open System

let centuryBegin = DateTime(2001, 1, 1)
let currentDate = DateTime.Now

let elapsedTicks = currentDate.Ticks - centuryBegin.Ticks
let elapsedSpan = TimeSpan elapsedTicks

printfn $"Elapsed from the beginning of the century to {currentDate:f}:"
printfn $"   {elapsedTicks * 100L:N0} nanoseconds"
printfn $"   {elapsedTicks:N0} ticks"
printfn $"   {elapsedSpan.TotalSeconds:N2} seconds"
printfn $"   {elapsedSpan.TotalMinutes:N2} minutes"
printfn $"   {elapsedSpan.Days:N0} days, {elapsedSpan.Hours} hours, {elapsedSpan.Minutes} minutes, {elapsedSpan.Seconds} seconds"

// This example displays an output similar to the following:
//
// Elapsed from the beginning of the century to Thursday, 14 November 2019 18:21:
//    595,448,498,171,000,000 nanoseconds
//    5,954,484,981,710,000 ticks
//    595,448,498.17 seconds
//    9,924,141.64 minutes
//    6,891 days, 18 hours, 21 minutes, 38 seconds
// </Snippet1>