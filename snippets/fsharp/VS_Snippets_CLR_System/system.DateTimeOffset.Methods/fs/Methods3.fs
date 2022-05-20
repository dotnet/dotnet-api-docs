module Methods3

// <Snippet8>
open System

type TimeComparison =
    | Earlier = -1
    | Same = 0
    | Later = 1

let firstTime = DateTimeOffset(2007, 9, 1, 6, 45, 0, TimeSpan(-7, 0, 0))

let secondTime = firstTime
printfn $"Comparing {firstTime} and {secondTime}: {firstTime.CompareTo secondTime |> enum<TimeComparison>}"

let thirdTime = DateTimeOffset(2007, 9, 1, 6, 45, 0, TimeSpan(-6, 0, 0))
printfn $"Comparing {firstTime} and {thirdTime}: {firstTime.CompareTo thirdTime |> enum<TimeComparison>}"

let fourthTime = new DateTimeOffset(2007, 9, 1, 8, 45, 0,
                new TimeSpan(-5, 0, 0))
printfn $"Comparing {firstTime} and {fourthTime}: {firstTime.CompareTo fourthTime |> enum<TimeComparison>}" 
                
// The example displays the following output to the console:
//       Comparing 9/1/2007 6:45:00 AM -07:00 and 9/1/2007 6:45:00 AM -07:00: Same
//       Comparing 9/1/2007 6:45:00 AM -07:00 and 9/1/2007 6:45:00 AM -06:00: Later
//       Comparing 9/1/2007 6:45:00 AM -07:00 and 9/1/2007 8:45:00 AM -05:00: Same
// </Snippet8>