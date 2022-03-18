module Delegate

// <Snippet1>
open System

type Searcher = delegate of (string * int * int * StringComparison) -> int

let title = "The House of the Seven Gables"
let finder = Searcher title.IndexOf
let mutable position = 0

while position > -1 do
    let characters = title.Length - position
    position <- 
        finder.Invoke("the", position, characters, StringComparison.InvariantCultureIgnoreCase)
    if position >= 0 then
        position <- position + 1
        printfn $"'The' found at position {position} in {title}."
// </Snippet1>