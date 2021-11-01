module Next

// Example of the Random.Next() methods.
open System

//<Snippet1>
let noBoundsRandoms seed =
    printfn "\nRandom object, seed = %i, no bounds:" seed
    let randObj = Random seed

    // Generate six random integers from 0 to int.MaxValue.
    for _ = 1 to 6 do
        printf "%11i " (randObj.Next())
    printfn ""

// Generate random numbers with an upper bound specified.
let upperBoundRandoms seed upper = 
    printfn "\nRandom object, seed = %i, upper bound = %i" seed upper
    let randObj = Random seed

    // Generate six random integers from 0 to the upper bound.
    for _ = 1 to 6 do
        printf "%11i " (randObj.Next(upper))
    printfn ""

// Generate random numbers with both bounds specified.
let bothBoundRandoms seed lower upper =
    printfn "\nRandom object, seed = %i, lower = %i, upper = %i: " seed lower upper
    let randObj = Random seed

    // Generate six random integers from the lower to upper bounds.
    for _ = 1 to 6 do 
        printf "%11i " (randObj.Next(lower,upper))
    printfn ""

printfn "This example of the Random.Next() methods\ngenerates the following.\n"

printfn """Create Random objects all with the same seed and generate
sequences of numbers with different bounds. Note the effect
that the various combinations of bounds have on the sequences."""

noBoundsRandoms 234

upperBoundRandoms 234 Int32.MaxValue
upperBoundRandoms 234 2000000000
upperBoundRandoms 234 200000000

bothBoundRandoms 234 0 Int32.MaxValue
bothBoundRandoms 234 Int32.MinValue Int32.MaxValue
bothBoundRandoms 234 -2000000000 2000000000
bothBoundRandoms 234 -200000000 200000000
bothBoundRandoms 234 -2000 2000

(*
This example of the Random.Next() methods
generates the following output.

Create Random objects all with the same seed and generate
sequences of numbers with different bounds. Note the effect
that the various combinations of bounds have on the sequences.

Random object, seed = 234, no bounds:
2091148258  1024955023   711273344  1081917183  1833298756   109460588

Random object, seed = 234, upper bound = 2147483647:
2091148258  1024955023   711273344  1081917183  1833298756   109460588

Random object, seed = 234, upper bound = 2000000000:
1947533580   954563751   662424922  1007613896  1707392518   101943116

Random object, seed = 234, upper bound = 200000000:
194753358    95456375    66242492   100761389   170739251    10194311

Random object, seed = 234, lower = 0, upper = 2147483647:
2091148258  1024955023   711273344  1081917183  1833298756   109460588

Random object, seed = 234, lower = -2147483648, upper = 2147483647:
2034812868   -97573602  -724936960    16350718  1519113864 -1928562472

Random object, seed = 234, lower = -2000000000, upper = 2000000000:
1895067160   -90872498  -675150156    15227793  1414785036 -1796113767

Random object, seed = 234, lower = -200000000, upper = 200000000:
189506716    -9087250   -67515016     1522779   141478503  -179611377

Random object, seed = 234, lower = -2000, upper = 2000:
    1895         -91        -676          15        1414       -1797
*)
//</Snippet1>