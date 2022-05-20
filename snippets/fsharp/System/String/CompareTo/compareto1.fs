module compareto

// <Snippet1>
let s1 = "ani\u00ADmal"
let o1: obj = "animal"
      
printfn $"Comparison of '{s1}' and '{o1}': {s1.CompareTo o1}"
// The example displays the following output:
//       Comparison of 'ani-mal' and 'animal': 0
// </Snippet1>