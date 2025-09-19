module Substring3.fs
do
    // <Snippet3>
    let s = "<term>extant<definition>still in existence</definition></term>"
    let searchString = "<definition>"
    let startIndex = s.IndexOf(searchString)
    let searchString = "</" + searchString.Substring 1
    let endIndex = s.IndexOf searchString
    let substring = s.Substring(startIndex, endIndex + searchString.Length - startIndex)
    printfn $"Original string: {s}"
    printfn $"Substring;       {substring}"

    // The example displays the following output:
    //     Original string: <term>extant<definition>still in existence</definition></term>
    //     Substring;       <definition>still in existence</definition>
    // </Snippet3>
