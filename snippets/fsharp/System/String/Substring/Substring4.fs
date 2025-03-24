module Substring4.fs
// <Snippet4>
let value = "This is a string."
let startIndex = 5
let length = 2
let substring = value.Substring(startIndex, length)
printfn $"{substring}"

// The example displays the following output:
//       is
// </Snippet4>
