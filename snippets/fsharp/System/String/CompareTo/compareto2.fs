module compareto2

// <Snippet2>
let s1 = "ani\u00ADmal"
let s2 = "animal"

printfn $"Comparison of '{s1}' and '{s2}': {s1.CompareTo s2}"
// The example displays the following output:
//       Comparison of 'ani-mal' and 'animal': 0
// </Snippet2>