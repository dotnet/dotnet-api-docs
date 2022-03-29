module compiler_resolution
// <Snippet1>
let value = "This is a short string."
let delimiter = 's'
let substrings = value.Split delimiter
for substring in substrings do
    printfn $"{substring}"

// The example displays the following output:
//     Thi
//      i
//      a
//     hort
//     tring.
// </Snippet1>