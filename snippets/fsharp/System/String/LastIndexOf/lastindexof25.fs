module lastindexof25.fs
open System

do
    // <Snippet25>
    let searchString = "\u00ADm"

    let s1 = "ani\u00ADmal"
    let s2 = "animal"

    let position = s1.LastIndexOf 'm'
    if position >= 0 then
        printfn $"{s1.LastIndexOf(searchString, position, StringComparison.CurrentCulture)}"
        printfn $"{s1.LastIndexOf(searchString, position, StringComparison.Ordinal)}"

    let position = s2.LastIndexOf 'm'
    if position >= 0 then
        printfn $"{s2.LastIndexOf(searchString, position, StringComparison.CurrentCulture)}"
        printfn $"{s2.LastIndexOf(searchString, position, StringComparison.Ordinal)}"

// The example displays the following output:
//
// 4
// 3
// 3
// -1
// </Snippet25>
