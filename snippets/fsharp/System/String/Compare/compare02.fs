module compare02

// <Snippet18>
open System

// Create upper-case characters from their Unicode code units.
let stringUpper = "\x0041\x0042\x0043"

// Create lower-case characters from their Unicode code units.
let stringLower = "\x0061\x0062\x0063"

// Display the strings.
printfn $"Comparing '{stringUpper}' and '{stringLower}':"

// Compare the uppercased strings the result is true.
printfn $"The Strings are equal when capitalized? %b{String.Compare(stringUpper.ToUpper(), stringLower.ToUpper()) = 0}"

// The previous method call is equivalent to this Compare method, which ignores case.
printfn $"The Strings are equal when case is ignored? %b{String.Compare(stringUpper, stringLower, true) = 0}"

// The example displays the following output:
//       Comparing 'ABC' and 'abc':
//       The Strings are equal when capitalized? true
//       The Strings are equal when case is ignored? true
// </Snippet18>