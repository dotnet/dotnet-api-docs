module Next2

open System

//<Snippet2>
let rnd = Random()

printfn "\n20 random integers from -100 to 100:"
for i = 1 to 20 do 
    printf "%6i" (rnd.Next(-100,100))
    if i % 5 = 0 then printfn ""

printfn "\n20 random integers from 1000 to 10000:"
for i = 1 to 20 do 
    printf "%8i" (rnd.Next(1000,10001))
    if i % 5 = 0 then printfn ""

printfn "\n20 random integers from 1 to 10:"
for i = 1 to 20 do 
    printf "%6i" (rnd.Next(1,11))
    if i % 5 = 0 then printfn ""

// The example displays output similar to the following:
//       20 random integers from -100 to 100:
//           65   -95   -10    90   -35
//          -83   -16   -15   -19    41
//          -67   -93    40    12    62
//          -80   -95    67   -81   -21
//
//       20 random integers from 1000 to 10000:
//           4857    9897    4405    6606    1277
//           9238    9113    5151    8710    1187
//           2728    9746    1719    3837    3736
//           8191    6819    4923    2416    3028
//
//       20 random integers from 1 to 10:
//            9     8     5     9     9
//            9     1     2     3     8
//            1     4     8    10     5
//            9     7     9    10     5
// </Snippet2>
