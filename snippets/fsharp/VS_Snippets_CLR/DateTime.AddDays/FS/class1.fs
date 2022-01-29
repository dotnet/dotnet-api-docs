// <Snippet1>
open System

let today = DateTime.Now
let answer = today.AddDays 36
printfn $"Today: {today:dddd}"
printfn $"36 days from today: {answer:dddd}"


// The example displays output like the following:
//       Today: Wednesday
//       36 days from today: Thursday
// </Snippet1>