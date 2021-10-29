//<Snippet1>
// Example of the Random class constructors and Random.NextDouble()
// method.
open System
open System.Threading

// Generate random numbers from the specified Random object.
let runIntNDoubleRandoms (randObj: Random) =
    // Generate the first six random integers.
    for _ = 1 to 6 do
        printf $" {randObj.Next(),10} "
    printfn ""

    // Generate the first six random doubles.
    for _ = 1 to 6 do
        printf $" {randObj.NextDouble():F8} "
    printfn ""

let fixedSeedRandoms seed =
    printfn "\nRandom numbers from a Random object with seed = %i:" seed
    let fixRand = Random seed
    
    runIntNDoubleRandoms fixRand

let autoSeedRandoms () =
    // Wait to allow the timer to advance.
    Thread.Sleep 1

    printfn "\nRandom numbers from a Random object with an auto-generated seed: "
    let autoRand = Random ()

    runIntNDoubleRandoms autoRand

printfn "This example of the Random class constructors and Random.NextDouble()"
printfn "generates the following output.\n"
printfn "Create Random objects, and then generate and display six integers and" 
printfn "six doubles from each."
 
fixedSeedRandoms 123
fixedSeedRandoms 123

fixedSeedRandoms 456
fixedSeedRandoms 456

autoSeedRandoms ()
autoSeedRandoms ()
autoSeedRandoms ()

(*
This example of the Random class constructors and Random.NextDouble()
generates an output similar to the following:

Create Random objects, and then generate and display six integers and
six doubles from each.

Random numbers from a Random object with seed = 123:
 2114319875  1949518561  1596751841  1742987178  1586516133   103755708
 0.01700087  0.14935942  0.19470390  0.63008947  0.90976122  0.49519146

Random numbers from a Random object with seed = 123:
 2114319875  1949518561  1596751841  1742987178  1586516133   103755708
 0.01700087  0.14935942  0.19470390  0.63008947  0.90976122  0.49519146

Random numbers from a Random object with seed = 456:
 2044805024  1323311594  1087799997  1907260840   179380355   120870348
 0.21988117  0.21026556  0.39236514  0.42420498  0.24102703  0.47310170

Random numbers from a Random object with seed = 456:
 2044805024  1323311594  1087799997  1907260840   179380355   120870348
 0.21988117  0.21026556  0.39236514  0.42420498  0.24102703  0.47310170

Random numbers from a Random object with an auto-generated seed:
  380213349   127379247  1969091178  1983029819  1963098450  1648433124
 0.08824121  0.41249688  0.36445811  0.05637512  0.62702451  0.49595560

Random numbers from a Random object with an auto-generated seed:
  861793304  2133528783  1947358439   124230908   921262645  1087892791
 0.56880819  0.42934091  0.60162512  0.74388610  0.99432979  0.30310005

Random numbers from a Random object with an auto-generated seed:
 1343373259  1992194672  1925625700   412915644  2026910487   527352458
 0.04937517  0.44618494  0.83879212  0.43139707  0.36163507  0.11024451
*)
//</Snippet1>

// Code added to show how to initialize Random objects with the
// same timer value that will produce unique random number sequences.
let createEngineWithSameTimer () =
// <Snippet3>
    let randomEngines = 
        Array.init 4 (fun i ->
            Operators.(>>>) DateTime.Now.Ticks i
            |> int
            |> Random )
// </Snippet3>
    for i in randomEngines do
        printfn "%i" (i.Next())
