module concat2

// <Snippet3>
// This example uses the F# Seq.filter function instead of Linq.
open System

let getAlphabet upper =
    let charValue = if upper then 65 else 97
    seq {
        for i = 0 to 25 do
            charValue + i |> char |> string
    }

getAlphabet true
|> Seq.filter (fun letter -> letter.CompareTo "M" >= 0)
|> String.Concat
|> printfn "%s"
// The example displays the following output:
//      MNOPQRSTUVWXYZ
// </Snippet3>