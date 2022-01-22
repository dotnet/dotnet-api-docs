module Func3

// <Snippet2>
open System

let extractWords (phrase: string) limit =
    let delimiters = [| ' ' |]
    if limit > 0 then
        phrase.Split(delimiters, limit)
    else
        phrase.Split delimiters

// Instantiate delegate to reference extractWords function
let extractMethod = Func<string, int, string[]> extractWords
let title = "The Scarlet Letter"

// Use delegate instance to call extractWords function and display result
for word in extractMethod.Invoke(title, 5) do
    printfn $"{word}"
// </Snippet2>