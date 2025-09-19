open System

// <Snippet2>
let rnd = Random()

let frequency = 
    Array.init 100 (fun _ -> 
        let number = rnd.NextDouble()
        floor (number * 10.0) |> int )
    |> Array.countBy id
    |> Array.map snd

printfn "Distribution of Random Numbers:"
for i = frequency.GetLowerBound 0 to frequency.GetUpperBound 0 do
    printfn $"0.{i}0-0.{i}9       {frequency.[i]}"

// The following example displays output similar to the following:
//       Distribution of Random Numbers:
//       0.00-0.09       16
//       0.10-0.19       8
//       0.20-0.29       8
//       0.30-0.39       11
//       0.40-0.49       9
//       0.50-0.59       6
//       0.60-0.69       13
//       0.70-0.79       6
//       0.80-0.89       9
//       0.90-0.99       14
// </Snippet2>
