module TestAction3

// <Snippet2>
open System

let copyStrings (source: string []) (target: string []) startPos =
    if source.Length <> target.Length then
        raise (IndexOutOfRangeException "The source and target arrays must have the same number of elements.")

    for i = startPos to source.Length - 1 do
        target.[i] <- source.[i]

let ordinals = [| "First"; "Second"; "Third"; "Fourth"; "Fifth" |]
let copiedOrdinals = Array.zeroCreate<string> ordinals.Length

let copyOperation = Action<_,_,_> copyStrings

copyOperation.Invoke(ordinals, copiedOrdinals, 3)

for ordinal in copiedOrdinals do
    printfn "%s" (if String.IsNullOrEmpty ordinal then "<None>" else ordinal)

// </Snippet2>
