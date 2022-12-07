module ignorable22.fs
// <Snippet22>
let searchString = "\u00ADm"
let s1 = "ani\u00ADmal"
let s2 = "animal"

printfn $"{s1.IndexOf(searchString, 2)}"
printfn $"{s2.IndexOf(searchString, 2)}"

// The example displays the following output:
//       4
//       3
// </Snippet22>
