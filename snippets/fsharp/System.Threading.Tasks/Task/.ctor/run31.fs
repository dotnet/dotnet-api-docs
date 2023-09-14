module run31
// <Snippet2>
open System
open System.IO
open System.Text.RegularExpressions
open System.Threading.Tasks

let pattern = @"\p{P}*\s+"
let titles = [| "Sister Carrie"; "The Financier" |]

let tasks =
    Array.map (fun title ->
        Task.Run(fun () ->
            // Create filename from title.
            let fn = title + ".txt"

            if File.Exists fn then
                use sr = new StreamReader(fn)
                let input = sr.ReadToEndAsync().Result
                Regex.Matches(input, pattern).Count
            else
                0)) titles

tasks |> Seq.cast |> Array.ofSeq |> Task.WaitAll

printfn "Word Counts:\n"

for i = 0 to tasks.Length - 1 do
    printfn $"%s{titles.[i]}: %10d{tasks.[i].Result} words"

// The example displays the following output:
//       Sister Carrie:    159,374 words
//       The Financier:    196,362 words
// </Snippet2>
