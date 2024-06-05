// <Snippet1>
let raining = false
let busLate = true

printfn $"raining.ToString() returns {raining}" 
printfn $"busLate.ToString() returns {busLate}"
// The example displays the following output:
//       raining.ToString() returns False
//       busLate.ToString() returns True
// </Snippet1>

// <Snippet2>
let input = bool.TrueString
let value = bool.Parse input
printfn $"'{input}' parsed as {value}"
// The example displays the following output:
//       'True' parsed as True
// </Snippet2>