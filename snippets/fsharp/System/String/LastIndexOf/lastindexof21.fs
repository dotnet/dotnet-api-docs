module lastindexof21.fs

// <Snippet21>
let s1 = "ani\u00ADmal"
let s2 = "animal"

// Find the index of the last soft hyphen followed by "n".
printfn $"""{s1.LastIndexOf "\u00ADn"}"""
printfn $"""{s2.LastIndexOf "\u00ADn"}"""

// Find the index of the last soft hyphen followed by "m".
printfn $"""{s1.LastIndexOf "\u00ADm"}"""
printfn $"""{s2.LastIndexOf "\u00ADm"}"""

// The example displays the following output:
//
// 1
// 1
// 4
// 3
// </Snippet21>
