module Concat6

// <Snippet6>
open System

let s1 = "We went to a bookstore, "
let s2 = "a movie, "
let s3 = "and a restaurant."

String.Concat(s1, s2, s3)
|> printfn "%s"
// The example displays the following output:
//      We went to a bookstore, a movie, and a restaurant. 
// </Snippet6>