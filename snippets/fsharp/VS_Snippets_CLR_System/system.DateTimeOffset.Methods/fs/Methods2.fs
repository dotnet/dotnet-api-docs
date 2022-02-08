module Methods2

// <Snippet7>
open System

type TimeComparison =
    | Earlier = -1
    | Same = 0
    | Later = 1

let firstTime = DateTimeOffset(2007, 9, 1, 6, 45, 0, TimeSpan(-7, 0, 0))

let secondTime = firstTime
printfn $"Comparing {firstTime} and {secondTime}: {DateTimeOffset.Compare(firstTime, secondTime) |> enum<TimeComparison>}"

let thirdTime = DateTimeOffset(2007, 9, 1, 6, 45, 0, TimeSpan(-6, 0, 0))
printfn $"Comparing {firstTime} and {thirdTime}: {DateTimeOffset.Compare(firstTime, thirdTime) |> enum<TimeComparison>}"

let fourthTime = DateTimeOffset(2007, 9, 1, 8, 45, 0, TimeSpan(-5, 0, 0))
printfn $"Comparing {firstTime} and {fourthTime}: {DateTimeOffset.Compare(firstTime, fourthTime) |> enum<TimeComparison>}"

// The example displays the following output to the console:
//       Comparing 9/1/2007 6:45:00 AM -07:00 and 9/1/2007 6:45:00 AM -07:00: Same
//       Comparing 9/1/2007 6:45:00 AM -07:00 and 9/1/2007 6:45:00 AM -06:00: Later
//       Comparing 9/1/2007 6:45:00 AM -07:00 and 9/1/2007 8:45:00 AM -05:00: Same
// </Snippet7>