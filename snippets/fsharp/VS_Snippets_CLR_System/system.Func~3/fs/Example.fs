module Example

// <Snippet5>
open System
open System.Linq

let predicate = Func<string, int, bool>(fun str index -> str.Length = index)

let words = [ "orange"; "apple"; "Article"; "elephant"; "star"; "and" ]
let aWords = words.Where predicate

for word in aWords do
    printfn $"{word}"
// </Snippet5>