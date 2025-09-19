module ToString7

// <Snippet7>
open System

let number = 1764.3789m

// Format as a currency value.
printfn $"""{number.ToString "C"}"""

// Format as a numeric value with 3 decimal places.
printfn $"""{number.ToString "N3"}"""

// The example displays the following output:
//       $1,764.38
//       1,764.379
// </Snippet7>