module tostring_string1

// <Snippet2>
open System

let article = "An"
let noun = "apple"
let str1 = $"{article} {noun}"
let str2 = Convert.ToString str1

printfn $"str1 is interned: {String.IsInterned str1 <> null}"
                  
printfn $"str1 and str2 are the same reference: {Object.ReferenceEquals(str1, str2)}"
// The example displays the following output:
//       str1 is interned: False
//       str1 and str2 are the same reference: True
// </Snippet2>