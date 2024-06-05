module ignorable25.fs
// <Snippet25>
open System

let searchString = "\u00ADm"
let s1 = "ani\u00ADmal"
let s2 = "animal"

printfn $"{s1.IndexOf(searchString, 2, StringComparison.CurrentCulture)}"
printfn $"{s1.IndexOf(searchString, 2, StringComparison.Ordinal)}"
printfn $"{s2.IndexOf(searchString, 2, StringComparison.CurrentCulture)}"
printfn $"{s2.IndexOf(searchString, 2, StringComparison.Ordinal)}"

// The example displays the following output:
//       4
//       3
//       3
//       -1
// </Snippet25>
