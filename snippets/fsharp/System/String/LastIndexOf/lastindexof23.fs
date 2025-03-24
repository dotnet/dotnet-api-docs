module lastindexof23.fs
do
    // <Snippet23>
    let s1 = "ani\u00ADmal"
    let s2 = "animal"

    // Find the index of the soft hyphen followed by "n".
    let position = s1.LastIndexOf "m"
    printfn $"'m' at position {position}"

    if position  >= 0 then
        printfn $"""{s1.LastIndexOf("\u00ADn", position, position + 1)}"""

    let position = s2.LastIndexOf "m"
    printfn $"'m' at position {position}"

    if position  >= 0 then
        printfn $"""{s2.LastIndexOf("\u00ADn", position, position + 1)}"""

    // Find the index of the soft hyphen followed by "m".
    let position = s1.LastIndexOf "m"
    printfn $"'m' at position {position}"

    if position  >= 0 then
        printfn $"""{s1.LastIndexOf("\u00ADm", position, position + 1)}"""

    let position = s2.LastIndexOf "m"
    printfn $"'m' at position {position}"

    if position  >= 0 then
        printfn $"""{s2.LastIndexOf("\u00ADm", position, position + 1)}"""

    // The example displays the following output:
    //
    // 'm' at position 4
    // 1
    // 'm' at position 3
    // 1
    // 'm' at position 4
    // 4
    // 'm' at position 3
    // 3
    // </Snippet23>
