open System

// <Snippet1>
// Calculate what day of the week is 36 days from this instant.
let today = DateTime.Now
let duration = TimeSpan(36, 0, 0, 0)
let answer = today.Add duration
printfn $"{answer:dddd}"
// </Snippet1>