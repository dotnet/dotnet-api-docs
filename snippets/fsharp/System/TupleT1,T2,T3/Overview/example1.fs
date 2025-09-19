// <Snippet1>
open System

let computeStatistics (scores: Tuple<string, double, int>[]) = 
    let mutable n = 0
    let mutable sum = 0.

    // Compute the mean.
    for score in scores do
        n <- n + score.Item3
        sum <- sum + score.Item2 * double score.Item3
    let mean = sum / double n
    
    // Compute the standard deviation.
    let mutable ss = 0.
    for score in scores do
        ss <- (score.Item2 - mean) ** 2.
    let sd = sqrt (ss / double scores.Length)
    Tuple.Create(scores.Length, mean, sd)

let scores = 
    [| Tuple.Create("Jack", 78.8, 8)
       Tuple.Create("Abbey", 92.1, 9) 
       Tuple.Create("Dave", 88.3, 9)
       Tuple.Create("Sam", 91.7, 8) 
       Tuple.Create("Ed", 71.2, 5)
       Tuple.Create("Penelope", 82.9, 8)
       Tuple.Create("Linda", 99.0, 9)
       Tuple.Create("Judith", 84.3, 9) |]
let result = computeStatistics scores
printfn $"Mean score: {result.Item2:N2} (SD={result.Item3:N2}) (n={result.Item1})"
// The example displays the following output:
//       Mean score: 87.02 (SD=0.96) (n=8)
// </Snippet1>