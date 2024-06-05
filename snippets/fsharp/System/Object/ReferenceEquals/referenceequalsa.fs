module referenceequalsa

// <Snippet2>
open System

let s1 = "String1"
let s2 = "String1"
printfn $"s1 = s2: {Object.ReferenceEquals(s1, s2)}"
printfn $"""{s1} interned: {if String.IsNullOrEmpty(String.IsInterned s1) then "No" else "Yes"}"""

let suffix = "A"
let s3 = "String" + suffix
let s4 = "String" + suffix
printfn $"s3 = s4: {Object.ReferenceEquals(s3, s4)}"
printfn $"""{s3} interned: {if String.IsNullOrEmpty(String.IsInterned s3) then "No" else "Yes"}"""

// The example displays the following output:
//       s1 = s2: True
//       String1 interned: Yes
//       s3 = s4: False
//       StringA interned: No
// </Snippet2>