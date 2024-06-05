open System

let first = DateTimeOffset()
let second = DateTimeOffset()
let this = DateTimeOffset()
let other = DateTimeOffset()
let right = DateTimeOffset()
let left = DateTimeOffset()
let obj = obj()

// <Snippet1>
DateTime.Compare(first.UtcDateTime, second.UtcDateTime)
// </Snippet1>
|> ignore
   
// <Snippet2>
this.UtcDateTime = other.UtcDateTime
// </Snippet2>
|> ignore

// <Snippet3>
this.UtcDateTime = (obj :?> DateTimeOffset).UtcDateTime
// </Snippet3>
|> ignore
   
// <Snippet4>
first.UtcDateTime = second.UtcDateTime
// </Snippet4>
|> ignore

// <Snippet5>
left.UtcDateTime > right.UtcDateTime
// </Snippet5>
|> ignore
// <Snippet6>
left.UtcDateTime >= right.UtcDateTime
// </Snippet6>
|> ignore
// <Snippet7>
left.UtcDateTime <> right.UtcDateTime
// </Snippet7>
|> ignore
// <Snippet8>
left.UtcDateTime < right.UtcDateTime
// </Snippet8>
|> ignore
// <Snippet9>
left.UtcDateTime <= right.UtcDateTime
// </Snippet9>
|> ignore