module data2

// <Snippet4>
open System
// open System.IO

let getResult () =
    let chunkSize = 50000000
    let nToGet = 200000000
    let rnd = Random()
    // use fs = new FileStream(@".\data.bin", FileMode.Create)
    // use bin = new BinaryWriter(fs)
    // bin.Write 0
    let mutable n = 0
    let mutable sum = 0.
    for _ = 0 to int (ceil (nToGet / chunkSize |> float) - 1.) do
        for _ = 0 to min (nToGet - n - 1) (chunkSize - 1) do
            let value = rnd.NextDouble()
            sum <- sum + value
            n <- n + 1
            // bin.Write(value)
    // bin.Seek(0, SeekOrigin.Begin) |> ignore
    // bin.Write n
    sum / float n, n

let mean, n = getResult ()
printfn $"Sample mean: {mean}, N = {n:N0}"

// The example displays output like the following:
//    Sample mean: 0.500022771458399, N = 200,000,000
// </Snippet4>