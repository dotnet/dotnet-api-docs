module example1

// <Snippet1>
open System

let scores = 
    [| Tuple<string, Nullable<int>>("Jack", 78)
       Tuple<string, Nullable<int>>("Abbey", 92) 
       Tuple<string, Nullable<int>>("Dave", 88)
       Tuple<string, Nullable<int>>("Sam", 91) 
       Tuple<string, Nullable<int>>("Ed", Nullable())
       Tuple<string, Nullable<int>>("Penelope", 82)
       Tuple<string, Nullable<int>>("Linda", 99)
       Tuple<string, Nullable<int>>("Judith", 84) |]

let computeMean (scores: Tuple<string, Nullable<int>>[]) (n: int outref) = 
    n <- 0      
    let mutable sum = 0
    for _, score in scores do
        if score.HasValue then
            n <- n + 1
            sum <- sum + score.Value
    if n > 0 then
        double sum / double n
    else
        0

let mutable number = 0
let mean = computeMean scores &number
printfn $"Average test score: {mean:N2} (n={number})"
// The example displays the following output:
//       Average test score: 87.71 (n=7)
// </Snippet1>