module IsAssignableFrom3

// <Snippet3>
open System
open System.Collections

let t = typeof<IEnumerable>
let c = typeof<Array>

let mutable instanceOfT = Unchecked.defaultof<IEnumerable>
let instanceOfC = [| 1; 2; 3; 4 |]
if t.IsAssignableFrom c then
    // <Snippet4>
    instanceOfT <- instanceOfC
    // </Snippet4>
// </Snippet3>