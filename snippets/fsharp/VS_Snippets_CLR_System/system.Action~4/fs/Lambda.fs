module TestLambdaExpression

// <Snippet4>
open System

let copyStrings (source: string []) (target: string []) startPos number =
    if source.Length <> target.Length then
        raise (IndexOutOfRangeException "The source and target arrays must have the same number of elements.")

    for i = startPos to startPos + number - 1 do
        target.[i] <- source.[i]

let ordinals =
    [| "First"; "Second"; "Third"; "Fourth"; "Fifth"
       "Sixth"; "Seventh"; "Eighth"; "Ninth"; "Tenth" |]

let copiedOrdinals: string [] = Array.zeroCreate ordinals.Length

let copyOperation = Action<_, _, _, _> (fun s1 s2 pos num -> copyStrings s1 s2 pos num)

copyOperation.Invoke(ordinals, copiedOrdinals, 3, 5)

for ordinal in copiedOrdinals do
    printfn "%s" (if String.IsNullOrEmpty ordinal then "<None>" else ordinal)

// </Snippet4>