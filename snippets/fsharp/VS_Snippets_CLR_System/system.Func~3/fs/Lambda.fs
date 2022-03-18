module Lambda

// <Snippet4>
open System

let separators = [| ' ' |]

let extract =
    Func<string, int, string []> (fun s i ->
        if i > 0 then
            s.Split(separators, i)
        else
            s.Split separators)

let title = "The Scarlet Letter"

// Use Func instance to call lambda expression and display result
for word in extract.Invoke(title, 5) do
    printfn $"{word}"
// </Snippet4>
