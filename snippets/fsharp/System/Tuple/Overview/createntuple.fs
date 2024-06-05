module createntuple

// <Snippet17>
open System

let primes = Tuple.Create(2, 3, 5, 7, 11, 13, 17, 19)
printfn $"Prime numbers less than 20: {primes.Item1}, {primes.Item2}, {primes.Item3}, {primes.Item4}, {primes.Item5}, {primes.Item6}, {primes.Item7}, and {primes.Rest.Item1}"
//    Prime numbers less than 20: 2, 3, 5, 7, 11, 13, 17, and 19
// </Snippet17>