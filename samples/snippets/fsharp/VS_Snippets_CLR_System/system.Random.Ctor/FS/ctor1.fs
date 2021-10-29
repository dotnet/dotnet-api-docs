// <Snippet2>
open System
open System.Threading

let showRandomNumbers (rand: Random) =
    printfn ""
    let values : byte [] = Array.zeroCreate 5
    rand.NextBytes values
    for value in values do 
        printf "%5i" value
    printfn ""

let rand1 = Random()
let rand2 = Random()
Thread.Sleep 2000
let rand3 = Random()
showRandomNumbers rand1
showRandomNumbers rand2
showRandomNumbers rand3

// The example displays an output similar to the following:
//       28   35  133  224   58
//
//       28   35  133  224   58
//
//       32  222   43  251   49
// </Snippet2>