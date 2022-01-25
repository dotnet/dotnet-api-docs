module WriteLine6

open System

// <Snippet6>
let rnd = Random()

// Generate five random Boolean values.
for _ = 1 to 5 do
    let bln = rnd.Next(0, 2) = 1
    Console.WriteLine $"True or False: {bln}"

// The example displays an output similar to the following:
//       True or False: False
//       True or False: True
//       True or False: False
//       True or False: False
//       True or False: True
// </Snippet6>