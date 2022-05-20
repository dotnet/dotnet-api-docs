module cont

//<snippet1>
let s1 = "The quick brown fox jumps over the lazy dog"
let s2 = "fox"
let b = s1.Contains s2
printfn $"'{s2}' is in the string '{s1}': {b}"
if b then
    let index = s1.IndexOf s2
    if index >= 0 then
        printfn $"'{s2} begins at character position {index + 1}"
// This example displays the following output:
//    'fox' is in the string 'The quick brown fox jumps over the lazy dog': True
//    'fox begins at character position 17
//</snippet1>