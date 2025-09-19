module ignorable26.fs
// <Snippet26>
open System

let s1 = "ani\u00ADmal"
let s2 = "animal"

printfn "Culture-sensitive comparison:"
// Use culture-sensitive comparison to find the soft hyphen.
printfn $"""{s1.IndexOf("\u00AD", StringComparison.CurrentCulture)}"""
printfn $"""{s2.IndexOf("\u00AD", StringComparison.CurrentCulture)}"""

// Use culture-sensitive comparison to find the soft hyphen followed by "n".
printfn $"""{s1.IndexOf("\u00ADn", StringComparison.CurrentCulture)}"""
printfn $"""{s2.IndexOf("\u00ADn", StringComparison.CurrentCulture)}"""

// Use culture-sensitive comparison to find the soft hyphen followed by "m".
printfn $"""{s1.IndexOf("\u00ADm", StringComparison.CurrentCulture)}"""
printfn $"""{s2.IndexOf("\u00ADm", StringComparison.CurrentCulture)}"""

printfn "Ordinal comparison:"
// Use ordinal comparison to find the soft hyphen.
printfn $"""{s1.IndexOf("\u00AD", StringComparison.Ordinal)}"""
printfn $"""{s2.IndexOf("\u00AD", StringComparison.Ordinal)}"""

// Use ordinal comparison to find the soft hyphen followed by "n".
printfn $"""{s1.IndexOf("\u00ADn", StringComparison.Ordinal)}"""
printfn $"""{s2.IndexOf("\u00ADn", StringComparison.Ordinal)}"""

// Use ordinal comparison to find the soft hyphen followed by "m".
printfn $"""{s1.IndexOf("\u00ADm", StringComparison.Ordinal)}"""
printfn $"""{s2.IndexOf("\u00ADm", StringComparison.Ordinal)}"""

// The example displays the following output:
//       Culture-sensitive comparison:
//       0
//       0
//       1
//       1
//       4
//       3
//       Ordinal comparison:
//       3
//       -1
//       -1
//       -1
//       3
//       -1
// </Snippet26>
