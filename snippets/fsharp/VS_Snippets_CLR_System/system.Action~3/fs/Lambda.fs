module TestLambda

// <Snippet4>
open System

let copyStrings (source: string []) (target: string []) startPos =
    if source.Length <> target.Length then
        raise (IndexOutOfRangeException "The source and target arrays must have the same number of elements.")

    for i = startPos to source.Length - 1 do
        target.[i] <- source.[i]

let ordinals = [| "First"; "Second"; "Third"; "Fourth"; "Fifth" |]
let copiedOrdinals: string [] = Array.zeroCreate ordinals.Length

let copyOperation = Action<_,_,_> (fun s1 s2 pos -> copyStrings s1 s2 pos)

copyOperation.Invoke(ordinals, copiedOrdinals, 3)

for ordinal in copiedOrdinals do
    printfn "%s" (if String.IsNullOrEmpty ordinal then "<None>" else ordinal)

// </Snippet4>
