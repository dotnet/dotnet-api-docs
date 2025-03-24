module TestDelegate

// <Snippet1>
open System

type StringCopy = delegate of stringArray1: string [] * 
                              stringArray2: string [] * 
                              indexToStart: int -> unit

let copyStrings (source: string []) (target: string []) startPos =
    if source.Length <> target.Length then
        raise (IndexOutOfRangeException "The source and target arrays must have the same number of elements.")

    for i = startPos to source.Length - 1 do
        target.[i] <- source.[i]

let ordinals = [| "First"; "Second"; "Third"; "Fourth"; "Fifth" |]
let copiedOrdinals: string [] = Array.zeroCreate ordinals.Length

let copyOperation = StringCopy copyStrings

copyOperation.Invoke(ordinals, copiedOrdinals, 3)

for ordinal in copiedOrdinals do
    printfn "%s" (if String.IsNullOrEmpty ordinal then "<None>" else ordinal)

// </Snippet1>
