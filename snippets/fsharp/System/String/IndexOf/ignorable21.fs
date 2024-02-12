module ignorable21.fs
// <Snippet21>
let s1 = "ani\u00ADmal"
let s2 = "animal"

// Find the index of the soft hyphen.
printfn $"""{s1.IndexOf "\u00AD"}"""
printfn $"""{s2.IndexOf "\u00AD"}"""

// Find the index of the soft hyphen followed by "n".
printfn $"""{s1.IndexOf "\u00ADn"}"""
printfn $"""{s2.IndexOf "\u00ADn"}"""

// Find the index of the soft hyphen followed by "m".
printfn $"""{s1.IndexOf "\u00ADm"}"""
printfn $"""{s2.IndexOf "\u00ADm"}"""

// The example displays the following output
// if run under the .NET Framework 4 or later:
//       0
//       0
//       1
//       1
//       4
//       3
// </Snippet21>
