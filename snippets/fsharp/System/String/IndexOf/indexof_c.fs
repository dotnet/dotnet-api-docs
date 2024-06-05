module indexof_c.fs
// <Snippet5>
open System

// Create a Unicode string with 5 Greek Alpha characters.
let szGreekAlpha = String('\u0391',5)

// Create a Unicode string with 3 Greek Omega characters.
let szGreekOmega = "\u03A9\u03A9\u03A9"

let szGreekLetters = String.Concat(szGreekOmega, szGreekAlpha, szGreekOmega.Clone())

// Display the entire string.
printfn $"The string: {szGreekLetters}"

// The first index of Alpha.
let ialpha = szGreekLetters.IndexOf '\u0391'
// The first index of Omega.
let iomega = szGreekLetters.IndexOf '\u03A9'

printfn "First occurrence of the Greek letter Alpha: Index {ialpha}"
printfn "First occurrence of the Greek letter Omega: Index {iomega}"

// The example displays the following output:
//    The string: ΩΩΩΑΑΑΑΑΩΩΩ
//    First occurrence of the Greek letter Alpha: Index 3
//    First occurrence of the Greek letter Omega: Index 0
// </Snippet5>
