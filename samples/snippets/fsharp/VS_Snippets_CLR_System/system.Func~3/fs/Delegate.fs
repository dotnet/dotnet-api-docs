module Delegate

// <Snippet1>
type ExtractMethod = delegate of string * int -> string []

let extractWords (phrase: string) limit =
    let delimiters = [| ' ' |]
    if limit > 0 then
        phrase.Split(delimiters, limit)
    else
        phrase.Split delimiters

// Instantiate delegate to reference extractWords function
let extractMeth = ExtractMethod extractWords
let title = "The Scarlet Letter"

// Use delegate instance to call extractWords function and display result
for word in extractMeth.Invoke(title, 5) do
    printfn $"{word}"
// </Snippet1>
