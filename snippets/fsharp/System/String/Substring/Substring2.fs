module Substring2.fs
// <Snippet2>
let s = "aaaaabbbcccccccdd"
let charRange = 'b'
let startIndex = s.IndexOf charRange
let endIndex = s.LastIndexOf charRange
let length = endIndex - startIndex + 1
printfn $"{s}.Substring({startIndex}, {length}) = {s.Substring(startIndex, length)}"

// The example displays the following output:
//       aaaaabbbcccccccdd.Substring(5, 3) = bbb
// </Snippet2>
