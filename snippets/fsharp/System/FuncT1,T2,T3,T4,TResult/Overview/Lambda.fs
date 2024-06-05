module Lambda

// <Snippet4>
open System

let title = "The House of the Seven Gables"

let finder =
    Func<string, int, int, StringComparison, int>(fun s pos chars typ -> title.IndexOf(s, pos, chars, typ))

let mutable position = 0

while position > -1 do
    let characters = title.Length - position
    position <- finder.Invoke("the", position, characters, StringComparison.InvariantCultureIgnoreCase)

    if position >= 0 then
        position <- position + 1
        printfn $"'The' found at position {position} in {title}."
// </Snippet4>
