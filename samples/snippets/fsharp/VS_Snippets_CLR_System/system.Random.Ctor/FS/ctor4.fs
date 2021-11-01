module Ctor4

// <Snippet4>
open System
open System.Threading

let showRandomNumbers (rand: Random) =
    printfn ""
    let values : byte [] = Array.zeroCreate 5
    rand.NextBytes values
    for value in values do 
        printf "%5i" value
    printfn ""

let rand1 = Random(DateTime.Now.Ticks &&& 0x0000FFFFL |> int)
let rand2 = Random(DateTime.Now.Ticks &&& 0x0000FFFFL |> int)
Thread.Sleep 20
let rand3 = Random(DateTime.Now.Ticks &&& 0x0000FFFFL |> int)
showRandomNumbers rand1
showRandomNumbers rand2
showRandomNumbers rand3

// The example displays output similar to the following:
//   145  214  177  134  173
//
//   145  214  177  134  173
//
//   126  185  175  249  157
// </Snippet4>