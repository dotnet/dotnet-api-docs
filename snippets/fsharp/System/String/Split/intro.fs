module intro

open System

let intro1 () =
    //<snippet1>
    let s = "You win some. You lose some."

    let subs = s.Split ' '

    for sub in subs do
        printfn $"Substring: {sub}"

    // This example produces the following output:
    //
    // Substring: You
    // Substring: win
    // Substring: some.
    // Substring: You
    // Substring: lose
    // Substring: some.
    //</snippet1>

let intro2 () =
    //<snippet2>
    let s = "You win some. You lose some."

    let subs = s.Split(' ', '.')

    for sub in subs do
        printfn $"Substring: {sub}"

    // This example produces the following output:
    //
    // Substring: You
    // Substring: win
    // Substring: some
    // Substring:
    // Substring: You
    // Substring: lose
    // Substring: some
    // Substring:
    //</snippet2>

let intro3 () =
    //<snippet3>
    let s = "You win some. You lose some."
    let separators = [| ' '; '.' |]

    let subs = s.Split(separators, StringSplitOptions.RemoveEmptyEntries)

    for sub in subs do
        printfn $"Substring: {sub}"

    // This example produces the following output:
    //
    // Substring: You
    // Substring: win
    // Substring: some
    // Substring: You
    // Substring: lose
    // Substring: some
    //</snippet3>