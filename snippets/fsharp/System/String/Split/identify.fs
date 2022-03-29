module identify
open System

let splitWithCharAndInt () =
    // <Snippet3>
    let phrase = "The quick  brown fox"
    
    phrase.Split(Unchecked.defaultof<char[]>, 3, StringSplitOptions.RemoveEmptyEntries) |> ignore

    phrase.Split(null :> char[], 3, StringSplitOptions.RemoveEmptyEntries) |> ignore

    phrase.Split((null: char[]), 3, StringSplitOptions.RemoveEmptyEntries) |> ignore
    // </Snippet3>

let splitWithStringAndInt () =
    // <Snippet4>
    let phrase = "The quick  brown fox"

    phrase.Split(Unchecked.defaultof<string[]>, 3, StringSplitOptions.RemoveEmptyEntries) |> ignore

    phrase.Split(null :> string[], 3, StringSplitOptions.RemoveEmptyEntries) |> ignore

    phrase.Split((null: string[]), 3, StringSplitOptions.RemoveEmptyEntries) |> ignore
    // </Snippet4>

let splitWithChar () =
    // <Snippet5>
    let phrase = "The quick  brown fox"

    phrase.Split(Unchecked.defaultof<char[]>, StringSplitOptions.RemoveEmptyEntries) |> ignore

    phrase.Split(null :> char[], StringSplitOptions.RemoveEmptyEntries) |> ignore

    phrase.Split((null: char[]), StringSplitOptions.RemoveEmptyEntries) |> ignore
    // </Snippet5>

let splitWithString () =
    // <Snippet6>
    let phrase = "The quick  brown fox"

    phrase.Split(Unchecked.defaultof<string[]>, StringSplitOptions.RemoveEmptyEntries) |> ignore

    phrase.Split(null :> string[], StringSplitOptions.RemoveEmptyEntries) |> ignore

    phrase.Split((null: string[]), StringSplitOptions.RemoveEmptyEntries) |> ignore
    // </Snippet6>