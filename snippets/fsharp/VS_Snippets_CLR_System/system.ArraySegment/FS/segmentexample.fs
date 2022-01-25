module segmentexample

// <Snippet2>
open System
open System.Threading.Tasks

// Create array.
let arr = Array.init 50 (fun i -> i + 1)

// Handle array in segments of 10.
let tasks =
    Array.chunkBySize 10 arr
    |> Array.mapi (fun m elements ->
        let mutable segment = ArraySegment<int>(arr, m * 10, elements.Length)
        task {
            for i = 0 to segment.Count - 1 do
                segment[i] <- segment[i] * (m + 1)
        } :> Task)

try
    Task.WhenAll(tasks).Wait()
    let mutable i = 0

    for value in arr do
        printf $"{value, 3} "
        i <- i + 1
        if i % 18 = 0 then printfn ""

with :? AggregateException as e ->
    printfn "Errors occurred when working with the array:"

    for inner in e.InnerExceptions do
        printfn $"{inner.GetType().Name}: {inner.Message}"


// The example displays the following output:
//      1   2   3   4   5   6   7   8   9  10  22  24  26  28  30  32  34  36
//     38  40  63  66  69  72  75  78  81  84  87  90 124 128 132 136 140 144
//    148 152 156 160 205 210 215 220 225 230 235 240 245 250
// </Snippet2>
