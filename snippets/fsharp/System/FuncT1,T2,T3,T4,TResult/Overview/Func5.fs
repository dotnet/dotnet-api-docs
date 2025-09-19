module Func5

// <Snippet2>
open System

let indexOf (s: string) s2 pos chars comparison =
    s.IndexOf(s2, pos, chars, comparison) 

let title = "The House of the Seven Gables"
let finder = Func<string, int, int, StringComparison, int>(indexOf title)
let mutable position = 0

while position > -1 do
    let characters = title.Length - position
    position <- 
        finder.Invoke("the", position, characters, StringComparison.InvariantCultureIgnoreCase)
    if position >= 0 then
        position <- position + 1
        printfn $"'The' found at position {position} in {title}."
// </Snippet2>