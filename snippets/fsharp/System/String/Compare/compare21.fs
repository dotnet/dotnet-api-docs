module compare21

// <Snippet21>
open System

let s1 = "ani\u00ADmal"
let s2 = "animal"

printfn $"Comparison of '{s1}' and '{s2}': {String.Compare(s1, s2)}"

// The example displays the following output:
//       Comparison of 'ani-mal' and 'animal': 0
// </Snippet21>