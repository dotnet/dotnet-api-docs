module join4.fs
// <Snippet4>
// This F# example uses Seq.filter instead of Linq.
open System

let getAlphabet upper =
    let charValue = if upper then 65 else 97
    seq {
        for i = 0 to 25 do
            charValue + i
            |> char
            |> string
    }

String.Join(" ", getAlphabet true |> Seq.filter (fun letter -> letter.CompareTo "M" >= 0))
|> printfn "%s"

// The example displays the following output:
//      M N O P Q R S T U V W X Y Z
// </Snippet4>
