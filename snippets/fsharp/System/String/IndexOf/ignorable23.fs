module ignorable23.fs
// <Snippet23>
let searchString = "\u00ADm"
let s1 = "ani\u00ADmal"
let s2 = "animal"

printfn $"{s1.IndexOf(searchString, 2, 4)}"
printfn $"{s2.IndexOf(searchString, 2, 4)}"

// The example displays the following output:
//       4
//       3
// </Snippet23>
