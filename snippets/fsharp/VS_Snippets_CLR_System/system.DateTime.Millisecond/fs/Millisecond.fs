open System

// <Snippet1>
let date1 = DateTime(2008, 1, 1, 0, 30, 45, 125)
printfn $"Milliseconds: {date1:fff}" // displays Milliseconds: 125
// </Snippet1>

// <Snippet2>
let date2 = DateTime(2008, 1, 1, 0, 30, 45, 125)
printfn $"Date: {date2:o}"

// Displays the following output to the console:
//      Date: 2008-01-01T00:30:45.1250000
// </Snippet2>

// <Snippet3>
let date3 = DateTime(2008, 1, 1, 0, 30, 45, 125)
printfn $"""Date with milliseconds: {date3.ToString "MM/dd/yyy HH:mm:ss.fff"}"""

// Displays the following output to the console:
//       Date with milliseconds: 01/01/2008 00:30:45.125
// </Snippet3>