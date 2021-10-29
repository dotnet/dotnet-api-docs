open System

// <Snippet2>
// Instantiate random number generator using system-supplied value as seed.
let rand = Random()

// Generate and display 5 random byte (integer) values.
let bytes : byte [] = Array.zeroCreate 5
rand.NextBytes bytes
printfn "Five random byte values:"
for byte in bytes do
    printf "%5i" byte
printfn ""

// Generate and display 5 random integers.
printfn "Five random integer values:"
for _ = 0 to 4 do
    printf $"{rand.Next(),15:N0}" 
printfn ""

// Generate and display 5 random integers between 0 and 100.
printfn "Five random integers between 0 and 100:"
for _ = 0 to 4 do
    printf $"{rand.Next 101,8:N0}"
printfn ""

// Generate and display 5 random integers from 50 to 100.
printfn "Five random integers between 50 and 100:"
for _ = 0 to 4 do
    printf $"{rand.Next(50, 101),8:N0}"
printfn ""

// Generate and display 5 random floating point values from 0 to 1.
printfn "Five Doubles."
for _ = 0 to 4 do
    printf $"{rand.NextDouble(),8:N3}"
printfn ""

// Generate and display 5 random floating point values from 0 to 5.
printfn "Five Doubles between 0 and 5."
for _ = 0 to 4 do
    printf $"{rand.NextDouble() * 5.0,8:N3}"

// The example displays output like the following:
//    Five random byte values:
//      194  185  239   54  116
//    Five random integer values:
//        507,353,531  1,509,532,693  2,125,074,958  1,409,512,757    652,767,128
//    Five random integers between 0 and 100:
//          16      78      94      79      52
//    Five random integers between 50 and 100:
//          56      66      96      60      65
//    Five Doubles.
//       0.943   0.108   0.744   0.563   0.415
//    Five Doubles between 0 and 5.
//       2.934   3.130   0.292   1.432   4.369
// </Snippet2>
